using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services
{
    public class CasualMatchService : ICasualMatchService
    {
        private readonly ICasualMatchRepository _casualMatchRepository;

        public CasualMatchService(ICasualMatchRepository casualMatchRepository)
        {
            _casualMatchRepository = casualMatchRepository;
        }
        public List<CasualMatchDto> GetAll()
        {
            var matches = _casualMatchRepository.GetAll();
            return matches.Select(CasualMatchDto.FromEntity).ToList();
        }

        public CasualMatchDto? GetById(int id)
        {
            var match = _casualMatchRepository.GetById(id) ?? throw new NotFoundException($"Match {id} not found");
            return CasualMatchDto.FromEntity(match);
        }

        public CasualMatchDto? GetByJoinCode(string code)
        {
            var match = _casualMatchRepository.GetByJoinCode(code) ?? throw new NotFoundException($"Code {code} not found");
            return CasualMatchDto.FromEntity(match);
        }

        public CasualMatchDto Create(CasualMatchCreateRequest request, Player authenticatedPlayer)
        {
            CasualMatch match = new CasualMatch();
            match.Admin = authenticatedPlayer;
            match.JoinCode = CodeGenerator.GenerateRandomCode(18);
            match.Country = authenticatedPlayer.Country;
            match.City = authenticatedPlayer.City;
            match.Schedule = request.Schedule;
            match.MatchFormat = request.MatchFormat;
            match.MatchMode = MatchMode.Casual;
            match.Players.Add(authenticatedPlayer);

            var createdMatch = _casualMatchRepository.Create(match);
            return CasualMatchDto.FromEntity(createdMatch);
        }

        public void Delete(int id, Player authenticatedPlayer)
        {
            var match = _casualMatchRepository.GetById(id) ?? throw new NotFoundException($"Match {id} not found");
            if (match.Admin.Id != authenticatedPlayer.Id) throw new NotAllowedException("Acceso denegado.");
            _casualMatchRepository.Delete(match);
        }

        public void Join(Player authenticatedPlayer, string code)
        {
            var match = _casualMatchRepository.GetByJoinCode(code) ?? throw new NotFoundException($"Code {code} not found");
            
            if(match.Players.Contains(authenticatedPlayer))
                throw new InvalidOperationException($"{authenticatedPlayer.Username} ya se encuentra en el partido");

            var format = match.MatchFormat;

            if (format == MatchFormat.Futbol5)
            {
                if (match.Players.Count >= 10)
                {
                    match.Open = false;
                    throw new InvalidOperationException("No se pueden agregar más de 10 jugadores a un partido de Futbol 5.");
                }

            }
            else if (format == MatchFormat.Futbol7)
            {
                if (match.Players.Count >= 14) 
                { 
                    match.Open = false;
                    throw new InvalidOperationException("No se pueden agregar más de 14 jugadores a un partido de Futbol 7.");
                } 
            }
            else
            {
                if (match.Players.Count >= 22)
                {
                    match.Open = false;
                    throw new InvalidOperationException("No se pueden agregar más de 22 jugadores a un partido de Futbol 11.");
                }
            }

            match.Players.Add(authenticatedPlayer);
            _casualMatchRepository.Update(match);
        }

        public void Leave(Player authenticatedPlayer, Player player, string code)
        {
            var match = _casualMatchRepository.GetByJoinCode(code) ?? throw new NotFoundException($"Code {code} not found");

            if (!match.Players.Contains(player))
                throw new InvalidOperationException($"{player.Username} no se encuentra en el partido");

            if (player.Id == match.Admin.Id && player.Username == authenticatedPlayer.Username)
            {
                Delete(match.Id, authenticatedPlayer);
                return;
            }

            if (player.Id != authenticatedPlayer.Id && authenticatedPlayer.Id != match.Admin.Id)
                throw new InvalidOperationException($"No puedes borrar a este usuario");

            match.Players.Remove(player);
            _casualMatchRepository.Update(match);

        }
    }
}


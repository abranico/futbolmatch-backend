using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerRepository _playerRepository;
        public TeamService(ITeamRepository teamRepository, IPlayerRepository playerRepository)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
        }
        public List<Team> GetAll()
        {
            return _teamRepository.GetAll();
        }

        public Team? GetById(int id)
        {
            var team = _teamRepository.GetById(id) ?? throw new NotFoundException($"Team {id} not found");
            return team;
        }

        public Team Create(TeamCreateRequest request, Player player)
        {
            if(player.isCaptain) throw new InvalidOperationException("No puedes crear mas de un equipo.");

            Team team = new Team();
            team.Name = request.Name;
            team.CaptainId = player.Id;
            team.Country = player.Country;
            team.City = player.City;
            team.Logo = request.Logo;
            team.Players.Add(player);
            team.JoinCode = CodeGenerator.GenerateRandomCode(18);

            player.isCaptain = true;
            _playerRepository.Update(player);
            return _teamRepository.Create(team);

        }

        public void Update(int id, TeamUpdateRequest request, int userId)
        {
            var team = _teamRepository.GetById(id) ?? throw new NotFoundException($"Team {id} not found");
            if (team.CaptainId != userId) throw new InvalidOperationException("Acceso denegado.");

            team.Name = request.Name;
            team.Logo = request.Logo;

            _teamRepository.Update(team);
        }

        public void Delete(int id, int userId)
        {
            var team = _teamRepository.GetById(id) ?? throw new NotFoundException($"Team {id} not found");
            if (team.CaptainId != userId) throw new InvalidOperationException("Acceso denegado.");
            _teamRepository.Delete(team);
        }

        public void Join(Player authenticatedPlayer, string code)
        {
            var team = _teamRepository.GetByJoinCode(code) ?? throw new NotFoundException($"Code {code} not found");

            if (team.Players.Contains(authenticatedPlayer))
                throw new InvalidOperationException($"{authenticatedPlayer.Username} ya se encuentra en el partido");

            team.Players.Add(authenticatedPlayer);
            _teamRepository.Update(team);
        }

        public void Leave(Player authenticatedPlayer, Player player, string code)
        {
            var team = _teamRepository.GetByJoinCode(code) ?? throw new NotFoundException($"Code {code} not found");

            if (!team.Players.Contains(player))
                throw new InvalidOperationException($"{player.Username} no se encuentra en el partido");

            if (player.Id == team.CaptainId && player.Username == authenticatedPlayer.Username)
            {
                Delete(player.Id, team.Id);
                return;
            }

            if (player.Username != authenticatedPlayer.Username && authenticatedPlayer.Id != team.CaptainId)
                throw new InvalidOperationException($"No puedes borrar a este usuario");

            team.Players.Remove(player);
            _teamRepository.Update(team);
        }

    }
}

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
        public List<TeamDto> GetAll()
        {
            var teams = _teamRepository.GetAll();
            return teams.Select(TeamDto.FromEntity).ToList();
        }

        public TeamDto? GetById(int id)
        {
            var team = _teamRepository.GetById(id) ?? throw new NotFoundException($"Team {id} not found");
            return TeamDto.FromEntity(team);
        }

        public TeamDto Create(TeamCreateRequest request, Player player)
        {
            if(player.isCaptain) throw new NotAllowedException("No puedes crear mas de un equipo.");

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
            var createdTeam = _teamRepository.Create(team);

            return TeamDto.FromEntity(createdTeam);

        }

        public void Update(int id, TeamUpdateRequest request, int userId)
        {
            var team = _teamRepository.GetById(id) ?? throw new NotFoundException($"Team {id} not found");
            if (team.CaptainId != userId) throw new NotAllowedException("Acceso denegado.");

            team.Name = request.Name;
            team.Logo = request.Logo;

            _teamRepository.Update(team);
        }

        public void Delete(int id, Player authenticatedPlayer)
        {
            var team = _teamRepository.GetById(id) ?? throw new NotFoundException($"Team {id} not found");
            if (team.CaptainId != authenticatedPlayer.Id) throw new NotAllowedException("Acceso denegado.");
            authenticatedPlayer.isCaptain = false;
            _playerRepository.Update(authenticatedPlayer);
            _teamRepository.Delete(team);
        }

        public void Join(Player authenticatedPlayer, string code)
        {
            var team = _teamRepository.GetByJoinCode(code) ?? throw new NotFoundException($"Code {code} not found");

            if (team.Players.Contains(authenticatedPlayer))
                throw new NotAllowedException($"{authenticatedPlayer.Username} ya se encuentra en el partido");

            team.Players.Add(authenticatedPlayer);
            _teamRepository.Update(team);
        }

        public void Leave(Player authenticatedPlayer, Player player, string code)
        {
            var team = _teamRepository.GetByJoinCode(code) ?? throw new NotFoundException($"Code {code} not found");

            if (!team.Players.Contains(player))
                throw new NotAllowedException($"{player.Username} no se encuentra en el partido");

            if (player.Id == team.CaptainId && player.Username == authenticatedPlayer.Username)
            {
                Delete(team.Id, authenticatedPlayer);
                authenticatedPlayer.isCaptain = false;
                _playerRepository.Update(player);
                return;
            }

            if (player.Username != authenticatedPlayer.Username && authenticatedPlayer.Id != team.CaptainId)
                throw new NotAllowedException($"No puedes borrar a este usuario");

            team.Players.Remove(player);
            _teamRepository.Update(team);
        }

    }
}

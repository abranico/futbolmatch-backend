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

        public TeamDto Create(TeamCreateRequest request, int userId)
        {
            Player authenticatedPlayer = _playerRepository.GetById(userId);
            if (authenticatedPlayer.isCaptain) throw new NotAllowedException("No puedes crear mas de un equipo.");

            Team team = new Team();
            team.Name = request.Name;
            team.Captain = authenticatedPlayer;
            team.Country = authenticatedPlayer.Country;
            team.City = authenticatedPlayer.City;
            team.Logo = request.Logo;
            team.Players.Add(authenticatedPlayer);
            team.JoinCode = CodeGenerator.GenerateRandomCode(18);

            authenticatedPlayer.isCaptain = true;
            authenticatedPlayer.Teams.Add(team);
            _playerRepository.Update(authenticatedPlayer);

            var createdTeam = _teamRepository.Create(team);

            return TeamDto.FromEntity(createdTeam);

        }

        public void Update(int id, TeamUpdateRequest request, int userId)
        {
            Player authenticatedPlayer = _playerRepository.GetById(userId);
            var team = _teamRepository.GetById(id) ?? throw new NotFoundException($"Team {id} not found");
            if (team.Captain.Id != userId && authenticatedPlayer.Role != Role.Admin) throw new NotAllowedException("Acceso denegado.");

            team.Name = request.Name;
            team.Logo = request.Logo;

            _teamRepository.Update(team);
        }

        public void Delete(int id, int userId)
        {
            Player authenticatedPlayer = _playerRepository.GetById(userId);         
            var team = _teamRepository.GetById(id) ?? throw new NotFoundException($"Team {id} not found");
            Player player = _playerRepository.GetById(team.Captain.Id);

            if (team.Captain.Id != authenticatedPlayer.Id && authenticatedPlayer.Role != Role.Admin) throw new NotAllowedException("Acceso denegado.");

            player.isCaptain = false;
            _playerRepository.Update(player);
            _teamRepository.Delete(team);
        }

        public void Join(int userId, string code)
        {
            Player authenticatedPlayer = _playerRepository.GetById(userId);
            var team = _teamRepository.GetByJoinCode(code) ?? throw new NotFoundException($"Code {code} not found");

            if (team.Players.Contains(authenticatedPlayer))
                throw new NotAllowedException($"{authenticatedPlayer.Username} ya se encuentra en el partido");

            team.Players.Add(authenticatedPlayer);
            authenticatedPlayer.Teams.Add(team);
            _playerRepository.Update(authenticatedPlayer);
            _teamRepository.Update(team);
        }

        public void Leave(int userId, string username, string code)
        {
            Player authenticatedPlayer = _playerRepository.GetById(userId);
            Player? player = _playerRepository.GetByUsername(username) ?? throw new NotFoundException($"Player {username} not found");

            var team = _teamRepository.GetByJoinCode(code) ?? throw new NotFoundException($"Code {code} not found");

            if (!team.Players.Contains(player))
                throw new NotAllowedException($"{player.Username} no se encuentra en el partido");

            if (player.Id == team.Captain.Id && player.Username == authenticatedPlayer.Username)
            {
                Delete(team.Id, authenticatedPlayer.Id);
                authenticatedPlayer.isCaptain = false;
                _playerRepository.Update(player);
                return;
            }

            if (player.Username != authenticatedPlayer.Username && authenticatedPlayer.Id != team.Captain.Id)
                throw new NotAllowedException($"No puedes borrar a este usuario");

            team.Players.Remove(player);
            player.Teams.Remove(team);
            _playerRepository.Update(player);
            _teamRepository.Update(team);
        }

    }
}

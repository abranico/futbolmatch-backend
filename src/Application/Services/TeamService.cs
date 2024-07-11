using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
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
            Team team = new Team();
            team.Name = request.Name;
            team.CaptainId = player.Id;
            team.Country = player.Country;
            team.City = player.City;
            team.Logo = request.Logo;            

            return _teamRepository.Create(team);

        }

        public void Update(int id, TeamUpdateRequest request)
        {
            var team = _teamRepository.GetById(id) ?? throw new NotFoundException($"Team {id} not found");
            team.Name = request.Name;
            team.Logo = request.Logo;

            _teamRepository.Update(team);
        }

        public void Delete(int id)
        {
            var team = _teamRepository.GetById(id) ?? throw new NotFoundException($"Team {id} not found");
            _teamRepository.Delete(team);
        }
    }
}

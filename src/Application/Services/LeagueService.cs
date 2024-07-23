using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;


namespace Application.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;
        private readonly ITeamRepository _teamRepository;
        public LeagueService(ILeagueRepository leagueRepository, ITeamRepository teamRepository)
        {
            _leagueRepository = leagueRepository;
            _teamRepository = teamRepository;
        }
        public List<LeagueDto> GetAll()
        {
            var leagues = _leagueRepository.GetAll();
            return leagues.Select(LeagueDto.FromEntity).ToList();
        }

        public LeagueDto? GetById(int id)
        {
            var league = _leagueRepository.GetById(id) ?? throw new NotFoundException($"League {id} not found");
            return LeagueDto.FromEntity(league);
        }

        public LeagueDto? GetByJoinCode(string code)
        {
            var league = _leagueRepository.GetByJoinCode(code) ?? throw new NotFoundException($"Code {code} not found");
            return LeagueDto.FromEntity(league);
        }

        public LeagueDto Create(LeagueCreateRequest request, Player authenticatedPlayer)
        {
            if(!authenticatedPlayer.IsPremium) throw new InvalidOperationException("Acceso denegado");
            
            League league = new League();
            league.JoinCode = CodeGenerator.GenerateRandomCode(18);
            league.Name = request.Name;
            league.Description = request.Description;
            league.Logo = request.Logo;
            league.Country = authenticatedPlayer.Country;
            league.City = authenticatedPlayer.City;
            league.Admin = authenticatedPlayer;
            league.MatchFormat = request.MatchFormat;

            var createdLeague = _leagueRepository.Create(league);
            return LeagueDto.FromEntity(createdLeague);

        }

        public void Update(int id, LeagueUpdateRequest request, int userId)
        {
            var league = _leagueRepository.GetById(id) ?? throw new NotFoundException($"League {id} not found");
            if(league.Admin.Id != userId) throw new InvalidOperationException("Acceso denegado");
            league.Name = request.Name;
            league.Description = request.Description;
            league.Logo = request.Logo;

            _leagueRepository.Update(league);
        }

        public void Delete(int id, int userId)
        {
            var league = _leagueRepository.GetById(id) ?? throw new NotFoundException($"League {id} not found");
            if (league.Admin.Id != userId) throw new InvalidOperationException("Acceso denegado");
            _leagueRepository.Delete(league);
        }

        public void Join(Player authenticatedPlayer, string code, int teamId)
        {
            Team team = _teamRepository.GetById(teamId) ?? throw new NotFoundException($"Team {teamId} not found");
            if(team.Captain.Id != authenticatedPlayer.Id) throw new InvalidOperationException("Acceso denegado");

            League league = _leagueRepository.GetByJoinCode(code) ?? throw new NotFoundException($"Code {code} is not valid");

            team.League = league;
            league.Teams.Add(team);

            _teamRepository.Update(team);
            _leagueRepository.Update(league);
        }

        public void Leave(Player authenticatedPlayer, int teamId)
        {
            Team team = _teamRepository.GetById(teamId) ?? throw new NotFoundException($"Team {teamId} not found");

            League league = team.League ?? throw new NotFoundException("Este equipo no forma parte de una liga");

            if (team.Captain.Id == authenticatedPlayer.Id)
            {
                team.League = null;
                league.Teams.Remove(team);

                _teamRepository.Update(team);
                _leagueRepository.Update(league);
            }
            else if (league.Admin.Id == authenticatedPlayer.Id)
            {
                team.League = null;
                league.Teams.Remove(team);

                _teamRepository.Update(team);
                _leagueRepository.Update(league);
            }
            else
            {
                throw new InvalidOperationException("Acceso denegado");
            }
        }
    }
}

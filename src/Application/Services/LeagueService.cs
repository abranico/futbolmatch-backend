using Application.Interfaces;
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
        public List<League> GetAll()
        {
            return _leagueRepository.GetAll();
        }

        public League? GetById(int id)
        {
            var league = _leagueRepository.GetById(id) ?? throw new NotFoundException($"League {id} not found");
            return league;
        }

        public League Create(LeagueCreateRequest request, Player player)
        {
            if(!player.IsPremium) throw new InvalidOperationException("Acceso denegado");
            
            League league = new League();
            league.JoinCode = CodeGenerator.GenerateRandomCode(18);
            league.Name = request.Name;
            league.Description = request.Description;
            league.Logo = request.Logo;
            league.Country = player.Country;
            league.City = player.City;
            league.AdminId = player.Id;
            league.MatchFormat = request.MatchFormat;
            return _leagueRepository.Create(league);

        }

        public void Update(int id, LeagueUpdateRequest request, int userId)
        {
            var league = _leagueRepository.GetById(id) ?? throw new NotFoundException($"League {id} not found");
            if(league.AdminId != userId) throw new InvalidOperationException("Acceso denegado");
            league.Name = request.Name;
            league.Description = request.Description;
            league.Logo = request.Logo;

            _leagueRepository.Update(league);
        }

        public void Delete(int id, int userId)
        {
            var league = _leagueRepository.GetById(id) ?? throw new NotFoundException($"League {id} not found");
            if (league.AdminId != userId) throw new InvalidOperationException("Acceso denegado");
            _leagueRepository.Delete(league);
        }

        public void Join(int id, string code, int userId)
        {
            Team team = _teamRepository.GetById(id) ?? throw new NotFoundException($"Team {id} not found");

            List<League> leagues = _leagueRepository.GetAll();

            League league = leagues.FirstOrDefault(x => x.JoinCode == code) ?? throw new NotFoundException($"Code {code} is not valid");

            if (team.CaptainId != userId) throw new InvalidOperationException("Acceso denegado.");

            team.LeagueId = league.Id;

            _teamRepository.Update(team);
        }
    }
}

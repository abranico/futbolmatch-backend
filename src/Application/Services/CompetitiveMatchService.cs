using Application.Interfaces;
using Application.Models.Requests;
using Application.Models;
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
    public class CompetitiveMatchService : ICompetitiveMatchService
    {
        private readonly ICompetitiveMatchRepository _competitiveMatchRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ILeagueRepository _leagueRepository;
        private readonly ITeamRepository _teamRepository;

        public CompetitiveMatchService(ICompetitiveMatchRepository competitiveMatchRepository, IPlayerRepository playerRepository, ILeagueRepository leagueRepository, ITeamRepository teamRepository)
        {
            _competitiveMatchRepository = competitiveMatchRepository;
            _playerRepository = playerRepository;
            _leagueRepository = leagueRepository;
            _teamRepository = teamRepository;
        }
        public List<CompetitiveMatchDto> GetAll()
        {
            var matches = _competitiveMatchRepository.GetAll();
            return matches.Select(CompetitiveMatchDto.FromEntity).ToList();
        }

        public CompetitiveMatchDto? GetById(int id)
        {
            var match = _competitiveMatchRepository.GetById(id) ?? throw new NotFoundException($"Match {id} not found");
            return CompetitiveMatchDto.FromEntity(match);
        }
        public CompetitiveMatchDto Create(CompetitiveMatchCreateRequest request)
        {
            League league = _leagueRepository.GetById(request.LeagueId) ?? throw new NotFoundException($"League {request.LeagueId} not found");
            Team homeTeam = _teamRepository.GetById(request.HomeTeamId) ?? throw new NotFoundException($"Team {request.HomeTeamId} not found");
            Team awayTeam = _teamRepository.GetById(request.AwayTeamId) ?? throw new NotFoundException($"Team {request.AwayTeamId} not found");

            if (homeTeam.League?.Id != league.Id)
            {
                throw new InvalidOperationException($"Team {homeTeam.Name} no pertenece a la liga {league.Name}");
            }
            if (awayTeam.League?.Id != league.Id)
            {
                throw new InvalidOperationException($"Team {awayTeam.Name} no pertenece a la liga {league.Name}");
            }

            // Validar que los equipos no son el mismo
            if (homeTeam.Id == awayTeam.Id)
            {
                throw new InvalidOperationException("Los equipos son los mismos.");
            }

            CompetitiveMatch match = new CompetitiveMatch();

            match.Name = request.Name;
            match.Country = league.Country;
            match.City = league.City;
            match.Schedule = request.Schedule;
            match.MatchFormat = league.MatchFormat;
            match.MatchMode = MatchMode.Competitive;
            match.League = league;
            match.HomeTeam = homeTeam;
            match.AwayTeam = awayTeam;

            var createdMatch = _competitiveMatchRepository.Create(match);
            league.Matchs.Add(createdMatch);
            _leagueRepository.Update(league);

            return CompetitiveMatchDto.FromEntity(createdMatch);
        }

        public void UpdateMatchResult(int matchId, string result, int userId)
        {
            Player authenticatedPlayer = _playerRepository.GetById(userId) ?? throw new NotFoundException($"Player {userId} not found");
            var match = _competitiveMatchRepository.GetById(matchId) ?? throw new NotFoundException($"Match {matchId} not found");
            if (match.Result != null ) throw new NotAllowedException("Este partido ya tiene un resultado.");
      

            match.Result = result;

            _competitiveMatchRepository.Update(match);
        }

        public void DeleteMatch(int matchId, int userId)
        {
            Player authenticatedPlayer = _playerRepository.GetById(userId) ?? throw new NotFoundException($"Player {userId} not found");

            var match = _competitiveMatchRepository.GetById(matchId) ?? throw new NotFoundException($"Match {matchId} not found");
            var league = _leagueRepository.GetById(match.League.Id);
            
            league.Matchs.Remove(match);
            _leagueRepository.Update(league);
            _competitiveMatchRepository.Delete(match);
        }

    }
}

using Application.Interfaces;
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
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;
        public LeagueService(ILeagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
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
            League league = new League();

            league.JoinCode = GenerateRandomCode(8);
            league.Name = request.Name;
            league.Description = request.Description;
            league.Logo = request.Logo;
            league.Country = player.Country;
            league.City = player.City;
            league.AdminId = player.Id;
            league.MatchFormat = request.MatchFormat;

            return _leagueRepository.Create(league);

        }

        public void Update(int id, LeagueUpdateRequest request)
        {
            var league = _leagueRepository.GetById(id) ?? throw new NotFoundException($"League {id} not found");

            league.Name = request.Name;
            league.Description = request.Description;
            league.Logo = request.Logo;

            _leagueRepository.Update(league);
        }

        public void Delete(int id)
        {
            var league = _leagueRepository.GetById(id) ?? throw new NotFoundException($"League {id} not found");
            _leagueRepository.Delete(league);
        }

        public string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var code = new char[length];

            for (int i = 0; i < length; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }

            return new string(code);
        }
    }
}

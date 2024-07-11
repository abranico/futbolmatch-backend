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
    public class CasualMatchService : ICasualMatchService
    {
        private readonly ICasualMatchRepository _casualMatchRepository;

        public CasualMatchService(ICasualMatchRepository casualMatchRepository)
        {
            _casualMatchRepository = casualMatchRepository;
        }
        public List<CasualMatch> GetAll()
        {
            return _casualMatchRepository.GetAll();
        }

        public CasualMatch? GetById(int id)
        {
            var match = _casualMatchRepository.GetById(id) ?? throw new NotFoundException($"Match {id} not found");
            return match;
        }

        public CasualMatch Create(CasualMatchCreateRequest request, Player player)
        {
            CasualMatch match = new CasualMatch();
            match.Admin = player.Id;
            match.JoinCode = GenerateRandomCode(8);
            match.Country = player.Country;
            match.City = player.City;
            match.Schedule = request.Schedule;
            match.MatchFormat = request.MatchFormat;
            match.MatchMode = MatchMode.Casual;

            return _casualMatchRepository.Create(match);
        }

        public void Delete(int id)
        {
            var match = _casualMatchRepository.GetById(id) ?? throw new NotFoundException($"Match {id} not found");
            _casualMatchRepository.Delete(match);
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


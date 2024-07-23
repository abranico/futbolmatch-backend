using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILeagueService
    {
        List<LeagueDto> GetAll();
        LeagueDto? GetById(int id);
        LeagueDto? GetByJoinCode(string code);
        LeagueDto Create(LeagueCreateRequest request, Player player);
        void Update(int id, LeagueUpdateRequest request, int userId);
        void Delete(int id, int userId);
        void Join(Player authenticatedPlayer, string code, int teamId);
        void Leave(Player authenticatedPlayer, int teamId);
    }
}

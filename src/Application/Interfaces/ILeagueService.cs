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
        LeagueDto Create(LeagueCreateRequest request, int userId);
        void Update(int id, LeagueUpdateRequest request, int userId);
        void Delete(int id, int userId);
        void Join(int userId, string code);
        void Leave(int userId, int teamId);
    }
}

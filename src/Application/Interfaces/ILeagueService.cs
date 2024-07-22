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
        List<League> GetAll();
        League? GetById(int id);
        League Create(LeagueCreateRequest request, Player player);
        void Update(int id, LeagueUpdateRequest request, int userId);
        void Delete(int id, int userId);
        void Join(int id, string code, int userId);
    }
}

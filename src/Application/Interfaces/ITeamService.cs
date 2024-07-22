using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITeamService
    {
        List<Team> GetAll();
        Team? GetById(int id);
        Team Create(TeamCreateRequest request, Player player);
        void Update(int id, TeamUpdateRequest request, int userId);
        void Delete(int id, int userId);        
    }
}

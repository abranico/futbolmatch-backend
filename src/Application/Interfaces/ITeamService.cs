using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITeamService
    {
        List<TeamDto> GetAll();
        TeamDto? GetById(int id);
        TeamDto Create(TeamCreateRequest request, int userId);
        void Update(int id, TeamUpdateRequest request, int userId);
        void Delete(int id, int userId);
        void Join(int userId, string code);
        void Leave(int userId, string username, string code);
    }
}

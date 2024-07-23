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
        TeamDto Create(TeamCreateRequest request, Player player);
        void Update(int id, TeamUpdateRequest request, int userId);
        void Delete(int id, Player authenticatedPlayer);
        void Join(Player player, string code);
        void Leave(Player authenticatedPlayer, Player player, string code);
    }
}

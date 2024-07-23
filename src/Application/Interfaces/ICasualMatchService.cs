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
    public interface ICasualMatchService
    {
        List<CasualMatchDto> GetAll();
        CasualMatchDto? GetById(int id);
        CasualMatchDto? GetByJoinCode(string code);
        CasualMatchDto Create(CasualMatchCreateRequest request, Player player);
        void Delete(int id, Player authenticatedPlayer);
        void Join(Player authenticatedPlayer, string code);
        void Leave(Player authenticatedPlayer, Player player, string code);
    }
}

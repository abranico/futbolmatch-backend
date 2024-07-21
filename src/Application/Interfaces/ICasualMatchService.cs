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
        List<CasualMatch> GetAll();
        CasualMatch? GetByJoinCode(string code);
        CasualMatch Create(CasualMatchCreateRequest request, Player player);
        void Delete(int id);
        void Join(string username, string code);
        void Leave(Player player, string username, string code);
    }
}

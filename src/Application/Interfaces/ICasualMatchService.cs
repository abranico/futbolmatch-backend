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
        CasualMatchDto Create(CasualMatchCreateRequest request, int userId);
        void Delete(int id, int userId);
        void Update(int id, int userId, CasualMatchUpdateRequest request);
        void Join(int userId, string code);
        void Leave(int userId, string username, string code);
    }
}

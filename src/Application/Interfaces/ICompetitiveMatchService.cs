using Application.Models.Requests;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICompetitiveMatchService
    {
        List<CompetitiveMatchDto> GetAll();
        CompetitiveMatchDto GetById(int id);
        CompetitiveMatchDto Create(CompetitiveMatchCreateRequest request);
        void UpdateMatchResult(int matchId, string result, int userId);
        void DeleteMatch(int matchId, int userId);
    }
}

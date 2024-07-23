using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CompetitiveMatchRepository : RepositoryBase<CompetitiveMatch>, ICompetitiveMatchRepository
    {
        private readonly ApplicationContext _context;

        public CompetitiveMatchRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }


        public override List<CompetitiveMatch> GetAll()
        {
            return _context.CompetitiveMatches
                    .Include(m => m.AwayTeam)
                    .Include(m => m.HomeTeam)
                    .Include(m => m.League)
                    .ToList();
        }

        public override CompetitiveMatch? GetById<TId>(TId id)
        {
            if (id is int intId)
            {
                return _context.CompetitiveMatches
                            .Include(m => m.AwayTeam)
                            .Include(m => m.HomeTeam)
                            .Include(m => m.League)
                            .FirstOrDefault(m => m.Id == intId);
            }
            throw new ArgumentException("Tipo de ID no compatible.");
        }

    }
}

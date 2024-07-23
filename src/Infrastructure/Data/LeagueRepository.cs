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
    public class LeagueRepository : RepositoryBase<League>, ILeagueRepository
    {
        private readonly ApplicationContext _context;

        public LeagueRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public override List<League> GetAll()
        {
            return _context.Leagues
                    .Include(m => m.Admin)
                    .Include(m => m.Teams)
                    .Include(m => m.Matchs)
                    .ToList();
        }

        public override League? GetById<TId>(TId id)
        {
            if (id is int intId)
            {
                return _context.Leagues
                        .Include(m => m.Admin)
                        .Include(m => m.Teams)
                        .Include(m => m.Matchs)
                        .FirstOrDefault(m => m.Id == intId);
            }
            throw new ArgumentException("Tipo de ID no compatible.");
        }

        public League? GetByJoinCode(string code)
        {
            return _context.Leagues
                    .Include(m => m.Admin) 
                    .Include(m => m.Teams)
                    .Include(m => m.Matchs)
                    .FirstOrDefault(m => m.JoinCode == code);
        }

    }
}

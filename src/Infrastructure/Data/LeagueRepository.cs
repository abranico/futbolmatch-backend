using Domain.Entities;
using Domain.Interfaces;
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

        public League? GetByJoinCode(string code)
        {
            return _context.Leagues.SingleOrDefault(u => u.JoinCode == code);
        }
    }
}

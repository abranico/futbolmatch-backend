using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        private readonly ApplicationContext _context;
        
        public TeamRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Team? GetByJoinCode(string code)
        {
            return _context.Teams.SingleOrDefault(u => u.JoinCode == code);
        }
    }
}

using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        private readonly ApplicationContext _context;
        public PlayerRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Player? GetByEmail(string email)
        {
            return _context.Players.SingleOrDefault(u => u.Email == email);
        }
    }
}

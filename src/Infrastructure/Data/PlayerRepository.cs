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
        public Player? GetByUsername(string username)
        {
            return _context.Players.SingleOrDefault(u => u.Username == username);
        }
        public override List<Player> GetAll()
        {
            return _context.Players.Include(t => t.Teams).ToList();
        }

        public override Player? GetById<TId>(TId id)
        {
            if (id is int intId)
            {
                return _context.Players
                    .Include(p => p.Teams) // Incluye los equipos.
                        .ThenInclude(t => t.Captain) // Incluye el capitán de cada equipo.
                    .Include(p => p.Teams) // Incluye los equipos nuevamente.
                        .ThenInclude(t => t.Players) // Incluye los jugadores de cada equipo.
                    .FirstOrDefault(p => p.Id == intId); // Filtra por ID.
            }
            throw new ArgumentException("Tipo de ID no compatible.");
        }
    }
}

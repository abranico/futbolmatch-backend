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
    public class CasualMatchRepository : RepositoryBase<CasualMatch>, ICasualMatchRepository
    {
        private readonly ApplicationContext _context;

        public CasualMatchRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }


        public override List<CasualMatch> GetAll()
        {
            return _context.CasualMatches
                    .Include(m => m.Admin) 
                    .Include(m => m.Players) 
                    .ToList();
        }

        public override CasualMatch? GetById<TId>(TId id)
        {
            if (id is int intId)
            {
                return _context.CasualMatches
                               .Include(m => m.Admin) 
                               .Include(m => m.Players) 
                               .FirstOrDefault(m => m.Id == intId);
            }
            throw new ArgumentException("Tipo de ID no compatible.");
        }

        public CasualMatch? GetByJoinCode(string code)
        {
            return _context.CasualMatches
                           .Include(m => m.Admin) // Incluir el Admin en la consulta
                           .Include(m => m.Players) // Incluir los jugadores en la consulta
                           .FirstOrDefault(m => m.JoinCode == code);
        }
    }
}

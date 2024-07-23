using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            return _context.Teams
                .Include(m => m.Captain)
                .Include(m => m.Players)
                .Include(m => m.League)
                .FirstOrDefault(m => m.JoinCode == code);
        }

        public override List<Team> GetAll()
        {
            return _context.Teams
                    .Include(m => m.Captain)
                    .Include(t => t.Players)
                    .Include(m => m.League)
                    .ToList(); 
        }


        public override Team? GetById<TId>(TId id)
        {
            if (id is int intId)
            {
                return _context.Teams
                        .Include(m => m.Captain)
                        .Include(m => m.Players)
                        .Include(m => m.League)
                        .FirstOrDefault(m => m.Id == intId);
            }
            throw new ArgumentException("Tipo de ID no compatible.");
        }

        public override Team Create(Team entity)
        {
            var existingTeam = _context.Set<Team>()
           .AsNoTracking()
           .FirstOrDefault(t => t.Id == entity.Id);

            if (existingTeam != null)
            {
                // Si existe, usar Attach para evitar el problema de duplicación
                _context.Set<Team>().Attach(entity);
            }
            else
            {
                // Si no existe, añadir la nueva entidad
                _context.Set<Team>().Add(entity);
            }

            _context.SaveChanges();
            return entity;
        }

    }
}

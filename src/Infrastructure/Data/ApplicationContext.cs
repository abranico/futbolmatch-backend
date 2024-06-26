using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<CasualMatch> CasualMatches { get; set; }
        public DbSet<CompetitiveMatch> CompetitiveMatches { get; set; }
        public DbSet<League> Leagues { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Team>()
            .HasMany(x => x.Players)
            .WithMany(x => x.Teams)
            .UsingEntity(j => j
                .ToTable("PlayersTeams")
                );

            modelBuilder.Entity<Team>()
           .HasOne(t => t.Captain)
           .WithMany()
           .HasForeignKey(t => t.CaptainId);

        }
    }
}

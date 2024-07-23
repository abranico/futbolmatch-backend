using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
                .HasOne(cm => cm.Captain);

            modelBuilder.Entity<CompetitiveMatch>()
        .HasOne(cm => cm.League)
        .WithMany(l => l.Matchs)
        .HasForeignKey("LeagueId");

            modelBuilder.Entity<League>()
                .HasMany(l => l.Matchs)
                .WithOne(cm => cm.League)
                .HasForeignKey("LeagueId"); 

            modelBuilder.Entity<Team>()
                .HasMany(cm => cm.Players)
                .WithMany(cm => cm.Teams)
                .UsingEntity(j => j.ToTable("TeamPlayers"));

            modelBuilder.Entity<CasualMatch>()
                .HasMany(cm => cm.Players)
                .WithMany()
                .UsingEntity(j => j.ToTable("CasualMatchPlayers"));

           
        }
    }
}

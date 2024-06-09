using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Player Admin { get; set; }
        public Visibility Visibility { get; set; }
        public MatchFormat MatchFormat { get; set; }
        public ICollection<CompetitiveMatch> MatchHistory { get; set; } = new List<CompetitiveMatch>();
        public ICollection<Team> Teams { get; set; } = new List<Team>();
        public ICollection<Player> Players { get; set; } = new List<Player>();
        public ICollection<Team> InvitedTeams { get; set; } = new List<Team>();
        public ICollection<Team> LeagueJoinRequests { get; set; } = new List<Team>();
        public LeagueStatus LeagueStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Tuple<Team, Team>>? Fixture { get; set; }
        public Team Winner { get; set; }

    }
}

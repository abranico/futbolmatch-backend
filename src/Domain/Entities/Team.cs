using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Team
    {
        public string Name { get; set; }
        public Player Captain { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string? Logo { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
        public ICollection<CompetitiveMatch> MatchHistory { get; set; } = new List<CompetitiveMatch>();
        public int AllPoints { get; set; } = 0;
        public League? League { get; set; }
        public int? LeaguePoints { get; set; }
    }
}

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
        public LeagueStatus LeagueStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
 

    }
}

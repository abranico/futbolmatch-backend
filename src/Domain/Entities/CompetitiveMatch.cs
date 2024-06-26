using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CompetitiveMatch: Match
    {
        public League League { get; set; }
        public string Result { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
    }
}

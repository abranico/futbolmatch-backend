using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Player : User
    {
        
        public string? Description { get; set; }
        public PreferredFoot? PreferredFoot {  get; set; }
        public Position Position { get; set; }
        public Role Role { get; set; } = Role.Player;
        public Team? Team { get; set; }
        public ICollection<Match> MatchHistory { get; set; } = new List<Match>();

    }
}

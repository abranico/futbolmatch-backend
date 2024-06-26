using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CaptainId { get; set; }
        public Player Captain { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
        public int Points { get; set; } = 0;
        public string Country { get; set; }
        public string City { get; set; }
        public League? League { get; set; }
        public string? Logo { get; set; }
    }
}

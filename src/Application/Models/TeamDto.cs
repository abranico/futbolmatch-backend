using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CaptainId { get; set; }
        public string JoinCode { get; set; }
        public ICollection<string> Players { get; set; }
        public int Points { get; set; } = 0;
        public string Country { get; set; }
        public string City { get; set; }
        public int? LeagueId { get; set; }
        public string? Logo { get; set; }
    }
}

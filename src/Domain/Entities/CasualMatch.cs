using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CasualMatch : Match
    {
        public Player Admin {  get; set; }
        public string JoinCode {  get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public bool Open { get; set; } = true;
    }
}





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class LeagueJoinRequest
    {
        public string Code { get; set; }
        public int TeamId { get; set; }
    }
}

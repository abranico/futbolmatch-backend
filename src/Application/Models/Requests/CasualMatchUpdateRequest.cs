using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class CasualMatchUpdateRequest
    {
        public string Name { get; set; }
        public DateTime Schedule { get; set; }
        public MatchFormat MatchFormat { get; set; }
    }
}

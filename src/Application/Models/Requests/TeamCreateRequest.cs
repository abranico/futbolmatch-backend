using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class TeamCreateRequest
    {
        public string Name { get; set; }
        public string? Logo { get; set; }
    }
}

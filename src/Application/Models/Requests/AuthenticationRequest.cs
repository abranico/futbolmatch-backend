using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class AuthenticationRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

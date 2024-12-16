using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class PlayerCreateRequest
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }    
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public string PhoneNumber { get; set; }

        

    }

}


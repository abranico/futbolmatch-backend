using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Picture { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool IsPremium { get; set; } = false;
        public string Role { get; set; }
        public string Description { get; set; }
        public string PreferredFoot { get; set; }
        public string Position { get; set; }
        public ICollection<string> Teams { get; set; }
        public bool isCaptain { get; set; }

        public static PlayerDto FromEntity(Player player)
        {
            return new PlayerDto
            {
                Id = player.Id,
                Email = player.Email,
                Username = player.Username,
                Firstname = player.Firstname,
                Lastname = player.Lastname,
                Picture = player.Picture ?? "",           
                Country = player.Country,
                City = player.City,
                PhoneNumber = player.PhoneNumber ?? "",
                DateOfBirth = player.DateOfBirth.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("es-ES")),
                Gender = player.Gender.ToString(),
                IsPremium = player.IsPremium,    
                Role = player.Role.ToString(),
                Description = player.Description ?? "",
                PreferredFoot = player.PreferredFoot.ToString() ?? "",
                Position = player.Position.ToString() ?? "",
                Teams = player.Teams.Select(p => p.Name).ToList(),
                isCaptain = player.isCaptain,

                Password = player.Password,
            };
        }
    }
}

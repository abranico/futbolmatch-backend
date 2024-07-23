using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class LeagueDto
    {
        public int Id { get; set; }
        public string JoinCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Admin { get; set; }
        public string MatchFormat { get; set; }

        public static LeagueDto FromEntity(League league)
        {
            return new LeagueDto
            {
                Id = league.Id,
                JoinCode = league.JoinCode,
                Name = league.Name,
                Description = league.Description ?? "",
                Logo = league.Logo ?? "",
                Country = league.Country,
                City = league.City,
                Admin = league.Admin.Username,
                MatchFormat = league.MatchFormat.ToString()
            };
        }
    }
}

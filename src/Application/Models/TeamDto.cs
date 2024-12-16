﻿using Domain.Entities;
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
        public string Captain { get; set; }
        public string JoinCode { get; set; }
        public ICollection<string> Players { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string League { get; set; }
        public string? Logo { get; set; }

        public static TeamDto FromEntity(Team team)
        {
            return new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                Captain = team.Captain?.Username,
                JoinCode = team.JoinCode,
                Players = team.Players?.Select(p => p.Username).ToList(),
                Country = team.Country,
                City = team.City,
                League = team.League?.Name ?? "",
                Logo = team.Logo
            };
        }
    }
}

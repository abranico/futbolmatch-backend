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
    public class CompetitiveMatchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Schedule { get; set; }
        public string MatchFormat { get; set; }
        public string MatchMode { get; set; }
        public string League { get; set; }
        public string Result { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public static CompetitiveMatchDto FromEntity(CompetitiveMatch match)
        {
            return new CompetitiveMatchDto
            {
                Id = match.Id,
                Name = match.Name,
                Country = match.Country,
                City = match.City,
                Schedule = match.Schedule.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("es-ES")),
                MatchFormat = match.MatchFormat.ToString(),
                MatchMode = match.MatchMode.ToString(),
                League = match.League.Name,
                Result = match.Result,
                HomeTeam = match.HomeTeam.Name,
                AwayTeam = match.AwayTeam.Name

            };
        }
    }
}

using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Match
    {
        public int Id { get; set; }
        public string Country {  get; set; }
        public string City {  get; set; }
        public DateTime Schedule { get; set; }
        public MatchFormat MatchFormat { get; set; }
        public MatchMode MatchMode { get; set; }
    }
}

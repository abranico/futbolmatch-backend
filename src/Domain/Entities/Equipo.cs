using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Equipo
    {
        public string Nombre { get; set; }
        public string Capitan { get; set; }
        public string Jugadores { get; set; }
        public int Partidos { get; set; }
        public int Puntos { get; set; }
        public string Ciudad { get; set; }
        public string Liga { get; set; }
    }
}

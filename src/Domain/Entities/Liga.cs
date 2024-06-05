using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Liga
    {

        public string Nombre { get; set; }
        public string Admin { get; set; }
        public int Partidos { get; set; }
        public string Equipos { get; set; }
        public string Tabla { get; set; }
        public string Tipo { get; set; }
        public string Ciudad { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Partido
    {
        public string Direccion {  get; set; }
        public string Tipo { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set; }
        public string Equipos { get; set; }
        public string Modo { get; set; }
    }
}

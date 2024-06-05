using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Imagen { get; set; }
        public string Contraseña { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public bool Premium { get; set; }







    }
}

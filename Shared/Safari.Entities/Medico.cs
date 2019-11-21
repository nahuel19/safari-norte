using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Medico : EntityBase
    {
        public override int Id { get; set; }
        public string TipoMatricula  { get; set; }
        public int NumeroMatricula  { get; set; }
        public string Apellido { get; set; }
        public string Nombre  { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaNacimiento  { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public string[] TiposMatriculas = new string[] { "MP", "MN" };
    }
}

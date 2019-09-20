using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Cliente : IEntity
    {
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Url { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}

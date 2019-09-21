using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Paciente : IEntity
    {
        public int Id { get; set; }

        
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string  Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }

        
        public int EspecieId { get; set; }
        public Especie Especie { get; set; }

        public string Observacion { get; set; }
    }
}

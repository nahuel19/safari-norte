using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Sala : EntityBase
    {
        public override int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoSala { get; set; }

        public string[] TiposSalas = new string[] { "Recuperación", "Quirófano", "Vacunatorio"};
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Precio : IEntity
    {
        [Key]
        [ForeignKey("TipoServicio")]
        public int Id { get; set; }
        public TipoServicio TipoServicio { get; set; }

        [Key]
        public DateTime FechaDesde { get; set; }
        
        [Key]
        public DateTime FechaHasta { get; set; }

        public int Valor { get; set; }
    }
}

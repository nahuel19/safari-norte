using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Movimiento : IEntity
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("TipoMovimiento")]
        public int TipoMovimientoId { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }

        public int Valor { get; set; }
    }
}

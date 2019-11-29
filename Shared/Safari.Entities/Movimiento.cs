using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    [Serializable]
    [DataContract]
    public class Movimiento : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        public override int Id { get; set; }

        [DataMember]
        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }

        [DataMember]
        [DisplayName("ClienteId")]
        public int ClienteId { get; set; }

        [DataMember]
        [DisplayName("TipoMovimientoId")]
        public int TipoMovimientoId { get; set; }

        [DataMember]
        [DisplayName("Valor")]
        public double Valor { get; set; }
    }
}

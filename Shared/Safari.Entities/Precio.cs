using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    [Serializable]
    [DataContract]
    public class Precio : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        public override int Id { get; set; }

        [DataMember]
        [DisplayName("TipoServicioId")]
        public int TipoServicioId { get; set; }

        [DisplayName("TipoServicio")]
        public TipoServicio TipoServicio { get; set; }

        [DataMember]
        [DisplayName("FechaDesde")]
        public DateTime FechaDesde { get; set; }

        [DataMember]
        [DisplayName("FechaHasta")]
        public DateTime FechaHasta { get; set; }

        [DataMember]
        [DisplayName("Valor")]
        public double Valor { get; set; }
    }
}

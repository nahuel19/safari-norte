using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    [Serializable]
    [DataContract]
    public class TipoMovimiento : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        public override int Id { get; set; }

        [DataMember]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DataMember]
        [DisplayName("Multiplicador")]
        public int Multiplicador { get; set; }

        
    }
}

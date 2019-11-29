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
    public class Paciente : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        public override int Id { get; set; }

        [DataMember]
        [DisplayName("ClienteId")]
        public int ClienteId { get; set; }

        [DisplayName("Cliente")]
        public Cliente Cliente { get; set; }

        [DataMember]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DataMember]
        [DisplayName("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        [DisplayName("EspecieId")]
        public int EspecieId { get; set; }

        [DisplayName("Especie")]
        public Especie Especie { get; set; }

        [DataMember]
        [DisplayName("Observacion")]
        public string Observacion { get; set; }
    }
}

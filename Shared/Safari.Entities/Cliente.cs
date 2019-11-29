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
    public class Cliente : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        public override int Id { get; set; }

        [DataMember]
        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [DataMember]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DataMember]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DataMember]
        [DisplayName("Telefono")]
        public string Telefono { get; set; }

        [DataMember]
        [DisplayName("Url")]
        public string Url { get; set; }

        [DataMember]
        [DisplayName("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        [DisplayName("Domicilio")]
        public string Domicilio { get; set; }


        public ICollection<Paciente> Pacientes { get; set; }
    }
}

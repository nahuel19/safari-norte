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
    public class Medico : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        public override int Id { get; set; }

        [DataMember]
        [DisplayName("TipoMatricula")]
        public string TipoMatricula  { get; set; }

        [DataMember]
        [DisplayName("NumeroMatricula")]
        public int NumeroMatricula  { get; set; }

        [DataMember]
        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [DataMember]
        [DisplayName("Nombre")]
        public string Nombre  { get; set; }

        [DataMember]
        [DisplayName("Especialidad")]
        public string Especialidad { get; set; }

        [DataMember]
        [DisplayName("FechaNacimiento")]
        public DateTime FechaNacimiento  { get; set; }

        [DataMember]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DataMember]
        [DisplayName("Telefono")]
        public string Telefono { get; set; }
        

        public string[] TiposMatriculas = new string[] { "MP", "MN" };
    }
}

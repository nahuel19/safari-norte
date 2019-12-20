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
    public class Cita: EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        public override int Id { get; set; }

        [DataMember]
        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }

        [DataMember]
        [DisplayName("MedicoId")]
        public int MedicoId { get; set; }

        [DisplayName("Medico")]
        public Medico Medico { get; set; }

        [DataMember]
        [DisplayName("PacienteId")]
        public int PacienteId { get; set; }

        [DisplayName("Paciente")]
        public Paciente Paciente { get; set; }

        [DataMember]
        [DisplayName("SalaId")]
        public int SalaId { get; set; }

        [DisplayName("Sala")]
        public Sala Sala { get; set; }

        [DataMember]
        [DisplayName("TipoServicioId")]
        public int TipoServicioId { get; set; }

        [DisplayName("TipoServicio")]
        public TipoServicio TipoServicio { get; set; }

        [DataMember]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [DataMember]
        [DisplayName("CreatedBy")]
        public string CreatedBy { get; set; }

        [DataMember]
        [DisplayName("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        [DisplayName("ChangedBy")]
        public string ChangedBy { get; set; }

        [DataMember]
        [DisplayName("ChangedDate")]
        public DateTime? ChangedDate { get; set; }

        [DataMember]
        [DisplayName("DeletedBy")]
        public string DeletedBy { get; set; }

        [DataMember]
        [DisplayName("DeletedDate")]
        public DateTime? DeletedDate { get; set; }

        [DataMember]
        [DisplayName("Deleted")]
        public bool Deleted { get; set; }

        public string[] TipoEstado = new string[] { "Cancelado", "Realizado", "Confirmado", "Reservado" };
    }
}

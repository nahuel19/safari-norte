using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class CitaComponent : IComponent<Cita>
    {
        public Cita Add(Cita cita)
        {
            Cita result = default(Cita);
            var citaDAC = new CitaDAC();

            result = citaDAC.Create(cita);
            return result;
        }

        public void Edit(Cita cita)
        {
            var citaDAC = new CitaDAC();
            citaDAC.Update(cita);

        }

        public Cita Find(int? id)
        {
            Cita result = default(Cita);
            var citaDAC = new CitaDAC();
            result = citaDAC.ReadBy(id.Value);

            return result;
        }

        public List<Cita> ToList()
        {
            List<Cita> result = default(List<Cita>);

            var citaDAC = new CitaDAC();
            result = citaDAC.Read();


      
            return result;

        }

        public void Remove(Cita cita)
        {
            var citaDAC = new CitaDAC();
            citaDAC.Delete(cita.Id);
        }

    }
}

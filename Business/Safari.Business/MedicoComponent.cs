using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class MedicoComponent : IComponent<Medico>
    {
        public Medico Add(Medico medico)
        {
            Medico result = default(Medico);
            var medicoDAC = new MedicoDAC();

            result = medicoDAC.Create(medico);
            return result;
        }

        public void Edit(Medico medico)
        {
            var medicoDAC = new MedicoDAC();
            medicoDAC.Update(medico);

        }

        public Medico Find(int? id)
        {
            Medico result = default(Medico);
            var medicoDAC = new MedicoDAC();
            result = medicoDAC.ReadBy(id.Value);
            return result;
        }

        public List<Medico> ToList()
        {
            List<Medico> result = default(List<Medico>);

            var medicoDAC = new MedicoDAC();
            result = medicoDAC.Read();
            return result;

        }

        public void Remove(Medico medico)
        {
            var medicoDAC = new MedicoDAC();
            medicoDAC.Delete(medico.Id);
        }

    }
}

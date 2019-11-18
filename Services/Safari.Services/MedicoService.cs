using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]

    public class MedicoService : IService<Medico>
    {
        public Medico Add(Medico medico)
        {
            var bc = new MedicoComponent();
            return bc.Add(medico);
        }

        public void Edit(Medico medico)
        {
            var bc = new MedicoComponent();
            bc.Edit(medico);
        }

        public Medico Find(int? id)
        {
            var bc = new MedicoComponent();
            return bc.Find(id);
        }


        public void Remove(Medico medico)
        {
            var bc = new MedicoComponent();
            bc.Remove(medico);
        }

        public List<Medico> ToList()
        {
            var bc = new MedicoComponent();
            return bc.ToList();
        }
    }
}

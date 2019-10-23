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

    public class SalaService : IService<Sala>
    {
        public Sala Add(Sala sala)
        {
            var bc = new SalaComponent();
            return bc.Add(sala);
        }

        public void Edit(Sala sala)
        {
            var bc = new SalaComponent();
            bc.Edit(sala);
        }

        public Sala Find(int? id)
        {
            var bc = new SalaComponent();
            return bc.Find(id);
        }


        public void Remove(Sala sala)
        {
            var bc = new SalaComponent();
            bc.Remove(sala);
        }

        public List<Sala> ToList()
        {
            var bc = new SalaComponent();
            return bc.ToList();
        }
    }
}

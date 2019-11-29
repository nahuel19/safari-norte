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

    public class PrecioService : IService<Precio>
    {
        public Precio Add(Precio precio)
        {
            var bc = new PrecioComponent();
            return bc.Add(precio);
        }

        public void Edit(Precio precio)
        {
            var bc = new PrecioComponent();
            bc.Edit(precio);
        }

        public Precio Find(int? id)
        {
            var bc = new PrecioComponent();
            return bc.Find(id);
        }


        public void Remove(Precio precio)
        {
            var bc = new PrecioComponent();
            bc.Remove(precio);
        }

        public List<Precio> ToList()
        {
            var bc = new PrecioComponent();
            return bc.ToList();
        }
    }
}

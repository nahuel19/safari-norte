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

    public class TipoServicioService : IService<TipoServicio>
    {
        public TipoServicio Add(TipoServicio tipoServicioComponent)
        {
            var bc = new TipoServicioComponent();
            return bc.Add(tipoServicioComponent);
        }

        public void Edit(TipoServicio tipoServicioComponent)
        {
            var bc = new TipoServicioComponent();
            bc.Edit(tipoServicioComponent);
        }

        public TipoServicio Find(int? id)
        {
            var bc = new TipoServicioComponent();
            return bc.Find(id);
        }


        public void Remove(TipoServicio tipoServicioComponent)
        {
            var bc = new TipoServicioComponent();
            bc.Remove(tipoServicioComponent);
        }

        public List<TipoServicio> ToList()
        {
            var bc = new TipoServicioComponent();
            return bc.ToList();
        }
    }
}

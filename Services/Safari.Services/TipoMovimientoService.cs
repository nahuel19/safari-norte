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

    public class TipoMovimientoService : IService<TipoMovimiento>
    {
        public TipoMovimiento Add(TipoMovimiento tipoMovimientoComponent)
        {
            var bc = new TipoMovimientoComponent();
            return bc.Add(tipoMovimientoComponent);
        }

        public void Edit(TipoMovimiento tipoMovimientoComponent)
        {
            var bc = new TipoMovimientoComponent();
            bc.Edit(tipoMovimientoComponent);
        }

        public TipoMovimiento Find(int? id)
        {
            var bc = new TipoMovimientoComponent();
            return bc.Find(id);
        }


        public void Remove(TipoMovimiento tipoMovimientoComponent)
        {
            var bc = new TipoMovimientoComponent();
            bc.Remove(tipoMovimientoComponent);
        }

        public List<TipoMovimiento> ToList()
        {
            var bc = new TipoMovimientoComponent();
            return bc.ToList();
        }
    }
}

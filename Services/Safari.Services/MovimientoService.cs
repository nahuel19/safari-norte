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

    public class MovimientoService : IService<Movimiento>
    {
        public Movimiento Add(Movimiento movimiento)
        {
            var bc = new MovimientoComponent();
            return bc.Add(movimiento);
        }

        public void Edit(Movimiento movimiento)
        {
            var bc = new MovimientoComponent();
            bc.Edit(movimiento);
        }

        public Movimiento Find(int? id)
        {
            var bc = new MovimientoComponent();
            return bc.Find(id);
        }


        public void Remove(Movimiento movimiento)
        {
            var bc = new MovimientoComponent();
            bc.Remove(movimiento);
        }

        public List<Movimiento> ToList()
        {
            var bc = new MovimientoComponent();
            return bc.ToList();
        }
    }
}

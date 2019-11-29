using Safari.Entities;
using Safari.Framework.Common;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public partial class MovimientoProcess : ProcessComponent, IProcess<Movimiento>
    {
        private IService<Movimiento> _iService;

        public MovimientoProcess(IService<Movimiento> iService)
        {
            _iService = iService;
        }
        public List<Movimiento> ToList()
        {
            List<Movimiento> result = default(List<Movimiento>);
            var proxy = _iService;
            try
            {
                result = proxy.ToList();
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }

        public Movimiento Find(int? id)
        {
            Movimiento result = default(Movimiento);
            var proxy = _iService;
            try
            {
                result = proxy.Find(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }

        public Movimiento Add(Movimiento movimiento)
        {
            Movimiento result = default(Movimiento);
            var proxy = ServiceFactory.Get<IService<Movimiento>>();

            try
            {
                result = proxy.Add(movimiento);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Movimiento Edit(Movimiento movimiento)
        {
            Movimiento result = default(Movimiento);
            var proxy = _iService;

            try
            {
                proxy.Edit(movimiento);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Movimiento Remove(Movimiento movimiento)
        {
            Movimiento result = default(Movimiento);
            var proxy = _iService;

            try
            {
                proxy.Remove(movimiento);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

    }
}

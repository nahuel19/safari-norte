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
    public partial class TipoMovimientoProcess : ProcessComponent, IProcess<TipoMovimiento>
    {
        private IService<TipoMovimiento> _iService;

        public TipoMovimientoProcess(IService<TipoMovimiento> iService)
        {
            _iService = iService;
        }

        public List<TipoMovimiento> ToList()
        {
            List<TipoMovimiento> result = default(List<TipoMovimiento>);
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

        public TipoMovimiento Find(int? id)
        {
            TipoMovimiento result = default(TipoMovimiento);
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

        public TipoMovimiento Add(TipoMovimiento tipoMovimiento)
        {
            TipoMovimiento result = default(TipoMovimiento);
            var proxy = ServiceFactory.Get<IService<TipoMovimiento>>();

            try
            {
                result = proxy.Add(tipoMovimiento);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public TipoMovimiento Edit(TipoMovimiento tipoMovimiento)
        {
            TipoMovimiento result = default(TipoMovimiento);
            var proxy = _iService;

            try
            {
                proxy.Edit(tipoMovimiento);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public TipoMovimiento Remove(TipoMovimiento tipoMovimiento)
        {
            TipoMovimiento result = default(TipoMovimiento);
            var proxy = _iService;

            try
            {
                proxy.Remove(tipoMovimiento);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

    }
}

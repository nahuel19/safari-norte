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
    public partial class PrecioProcess : ProcessComponent, IProcess<Precio>
    {
        private IService<Precio> _iService;

        public PrecioProcess(IService<Precio> iService)
        {
            _iService = iService;
        }
        public List<Precio> ToList()
        {
            List<Precio> result = default(List<Precio>);
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

        public Precio Find(int? id)
        {
            Precio result = default(Precio);
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

        public Precio Add(Precio precio)
        {
            Precio result = default(Precio);
            var proxy = ServiceFactory.Get<IService<Precio>>();

            try
            {
                result = proxy.Add(precio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Precio Edit(Precio precio)
        {
            Precio result = default(Precio);
            var proxy = _iService;

            try
            {
                proxy.Edit(precio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Precio Remove(Precio precio)
        {
            Precio result = default(Precio);
            var proxy = _iService;

            try
            {
                proxy.Remove(precio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

    }
}

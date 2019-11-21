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
   

    public partial class TipoServicioProcess : ProcessComponent, IProcess<TipoServicio>
    {
        private IService<TipoServicio> _iService;

        public TipoServicioProcess(IService<TipoServicio> iService)
        {
            _iService = iService;
        }


        public List<TipoServicio> ToList()
        {
            List<TipoServicio> result = default(List<TipoServicio>);
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

        public TipoServicio Find(int? id)
        {
            TipoServicio result = default(TipoServicio);
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

        public TipoServicio Add(TipoServicio tipoServicio)
        {
            TipoServicio result = default(TipoServicio);
            var proxy = ServiceFactory.Get<IService<TipoServicio>>();

            try
            {
                result = proxy.Add(tipoServicio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public TipoServicio Edit(TipoServicio tipoServicio)
        {
            TipoServicio result = default(TipoServicio);
            var proxy = _iService;

            try
            {
                proxy.Edit(tipoServicio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public TipoServicio Remove(TipoServicio tipoServicio)
        {
            TipoServicio result = default(TipoServicio);
            var proxy = _iService;

            try
            {
                proxy.Remove(tipoServicio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

    }
}

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
    public partial class SalaProcess: ProcessComponent, IProcess<Sala>
    {
        private IService<Sala> _iService;

        public SalaProcess(IService<Sala> iService)
        {
            _iService = iService;
        }
        public List<Sala> ToList()
        {
            List<Sala> result = default(List<Sala>);
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

        public Sala Find(int? id)
        {
            Sala result = default(Sala);
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

        public Sala Add(Sala sala)
        {
            Sala result = default(Sala);
            var proxy = ServiceFactory.Get<IService<Sala>>();

            try
            {
                result = proxy.Add(sala);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Sala Edit(Sala sala)
        {
            Sala result = default(Sala);
            var proxy = _iService;

            try
            {
                proxy.Edit(sala);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Sala Remove(Sala sala)
        {
            Sala result = default(Sala);
            var proxy = _iService;

            try
            {
                proxy.Remove(sala);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }
    }
}

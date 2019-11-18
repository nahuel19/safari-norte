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
    public partial class ClienteProcess : ProcessComponent, IProcess<Cliente>
    {
        private IService<Cliente> _iService;

        public ClienteProcess(IService<Cliente> iService)
        {
            _iService = iService;
        }
        public List<Cliente> ToList()
        {
            List<Cliente> result = default(List<Cliente>);
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

        public Cliente Find(int? id)
        {
            Cliente result = default(Cliente);
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

        public Cliente Add(Cliente cliente)
        {
            Cliente result = default(Cliente);
            var proxy = ServiceFactory.Get<IService<Cliente>>();

            try
            {
                result = proxy.Add(cliente);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Cliente Edit(Cliente cliente)
        {
            Cliente result = default(Cliente);
            var proxy = _iService;

            try
            {
                proxy.Edit(cliente);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Cliente Remove(Cliente cliente)
        {
            Cliente result = default(Cliente);
            var proxy = _iService;

            try
            {
                proxy.Remove(cliente);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

    }
}

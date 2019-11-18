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
    public partial class MedicoProcess : ProcessComponent, IProcess<Medico>
    {
        private IService<Medico> _iService;

        public MedicoProcess(IService<Medico> iService)
        {
            _iService = iService;
        }


        public List<Medico> ToList()
        {
            List<Medico> result = default(List<Medico>);
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

        public Medico Find(int? id)
        {
            Medico result = default(Medico);
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

        public Medico Add(Medico medico)
        {
            Medico result = default(Medico);
            var proxy = ServiceFactory.Get<IService<Medico>>();

            try
            {
                result = proxy.Add(medico);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Medico Edit(Medico medico)
        {
            Medico result = default(Medico);
            var proxy = _iService;

            try
            {
                proxy.Edit(medico);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Medico Remove(Medico medico)
        {
            Medico result = default(Medico);
            var proxy = _iService;

            try
            {
                proxy.Remove(medico);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

    }
}

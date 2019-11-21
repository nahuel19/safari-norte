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
    public partial class PacienteProcess : ProcessComponent, IProcess<Paciente>
    {
        private IService<Paciente> _iService;

        public PacienteProcess(IService<Paciente> iService)
        {
            _iService = iService;
        }


        public List<Paciente> ToList()
        {
            List<Paciente> result = default(List<Paciente>);
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

        public Paciente Find(int? id)
        {
            Paciente result = default(Paciente);
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

        public Paciente Add(Paciente paciente)
        {
            Paciente result = default(Paciente);
            var proxy = ServiceFactory.Get<IService<Paciente>>();

            try
            {
                result = proxy.Add(paciente);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Paciente Edit(Paciente paciente)
        {
            Paciente result = default(Paciente);
            var proxy = _iService;

            try
            {
                proxy.Edit(paciente);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Paciente Remove(Paciente paciente)
        {
            Paciente result = default(Paciente);
            var proxy = _iService;

            try
            {
                proxy.Remove(paciente);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

    }
}

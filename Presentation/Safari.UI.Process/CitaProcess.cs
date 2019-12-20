using Safari.Entities;
using Safari.Framework.Common;
using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public partial class CitaProcess : ProcessComponent, IProcess<Cita>
    {
        private IService<Cita> _iService;

        public CitaProcess(IService<Cita> iService)
        {
            _iService = iService;
        }
        public List<Cita> ToList()
        {
            List<Cita> result = default(List<Cita>);
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

        public Cita Find(int? id)
        {
            Cita result = default(Cita);
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

        public Cita Add(Cita cita)
        {
            Cita result = default(Cita);
            var proxy = ServiceFactory.Get<IService<Cita>>();

            try
            {
                result = proxy.Add(cita);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Cita Edit(Cita cita)
        {
            Cita result = default(Cita);
            var proxy = _iService;

            try
            {
                proxy.Edit(cita);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Cita Facturar(Cita cita, int val)
        {
            Cita result = default(Cita);
            var proxy = new CitaService(); ;

            try
            {
                proxy.Facturar(cita, val);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }


        public Cita Remove(Cita cita)
        {
            Cita result = default(Cita);
            var proxy = _iService;

            try
            {
                proxy.Remove(cita);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

    }
}

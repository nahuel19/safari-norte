using Safari.Entities;
using Safari.Framework.Common;
using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace Safari.UI.Process
{    
    public partial class EspecieProcess : ProcessComponent, IProcess<Especie>
    {
        private IService<Especie> _iService;

        public EspecieProcess(IService<Especie> iService)
        {
            _iService = iService;
        }
        public List<Especie> ToList()
        {
            List<Especie> result = default(List<Especie>);
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

        public Especie Find(int? id)
        {
            Especie result = default(Especie);
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

        public Especie Add(Especie especie)
        {
            Especie result = default(Especie);
            var proxy = ServiceFactory.Get<IService<Especie>>();

            try
            {
                result = proxy.Add(especie);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Especie Edit(Especie especie)
        {
            Especie result = default(Especie);
            var proxy = _iService;

            try
            {
                proxy.Edit(especie);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Especie Remove(Especie especie)
        {
            Especie result = default(Especie);
            var proxy = _iService;

            try
            {
                proxy.Remove(especie);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

    }
}

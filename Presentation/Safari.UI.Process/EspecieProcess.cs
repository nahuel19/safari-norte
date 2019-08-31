using Safari.Entities;
using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace Safari.UI.Process
{    
    public partial class EspecieProcess : ProcessComponent
    {       
        public List<Especie> ListarTodos()
        {
            List<Especie> result = default(List<Especie>);
            IEspecieService proxy = new EspecieService();
            
            try
            {
                result = proxy.ListarTodos();
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }            
            return result;
        }
        
        public Especie Agregar(Especie especie)
        {
            Especie result = default(Especie);
            IEspecieService proxy = new EspecieService();

            try
            {
                result = proxy.Agregar(especie);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            
            return result;
        }
    }
}

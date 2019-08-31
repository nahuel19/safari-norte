using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;

namespace Safari.Services
{    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class EspecieService : IEspecieService
    {
        public Especie Agregar(Especie especie)
        {
            var bc = new EspecieComponent();
            return bc.Agregar(especie);
        }

        public List<Especie> ListarTodos()
        {
            var bc = new EspecieComponent();
            return bc.ListarTodos();
        }
    }
}

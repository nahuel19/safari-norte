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

    public class EspecieService : IService<Especie>
    {
        public Especie Add(Especie especie)
        {
            var bc = new EspecieComponent();
            return bc.Add(especie);
        }

        public void Edit(Especie especie)
        {
            var bc = new EspecieComponent();
            bc.Edit(especie);
        }

        public Especie Find(int? id)
        {
            var bc = new EspecieComponent();
            return bc.Find(id);
        }


        public void Remove(Especie especie)
        {
            var bc = new EspecieComponent();
            bc.Remove(especie);
        }

        public List<Especie> ToList()
        {
            var bc = new EspecieComponent();
            return bc.ToList();
        }
    }
}

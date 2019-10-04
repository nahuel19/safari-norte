using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Safari.Entities;
using Safari.Data;
using Safari.Services.Contracts;

namespace Safari.Business
{
   
    public partial class EspecieComponent : IEspecieService /*IService<Especie>*/
    {
        public Especie Add(Especie especie)
        {
            Especie result = default(Especie);
            var especieDAC = new EspecieDAC();

            result = especieDAC.Create(especie);
            return result;
        }

        public void Edit(Especie especie)
        {
            var especieDAC = new EspecieDAC();
            especieDAC.Update(especie);

        }

        public Especie Find(int? id)
        {
            Especie result = default(Especie);
            var especieDAC = new EspecieDAC();
            result = especieDAC.ReadBy(id.Value);
            return result;
        }

        public List<Especie> ToList()
        {
            List<Especie> result = default(List<Especie>);

            var especieDAC = new EspecieDAC();
            result = especieDAC.Read();
            return result;

        }

        public void Remove(Especie especie)
        {
            var especieDAC = new EspecieDAC();
            especieDAC.Delete(especie.Id);

        }

    }
}

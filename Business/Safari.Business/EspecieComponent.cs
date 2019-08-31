using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Safari.Entities;
using Safari.Data;
using NTier.Data;

namespace Safari.Business
{
   
    public partial class EspecieComponent
    {        
        public Especie Agregar(Especie especie)
        {
            Especie result = default(Especie);
            var especieDAC = new EspecieDAC();

            result = especieDAC.Create(especie);
            return result;
        }

        public List<Especie> ListarTodos()
        {
            List<Especie> result = default(List<Especie>);

            var especieDAC = new EspecieDAC();
            result = especieDAC.Read();
            return result;

        }
    }
}

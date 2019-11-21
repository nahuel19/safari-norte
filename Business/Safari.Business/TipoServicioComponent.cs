using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class TipoServicioComponent : IComponent<TipoServicio>
    {
        public TipoServicio Add(TipoServicio tipoServicio)
        {
            TipoServicio result = default(TipoServicio);
            var tipoServicioDAC = new TipoServicioDAC();

            result = tipoServicioDAC.Create(tipoServicio);
            return result;
        }

        public void Edit(TipoServicio tipoServicio)
        {
            var tipoServicioDAC = new TipoServicioDAC();
            tipoServicioDAC.Update(tipoServicio);

        }

        public TipoServicio Find(int? id)
        {
            TipoServicio result = default(TipoServicio);
            var tipoServicioDAC = new TipoServicioDAC();
            result = tipoServicioDAC.ReadBy(id.Value);
            return result;
        }

        public List<TipoServicio> ToList()
        {
            List<TipoServicio> result = default(List<TipoServicio>);

            var tipoServicioDAC = new TipoServicioDAC();
            result = tipoServicioDAC.Read();
            return result;

        }

        public void Remove(TipoServicio tipoServicio)
        {
            var tipoServicioDAC = new TipoServicioDAC();
            tipoServicioDAC.Delete(tipoServicio.Id);

        }

    }
}

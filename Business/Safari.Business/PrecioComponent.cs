using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class PrecioComponent : IComponent<Precio>
    {
        public Precio Add(Precio precio)
        {
            Precio result = default(Precio);
            var precioDAC = new PrecioDAC();

            result = precioDAC.Create(precio);
            return result;
        }

        public void Edit(Precio precio)
        {
            var precioDAC = new PrecioDAC();
            precioDAC.Update(precio);

        }

        public Precio Find(int? id)
        {
            Precio result = default(Precio);
            var precioDAC = new PrecioDAC();
            result = precioDAC.ReadBy(id.Value);
            
            result.TipoServicio = new TipoServicioDAC().ReadBy(result.TipoServicioId);
            return result;
        }

        public List<Precio> ToList()
        {
            List<Precio> result = default(List<Precio>);

            var precioDAC = new PrecioDAC();
            result = precioDAC.Read();

            foreach (var r in result)
            {
                r.TipoServicio = new TipoServicioDAC().ReadBy(r.TipoServicioId);
            }

            return result;

        }

        public void Remove(Precio precio)
        {
            var precioDAC = new PrecioDAC();
            precioDAC.Delete(precio.Id);

        }

    }
}

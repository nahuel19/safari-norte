using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class TipoMovimientoComponent : IComponent<TipoMovimiento>
    {
        public TipoMovimiento Add(TipoMovimiento tipoMovimiento)
        {
            TipoMovimiento result = default(TipoMovimiento);
            var tipoMovimientoDAC = new TipoMovimientoDAC();

            result = tipoMovimientoDAC.Create(tipoMovimiento);
            return result;
        }

        public void Edit(TipoMovimiento tipoMovimiento)
        {
            var tipoMovimientoDAC = new TipoMovimientoDAC();
            tipoMovimientoDAC.Update(tipoMovimiento);

        }

        public TipoMovimiento Find(int? id)
        {
            TipoMovimiento result = default(TipoMovimiento);
            var tipoMovimientoDAC = new TipoMovimientoDAC();
            result = tipoMovimientoDAC.ReadBy(id.Value);
            return result;
        }

        public List<TipoMovimiento> ToList()
        {
            List<TipoMovimiento> result = default(List<TipoMovimiento>);

            var tipoMovimientoDAC = new TipoMovimientoDAC();
            result = tipoMovimientoDAC.Read();
            return result;

        }

        public void Remove(TipoMovimiento tipoMovimiento)
        {
            var tipoMovimientoDAC = new TipoMovimientoDAC();
            tipoMovimientoDAC.Delete(tipoMovimiento.Id);

        }

    }
}

using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    
    public partial class MovimientoComponent : IComponent<Movimiento>
    {
        public Movimiento Add(Movimiento movimiento)
        {
            Movimiento result = default(Movimiento);
            var movimientoDAC = new MovimientoDAC();

            result = movimientoDAC.Create(movimiento);
            return result;
        }

        public void Edit(Movimiento movimiento)
        {
            var movimientoDAC = new MovimientoDAC();
            movimientoDAC.Update(movimiento);

        }

        public Movimiento Find(int? id)
        {
            Movimiento result = default(Movimiento);
            var movimientoDAC = new MovimientoDAC();
            result = movimientoDAC.ReadBy(id.Value);
            return result;
        }

        public List<Movimiento> ToList()
        {
            List<Movimiento> result = default(List<Movimiento>);

            var movimientoDAC = new MovimientoDAC();
            result = movimientoDAC.Read();
            return result;

        }

        public void Remove(Movimiento movimiento)
        {
            var movimientoDAC = new MovimientoDAC();
            movimientoDAC.Delete(movimiento.Id);

        }

    }
}

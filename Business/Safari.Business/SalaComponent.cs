using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class SalaComponent : IComponent<Sala>
    {
        public Sala Add(Sala sala)
        {
            Sala result = default(Sala);
            var salaDAC = new SalaDAC();

            result = salaDAC.Create(sala);
            return result;
        }

        public void Edit(Sala sala)
        {
            var salaDAC = new SalaDAC();
            salaDAC.Update(sala);

        }

        public Sala Find(int? id)
        {
            Sala result = default(Sala);
            var salaDAC = new SalaDAC();
            result = salaDAC.ReadBy(id.Value);
            return result;
        }

        public List<Sala> ToList()
        {
            List<Sala> result = default(List<Sala>);

            var salaDAC = new SalaDAC();
            result = salaDAC.Read();
            return result;

        }

        public void Remove(Sala sala)
        {
            var salaDAC = new SalaDAC();
            salaDAC.Delete(sala.Id);

        }
    }
}

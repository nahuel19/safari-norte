using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class PacienteComponent : IComponent<Paciente>
    {
        public Paciente Add(Paciente paciente)
        {
            Paciente result = default(Paciente);
            var pacienteDAC = new PacienteDAC();

            result = pacienteDAC.Create(paciente);
            return result;
        }

        public void Edit(Paciente paciente)
        {
            var pacienteDAC = new PacienteDAC();
            pacienteDAC.Update(paciente);

        }

        public Paciente Find(int? id)
        {
            Paciente result = default(Paciente);
            var pacienteDAC = new PacienteDAC();
            result = pacienteDAC.ReadBy(id.Value);

            result.Cliente = new ClienteDAC().ReadBy(result.ClienteId);
            result.Especie = new EspecieDAC().ReadBy(result.EspecieId);

            return result;
        }

        public List<Paciente> ToList()
        {
            List<Paciente> result = default(List<Paciente>);

            var pacienteDAC = new PacienteDAC();
            result = pacienteDAC.Read();

            foreach(var r in result)
            {
                r.Cliente = new ClienteDAC().ReadBy(r.ClienteId);
                r.Especie = new EspecieDAC().ReadBy(r.EspecieId);
            }


            return result;

        }

        public void Remove(Paciente paciente)
        {
            var pacienteDAC = new PacienteDAC();
            pacienteDAC.Delete(paciente.Id);

        }
    }
}

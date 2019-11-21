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
            return result;
        }

        public List<Paciente> ToList()
        {
            List<Paciente> result = default(List<Paciente>);

            var pacienteDAC = new PacienteDAC();
            result = pacienteDAC.Read();
            return result;

        }

        public void Remove(Paciente paciente)
        {
            var pacienteDAC = new PacienteDAC();
            pacienteDAC.Delete(paciente.Id);

        }
    }
}

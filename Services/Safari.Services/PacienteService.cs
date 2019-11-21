using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]

    public class PacienteService : IService<Paciente>
    {
        public Paciente Add(Paciente paciente)
        {
            var bc = new PacienteComponent();
            return bc.Add(paciente);
        }

        public void Edit(Paciente paciente)
        {
            var bc = new PacienteComponent();
            bc.Edit(paciente);
        }

        public Paciente Find(int? id)
        {
            var bc = new PacienteComponent();
            return bc.Find(id);
        }


        public void Remove(Paciente paciente)
        {
            var bc = new PacienteComponent();
            bc.Remove(paciente);
        }

        public List<Paciente> ToList()
        {
            var bc = new PacienteComponent();
            return bc.ToList();
        }
    }
}

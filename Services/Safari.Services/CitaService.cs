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

    public class CitaService : IService<Cita>
    {
        public Cita Add(Cita cita)
        {
            var bc = new CitaComponent();
            return bc.Add(cita);
        }

        public void Edit(Cita cita)
        {
            var bc = new CitaComponent();
            bc.Edit(cita);
        }

        public void Facturar(Cita cita, int val)
        {
            var bc = new CitaComponent();
            bc.Facturar(cita, val);
        }

        public Cita Find(int? id)
        {
            var bc = new CitaComponent();
            return bc.Find(id);
        }


        public void Remove(Cita cita)
        {
            var bc = new CitaComponent();
            bc.Remove(cita);
        }

        public List<Cita> ToList()
        {
            var bc = new CitaComponent();
            return bc.ToList();
        }
    }
}

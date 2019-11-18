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

    public class ClienteService : IService<Cliente>
    {
        public Cliente Add(Cliente cliente)
        {
            var bc = new ClienteComponent();
            return bc.Add(cliente);
        }

        public void Edit(Cliente cliente)
        {
            var bc = new ClienteComponent();
            bc.Edit(cliente);
        }

        public Cliente Find(int? id)
        {
            var bc = new ClienteComponent();
            return bc.Find(id);
        }


        public void Remove(Cliente cliente)
        {
            var bc = new ClienteComponent();
            bc.Remove(cliente);
        }

        public List<Cliente> ToList()
        {
            var bc = new ClienteComponent();
            return bc.ToList();
        }
    }
}

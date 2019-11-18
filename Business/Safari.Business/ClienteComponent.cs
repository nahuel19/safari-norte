using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class ClienteComponent : IComponent<Cliente>
    {
        public Cliente Add(Cliente cliente)
        {
            Cliente result = default(Cliente);
            var clienteDAC = new ClienteDAC();

            result = clienteDAC.Create(cliente);
            return result;
        }

        public void Edit(Cliente cliente)
        {
            var clienteDAC = new ClienteDAC();
            clienteDAC.Update(cliente);

        }

        public Cliente Find(int? id)
        {
            Cliente result = default(Cliente);
            var clienteDAC = new ClienteDAC();
            result = clienteDAC.ReadBy(id.Value);
            return result;
        }

        public List<Cliente> ToList()
        {
            List<Cliente> result = default(List<Cliente>);

            var clienteDAC = new ClienteDAC();
            result = clienteDAC.Read();
            return result;

        }

        public void Remove(Cliente cliente)
        {
            var clienteDAC = new ClienteDAC();
            clienteDAC.Delete(cliente.Id);

        }
    }
}

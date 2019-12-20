using Safari.Entities;
using Safari.Services.Contracts.Request;
using Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public partial class ClienteApiProcess : ProcessComponent
    {
        public List<Cliente> ToList()
        {
            var result = default(List<Cliente>);
            try
            {
                var response = HttpGet<ListarTodosClienteResponse>("api/Cliente/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }



        public Cliente Add(Cliente cliente)
        {
            Cliente result = default(Cliente);
            try
            {
                var request = new ClienteRequest() { Cliente = cliente };
                var response = HttpPost<ClienteResponse, ClienteRequest>("api/Cliente/Agregar", request, MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }


        public void Update(Cliente cliente)
        {
            try
            {
                var request = new ClienteRequest() { Cliente = cliente };
                HttpPost<ClienteResponse, ClienteRequest>("api/Cliente/Actualizar", request, MediaType.Json);

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public void Delete(Cliente cliente)
        {
            try
            {
                var request = new ClienteRequest() { Cliente = cliente };
                HttpPost<ClienteResponse, ClienteRequest>("api/Cliente/Eliminar", request, MediaType.Json);


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        
        public Cliente ReadBy(int id)
        {
            try
            {
                var parameters = new Dictionary<string, object> { { "id", id } };

                var response = HttpGet<ClienteResponse>("api/Cliente/LeerPorId", parameters, MediaType.Json);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}

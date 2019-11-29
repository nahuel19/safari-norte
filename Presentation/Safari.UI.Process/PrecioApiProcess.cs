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
   public partial class PrecioApiProcess : ProcessComponent
    {
        public List<Precio> ToList()
        {
            var result = default(List<Precio>);
            try
            {
                var response = HttpGet<ListarTodosPrecioResponse>("api/Precio/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }



        public Precio Add(Precio precio)
        {
            Precio result = default(Precio);
            try
            {
                var request = new PrecioRequest() { Precio = precio };
                var response = HttpPost<PrecioResponse, PrecioRequest>("api/Precio/Agregar", request, MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }


        public void Update(Precio precio)
        {
            try
            {
                var request = new PrecioRequest() { Precio = precio };
                HttpPost<PrecioResponse, PrecioRequest>("api/Precio/Actualizar", request, MediaType.Json);

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public void Delete(Precio precio)
        {
            try
            {
                var request = new PrecioRequest() { Precio = precio };
                HttpPost<PrecioResponse, PrecioRequest>("api/Precio/Eliminar", request, MediaType.Json);


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }




        public Precio ReadBy(int id)
        {
            try
            {
                var parameters = new Dictionary<string, object> { { "id", id } };

                var response = HttpGet<PrecioResponse>("api/Precio/LeerPorId", parameters, MediaType.Json);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}

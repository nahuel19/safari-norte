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
    public partial class TipoServicioApiProcess : ProcessComponent
    {
        public List<TipoServicio> ToList()
        {
            var result = default(List<TipoServicio>);
            try
            {
                var response = HttpGet<ListarTodosTipoServicioResponse>("api/TipoServicio/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }



        public TipoServicio Add(TipoServicio tipoServicio)
        {
            TipoServicio result = default(TipoServicio);
            try
            {
                var request = new TipoServicioRequest() { TipoServicio = tipoServicio };
                var response = HttpPost<TipoServicioResponse, TipoServicioRequest>("api/TipoServicio/Agregar", request, MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }


        public void Update(TipoServicio tipoServicio)
        {
            try
            {
                var request = new TipoServicioRequest() { TipoServicio = tipoServicio };
                HttpPost<TipoServicioResponse, TipoServicioRequest>("api/TipoServicio/Actualizar", request, MediaType.Json);

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public void Delete(TipoServicio tipoServicio)
        {
            try
            {
                var request = new TipoServicioRequest() { TipoServicio = tipoServicio };
                HttpPost<TipoServicioResponse, TipoServicioRequest>("api/TipoServicio/Eliminar", request, MediaType.Json);


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public TipoServicio ReadBy(int id)
        {
            try
            {
                var parameters = new Dictionary<string, object> { { "id", id } };

                var response = HttpGet<TipoServicioResponse>("api/TipoServicio/LeerPorId", parameters, MediaType.Json);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}

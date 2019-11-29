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
    
    public partial class TipoMovimientoApiProcess : ProcessComponent
    {
        public List<TipoMovimiento> ToList()
        {
            var result = default(List<TipoMovimiento>);
            try
            {
                var response = HttpGet<ListarTodosTipoMovimientoResponse>("api/TipoMovimiento/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }



        public TipoMovimiento Add(TipoMovimiento tipoMovimiento)
        {
            TipoMovimiento result = default(TipoMovimiento);
            try
            {
                var request = new TipoMovimientoRequest() { TipoMovimiento = tipoMovimiento };
                var response = HttpPost<TipoMovimientoResponse, TipoMovimientoRequest>("api/TipoMovimiento/Agregar", request, MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }


        public void Update(TipoMovimiento tipoMovimiento)
        {
            try
            {
                var request = new TipoMovimientoRequest() { TipoMovimiento = tipoMovimiento };
                HttpPost<TipoMovimientoResponse, TipoMovimientoRequest>("api/TipoMovimiento/Actualizar", request, MediaType.Json);

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public void Delete(TipoMovimiento tipoMovimiento)
        {
            try
            {
                var request = new TipoMovimientoRequest() { TipoMovimiento = tipoMovimiento };
                HttpPost<TipoMovimientoResponse, TipoMovimientoRequest>("api/TipoMovimiento/Eliminar", request, MediaType.Json);


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }




        public TipoMovimiento ReadBy(int id)
        {
            try
            {
                var parameters = new Dictionary<string, object> { { "id", id } };

                var response = HttpGet<TipoMovimientoResponse>("api/TipoMovimiento/LeerPorId", parameters, MediaType.Json);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}

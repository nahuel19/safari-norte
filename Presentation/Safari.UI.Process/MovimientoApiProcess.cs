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
    
    public partial class MovimientoApiProcess : ProcessComponent
    {
        public List<Movimiento> ToList()
        {
            var result = default(List<Movimiento>);
            try
            {
                var response = HttpGet<ListarTodosMovimientoResponse>("api/Movimiento/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }



        public Movimiento Add(Movimiento movimiento)
        {
            Movimiento result = default(Movimiento);
            try
            {
                var request = new MovimientoRequest() { Movimiento = movimiento };
                var response = HttpPost<MovimientoResponse, MovimientoRequest>("api/Movimiento/Agregar", request, MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }


        public void Update(Movimiento movimiento)
        {
            try
            {
                var request = new MovimientoRequest() { Movimiento = movimiento };
                HttpPost<MovimientoResponse, MovimientoRequest>("api/Movimiento/Actualizar", request, MediaType.Json);

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public void Delete(Movimiento movimiento)
        {
            try
            {
                var request = new MovimientoRequest() { Movimiento = movimiento };
                HttpPost<MovimientoResponse, MovimientoRequest>("api/Movimiento/Eliminar", request, MediaType.Json);


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public Movimiento ReadBy(int id)
        {
            try
            {
                var parameters = new Dictionary<string, object> { { "id", id } };

                var response = HttpGet<MovimientoResponse>("api/Movimiento/LeerPorId", parameters, MediaType.Json);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}

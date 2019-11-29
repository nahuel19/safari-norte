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
    public partial class CitaApiProcess : ProcessComponent
    {
        public List<Cita> ToList()
        {
            var result = default(List<Cita>);
            try
            {
                var response = HttpGet<ListarTodosCitaResponse>("api/Cita/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }



        public Cita Add(Cita cita)
        {
            Cita result = default(Cita);
            try
            {
                var request = new CitaRequest() { Cita = cita };
                var response = HttpPost<CitaResponse, CitaRequest>("api/Cita/Agregar", request, MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }


        public void Update(Cita cita)
        {
            try
            {
                var request = new CitaRequest() { Cita = cita };
                HttpPost<CitaResponse, CitaRequest>("api/Cita/Actualizar", request, MediaType.Json);

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public void Delete(Cita cita)
        {
            try
            {
                var request = new CitaRequest() { Cita = cita };
                HttpPost<CitaResponse, CitaRequest>("api/Cita/Eliminar", request, MediaType.Json);


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }




        public Cita ReadBy(int id)
        {
            try
            {
                var parameters = new Dictionary<string, object> { { "id", id } };

                var response = HttpGet<CitaResponse>("api/Cita/LeerPorId", parameters, MediaType.Json);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}

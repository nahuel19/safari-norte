using Safari.Business;
using Safari.Services.Contracts.Request;
using Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Safari.Services.Http
{
    
    [RoutePrefix("api/Cita")]
    public class CitaServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public CitaResponse Agregar(CitaRequest request)
        {
            try
            {
                var response = new CitaResponse();
                var bc = new CitaComponent();
                response.Result = bc.Add(request.Cita);
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("ListarTodos")]
        public ListarTodosCitaResponse ListarTodos()
        {
            try
            {
                var response = new ListarTodosCitaResponse();
                var bc = new CitaComponent();
                response.Result = bc.ToList();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }


        [HttpGet]
        [Route("LeerPorId")]
        public CitaResponse LeerPorId(int id)
        {
            try
            {
                var response = new CitaResponse();
                var bc = new CitaComponent();
                response.Result = bc.Find(id);
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }


        [HttpPost]
        [Route("Actualizar")]
        public void Actualizar(CitaRequest request)
        {
            try
            {
                var bc = new CitaComponent();
                bc.Edit(request.Cita);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }


        [HttpDelete]
        [Route("Eliminar")]
        public void Eliminar(CitaRequest request)
        {
            try
            {
                var bc = new CitaComponent();
                
                bc.Remove(request.Cita);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }




    }
}

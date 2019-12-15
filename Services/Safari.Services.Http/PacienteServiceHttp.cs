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
    
    [RoutePrefix("api/Paciente")]
    public class PacienteServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public PacienteResponse Agregar(PacienteRequest request)
        {
            try
            {
                var response = new PacienteResponse();
                var bc = new PacienteComponent();
                response.Result = bc.Add(request.Paciente);
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
        public ListarTodosPacienteResponse ListarTodos()
        {
            try
            {
                var response = new ListarTodosPacienteResponse();
                var bc = new PacienteComponent();
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
        public PacienteResponse LeerPorId(int id)
        {
            try
            {
                var response = new PacienteResponse();
                var bc = new PacienteComponent();
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
        public void Actualizar(PacienteRequest request)
        {
            try
            {
                var bc = new PacienteComponent();
                bc.Edit(request.Paciente);
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
        [Route("Eliminar")]
        public void Eliminar(PacienteRequest request)
        {
            try
            {
                var bc = new PacienteComponent();
                //var paciente = bc.Find(id);
                bc.Remove(request.Paciente);
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

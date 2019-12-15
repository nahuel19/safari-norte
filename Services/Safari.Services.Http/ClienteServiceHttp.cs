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

    [RoutePrefix("api/Cliente")]
    public class ClienteServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public ClienteResponse Agregar(ClienteRequest request)
        {
            try
            {
                var response = new ClienteResponse();
                var bc = new ClienteComponent();
                response.Result = bc.Add(request.Cliente);
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
        public ListarTodosClienteResponse ListarTodos()
        {
            try
            {
                var response = new ListarTodosClienteResponse();
                var bc = new ClienteComponent();
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
        public ClienteResponse LeerPorId(int id)
        {
            try
            {
                var response = new ClienteResponse();
                var bc = new ClienteComponent();
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
        public void Actualizar(ClienteRequest request)
        {
            try
            {
                var bc = new ClienteComponent();
                bc.Edit(request.Cliente);
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
        public void Eliminar(ClienteRequest request)
        {
            try
            {
                var bc = new ClienteComponent();
                //var especie = bc.Find(id);
                bc.Remove(request.Cliente);
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

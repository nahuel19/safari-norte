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

    [RoutePrefix("api/Sala")]
    public class SalaServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public SalaResponse Agregar(SalaRequest request)
        {
            try
            {
                var response = new SalaResponse();
                var bc = new SalaComponent();
                response.Result = bc.Add(request.Sala);
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
        public ListarTodosSalaResponse ListarTodos()
        {
            try
            {
                var response = new ListarTodosSalaResponse();
                var bc = new SalaComponent();
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
        public SalaResponse LeerPorId(int id)
        {
            try
            {
                var response = new SalaResponse();
                var bc = new SalaComponent();
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
        public void Actualizar(SalaRequest request)
        {
            try
            {
                var bc = new SalaComponent();
                bc.Edit(request.Sala);
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
        public void Eliminar(SalaRequest request)
        {
            try
            {
                var bc = new SalaComponent();
                //var sala = bc.Find(id);
                bc.Remove(request.Sala);
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

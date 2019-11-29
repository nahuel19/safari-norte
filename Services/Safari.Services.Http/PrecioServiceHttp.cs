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
   
    [RoutePrefix("api/Precio")]
    public class PrecioServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public PrecioResponse Agregar(PrecioRequest request)
        {
            try
            {
                var response = new PrecioResponse();
                var bc = new PrecioComponent();
                response.Result = bc.Add(request.Precio);
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
        public ListarTodosPrecioResponse ListarTodos()
        {
            try
            {
                var response = new ListarTodosPrecioResponse();
                var bc = new PrecioComponent();
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
        public PrecioResponse LeerPorId(int id)
        {
            try
            {
                var response = new PrecioResponse();
                var bc = new PrecioComponent();
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
        public void Actualizar(PrecioRequest request)
        {
            try
            {
                var bc = new PrecioComponent();
                bc.Edit(request.Precio);
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
        public void Eliminar(PrecioRequest request)
        {
            try
            {
                var bc = new PrecioComponent();
                
                bc.Remove(request.Precio);
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

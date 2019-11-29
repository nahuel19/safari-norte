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
    [RoutePrefix("api/Especie")]
    public class EspecieServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public EspecieResponse Agregar(EspecieRequest request)
        {
            try
            {
                var response = new EspecieResponse();
                var bc = new EspecieComponent();
                response.Result = bc.Add(request.Especie);
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
        public ListarTodosEspecieResponse ListarTodos()
        {
            try
            {
                var response = new ListarTodosEspecieResponse();
                var bc = new EspecieComponent();
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
        public EspecieResponse LeerPorId(int id)
        {
            try
            {
                var response = new EspecieResponse();
                var bc = new EspecieComponent();
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
        public void Actualizar(EspecieRequest request)
        {
            try
            {
                var bc = new EspecieComponent();
                bc.Edit(request.Especie);
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
        public void Eliminar(EspecieRequest request)
        {
            try
            {
                var bc = new EspecieComponent();
                //var especie = bc.Find(id);
                bc.Remove(request.Especie);
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

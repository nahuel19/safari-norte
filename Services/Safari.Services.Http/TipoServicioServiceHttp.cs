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

    [RoutePrefix("api/TipoServicio")]
    public class TipoServicioServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public TipoServicioResponse Agregar(TipoServicioRequest request)
        {
            try
            {
                var response = new TipoServicioResponse();
                var bc = new TipoServicioComponent();
                response.Result = bc.Add(request.TipoServicio);
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
        public ListarTodosTipoServicioResponse ListarTodos()
        {
            try
            {
                var response = new ListarTodosTipoServicioResponse();
                var bc = new TipoServicioComponent();
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
        public TipoServicioResponse LeerPorId(int id)
        {
            try
            {
                var response = new TipoServicioResponse();
                var bc = new TipoServicioComponent();
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
        public void Actualizar(TipoServicioRequest request)
        {
            try
            {
                var bc = new TipoServicioComponent();
                bc.Edit(request.TipoServicio);
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
        public void Eliminar(TipoServicioRequest request)
        {
            try
            {
                var bc = new TipoServicioComponent();
                //var especie = bc.Find(id);
                bc.Remove(request.TipoServicio);
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

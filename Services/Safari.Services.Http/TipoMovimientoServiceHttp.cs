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
    
    [RoutePrefix("api/TipoMovimiento")]
    public class TipoMovimientoServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public TipoMovimientoResponse Agregar(TipoMovimientoRequest request)
        {
            try
            {
                var response = new TipoMovimientoResponse();
                var bc = new TipoMovimientoComponent();
                response.Result = bc.Add(request.TipoMovimiento);
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
        public ListarTodosTipoMovimientoResponse ListarTodos()
        {
            try
            {
                var response = new ListarTodosTipoMovimientoResponse();
                var bc = new TipoMovimientoComponent();
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
        public TipoMovimientoResponse LeerPorId(int id)
        {
            try
            {
                var response = new TipoMovimientoResponse();
                var bc = new TipoMovimientoComponent();
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
        public void Actualizar(TipoMovimientoRequest request)
        {
            try
            {
                var bc = new TipoMovimientoComponent();
                bc.Edit(request.TipoMovimiento);
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
        public void Eliminar(TipoMovimientoRequest request)
        {
            try
            {
                var bc = new TipoMovimientoComponent();
                bc.Remove(request.TipoMovimiento);
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

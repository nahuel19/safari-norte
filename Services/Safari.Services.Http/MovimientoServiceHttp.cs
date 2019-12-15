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
    [RoutePrefix("api/Movimiento")]
    public class MovimientoServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public MovimientoResponse Agregar(MovimientoRequest request)
        {
            try
            {
                var response = new MovimientoResponse();
                var bc = new MovimientoComponent();
                response.Result = bc.Add(request.Movimiento);
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
        public ListarTodosMovimientoResponse ListarTodos()
        {
            try
            {
                var response = new ListarTodosMovimientoResponse();
                var bc = new MovimientoComponent();
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
        public MovimientoResponse LeerPorId(int id)
        {
            try
            {
                var response = new MovimientoResponse();
                var bc = new MovimientoComponent();
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
        public void Actualizar(MovimientoRequest request)
        {
            try
            {
                var bc = new MovimientoComponent();
                bc.Edit(request.Movimiento);
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
        public void Eliminar(MovimientoRequest request)
        {
            try
            {
                var bc = new MovimientoComponent();
                //var especie = bc.Find(id);
                bc.Remove(request.Movimiento);
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

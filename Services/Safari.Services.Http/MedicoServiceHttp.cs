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


    //[RoutePrefix("api/Medico")]
    //public class MedicoServiceHttp : ApiController
    //{
    //    [HttpPost]
    //    [Route("Agregar")]
    //    public MedicoResponse Agregar(MedicoRequest request)
    //    {
    //        try
    //        {
    //            var response = new MedicoResponse();
    //            var bc = new MedicoComponent();
    //            response.Result = bc.Add(request.Medico);
    //            return response;
    //        }
    //        catch (Exception ex)
    //        {
    //            var httpError = new HttpResponseMessage()
    //            {
    //                StatusCode = (HttpStatusCode)422, // UNPROCESSABLE ENTITY
    //                ReasonPhrase = ex.Message
    //            };
    //            throw new HttpResponseException(httpError);
    //        }
    //    }

    //    [HttpGet]
    //    [Route("ListarTodos")]
    //    public ListarTodosMedicoResponse ListarTodos()
    //    {
    //        try
    //        {
    //            var response = new ListarTodosMedicoResponse();
    //            var bc = new MedicoComponent();
    //            response.Result = bc.ToList();
    //            return response;
    //        }
    //        catch (Exception ex)
    //        {
    //            var httpError = new HttpResponseMessage()
    //            {
    //                StatusCode = (HttpStatusCode)422, // UNPROCESSABLE ENTITY
    //                ReasonPhrase = ex.Message
    //            };
    //            throw new HttpResponseException(httpError);
    //        }
    //    }
    //}


    [RoutePrefix("api/Medico")]
    public class MedicoServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public MedicoResponse Agregar(MedicoRequest request)
        {
            try
            {
                var response = new MedicoResponse();
                var bc = new MedicoComponent();
                response.Result = bc.Add(request.Medico);
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
        public ListarTodosMedicoResponse ListarTodos()
        {
            try
            {
                var response = new ListarTodosMedicoResponse();
                var bc = new MedicoComponent();
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
        public MedicoResponse LeerPorId(int id)
        {
            try
            {
                var response = new MedicoResponse();
                var bc = new MedicoComponent();
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
        public void Actualizar(MedicoRequest request)
        {
            try
            {
                var bc = new MedicoComponent();
                bc.Edit(request.Medico);
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


        //[HttpDelete]
        //[Route("Eliminar")]
        //public void Eliminar(MedicoRequest request)
        //{
        //    try
        //    {
        //        var bc = new MedicoComponent();
        //        bc.Remove(request.Medico);
        //    }
        //    catch (Exception ex)
        //    {
        //        var httpError = new HttpResponseMessage()
        //        {
        //            StatusCode = (HttpStatusCode)422,
        //            ReasonPhrase = ex.Message
        //        };
        //        throw new HttpResponseException(httpError);
        //    }
        //}
        [HttpPost]
        [Route("Eliminar")]
        public void Eliminar(int id)
        {
            try
            {
                var bc = new MedicoComponent();
                var medico = bc.Find(id);
                bc.Remove(medico);
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

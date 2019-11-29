using Safari.Entities;
using Safari.Services.Contracts.Request;
using Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public partial class MedicoApiProcess : ProcessComponent
    {
        //public List<Medico> ToList()
        //{
        //    var result = default(List<Medico>);
        //    try
        //    {
        //        var response = HttpGet<ListarTodosMedicoResponse>("api/Medico/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
        //        result = response.Result;
        //    }
        //    catch (FaultException fex)
        //    {
        //        throw new ApplicationException(fex.Message);
        //    }
        //    return result;
        //}

        //public Medico Create(Medico medico)
        //{
        //    MedicoResponse response = default(MedicoResponse);
        //    MedicoRequest payload = new MedicoRequest();
        //    try
        //    {
        //        payload.Medico = medico;
        //        response = HttpPost<MedicoResponse, MedicoRequest>(
        //            "api/Medico/Agregar",
        //            payload,
        //            MediaType.Json
        //        );
        //    }
        //    catch (FaultException fex)
        //    {
        //        throw new ApplicationException(fex.Message);
        //    }
        //    return response.Result;
        //}

        public List<Medico> ToList()
        {
            var result = default(List<Medico>);
            try
            {
                var response = HttpGet<ListarTodosMedicoResponse>("api/Medico/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }



        public Medico Add(Medico medico)
        {
            Medico result = default(Medico);
            try
            {
                var request = new MedicoRequest() { Medico = medico };
                var response = HttpPost<MedicoResponse, MedicoRequest>("api/Medico/Agregar", request, MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }


        public void Update(Medico medico)
        {
            try
            {
                var request = new MedicoRequest() { Medico = medico };
                var response = HttpPost<MedicoResponse, MedicoRequest>("api/Medico/Actualizar", request, MediaType.Json);

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public void Delete(Medico medico)
        {
            try
            {
                var request = new MedicoRequest() { Medico = medico };
                var r = HttpPost<MedicoRequest>("api/Medico/Eliminar", request, MediaType.Json);


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Medico ReadBy(int id)
        {
            try
            {
                var parameters = new Dictionary<string, object> { { "id", id } };

                var response = HttpGet<MedicoResponse>("api/Medico/LeerPorId", parameters, MediaType.Json);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}

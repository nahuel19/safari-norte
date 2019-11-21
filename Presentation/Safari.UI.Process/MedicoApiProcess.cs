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

        public Medico Create(Medico medico)
        {
            AgregarMedicoResponse response = default(AgregarMedicoResponse);
            AgregarMedicoRequest payload = new AgregarMedicoRequest();
            try
            {
                payload.data = medico;
                response = HttpPost<AgregarMedicoResponse, AgregarMedicoRequest>(
                    "api/Medico/Agregar",
                    payload,
                    MediaType.Json
                );
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return response.result;
        }


    }
}

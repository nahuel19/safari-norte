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
    public partial class PacienteApiProcess : ProcessComponent
    {
        public List<Paciente> ToList()
        {
            var result = default(List<Paciente>);
            try
            {
                var response = HttpGet<ListarTodosPacienteResponse>("api/Paciente/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }



        public Paciente Add(Paciente paciente)
        {
            Paciente result = default(Paciente);
            try
            {
                var request = new PacienteRequest() { Paciente = paciente };
                var response = HttpPost<PacienteResponse, PacienteRequest>("api/Paciente/Agregar", request, MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }


        public void Update(Paciente paciente)
        {
            try
            {
                var request = new PacienteRequest() { Paciente = paciente };
                HttpPost<PacienteResponse, PacienteRequest>("api/Paciente/Actualizar", request, MediaType.Json);

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public void Delete(Paciente paciente)
        {
            try
            {
                var request = new PacienteRequest() { Paciente = paciente };
                HttpPost<PacienteResponse, PacienteRequest>("api/Paciente/Eliminar", request, MediaType.Json);


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public Paciente ReadBy(int id)
        {
            try
            {
                var parameters = new Dictionary<string, object> { { "id", id } };

                var response = HttpGet<PacienteResponse>("api/Paciente/LeerPorId", parameters, MediaType.Json);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}

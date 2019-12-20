
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
    
    public partial class SalaApiProcess : ProcessComponent
    {
        public List<Sala> ToList()
        {
            var result = default(List<Sala>);
            try
            {
                var response = HttpGet<ListarTodosSalaResponse>("api/Sala/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }



        public Sala Add(Sala sala)
        {
            Sala result = default(Sala);
            try
            {
                var request = new SalaRequest() { Sala = sala };
                var response = HttpPost<SalaResponse, SalaRequest>("api/Sala/Agregar", request, MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }


        public void Update(Sala sala)
        {
            try
            {
                var request = new SalaRequest() { Sala = sala };
                HttpPost<SalaResponse, SalaRequest>("api/Sala/Actualizar", request, MediaType.Json);

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public void Delete(Sala sala)
        {
            try
            {
                var request = new SalaRequest() { Sala = sala };
                HttpPost<SalaResponse, SalaRequest>("api/Sala/Eliminar", request, MediaType.Json);


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public Sala ReadBy(int id)
        {
            try
            {
                var parameters = new Dictionary<string, object> { { "id", id } };

                var response = HttpGet<SalaResponse>("api/Sala/LeerPorId", parameters, MediaType.Json);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}

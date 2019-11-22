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
    
    public partial class EspecieApiProcess : ProcessComponent
    {
        public List<Especie> ToList()
        {
            var result = default(List<Especie>);
            try
            {
                var response = HttpGet<ListarTodosEspecieResponse>("api/Especie/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }



        public Especie Add(Especie especie)
        {
            Especie result = default(Especie);
            try
            {
                var request = new EspecieRequest() { Especie = especie };
                var response = HttpPost<EspecieResponse, EspecieRequest>("api/Especie/Agregar", request, MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }


        public void Update(Especie especie)
        {
            try
            {
                var request = new EspecieRequest() { Especie = especie };
                var response = HttpPost<EspecieResponse, EspecieRequest>("api/Especie/Actualizar", request, MediaType.Json);
                
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public void Delete(Especie especie)
        {
            try
            {
                var request = new EspecieRequest() { Especie = especie };
                var r = HttpPost<EspecieRequest>("api/Especie/Eliminar", request, MediaType.Json);
                
                
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Especie ReadBy(int id)
        {
            try
            {
                var parameters = new Dictionary<string, object> {{ "id", id }};

                var response = HttpGet<EspecieResponse>("api/Especie/LeerPorId", parameters, MediaType.Json);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}

using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    [ServiceContract]
    public interface IEspecieService  /*<TEntity> where TEntity : EntityBase*/
    {
        [OperationContract]
        Especie Add(Especie especie);
        [OperationContract]
        List<Especie> ToList();
        [OperationContract]
        Especie Find(int? id);
        [OperationContract]
        void Edit(Especie especie);
        [OperationContract]
        void Remove(Especie especie);
        //[OperationContract]
        //TEntity Add(TEntity entity);
        //[OperationContract]
        //List<TEntity> ToList();
        //[OperationContract]
        //TEntity Find(int? id);
        //[OperationContract]
        //void Edit(TEntity entity);
        //[OperationContract]
        //void Remove(TEntity entity);

    }
}

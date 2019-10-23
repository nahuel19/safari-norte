using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Entities;

namespace Safari.Business
{
    public interface IComponent<TEntity> where TEntity : EntityBase
    {
        TEntity Add(TEntity entity);
        List<TEntity> ToList();
        TEntity Find(int? id);
        void Edit(TEntity entity);
        void Remove(TEntity entity);
    }
}

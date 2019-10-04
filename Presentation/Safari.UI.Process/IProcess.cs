using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public interface IProcess<TEntity> where TEntity : EntityBase
    {
        List<TEntity> ToList();
        TEntity Find(int? id);
        TEntity Add(TEntity entity);
        TEntity Edit(TEntity entity);
        TEntity Remove(TEntity entity);
    }
}

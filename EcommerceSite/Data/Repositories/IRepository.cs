using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories
{
    public interface IRepository<TEntity>
        where TEntity:class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(params object[] id);
        TEntity Add(TEntity entitiy);
        void Edit(TEntity entitiy);
        void Delete(params object[] id);
    }
}

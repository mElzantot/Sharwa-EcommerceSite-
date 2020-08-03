using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories
{
    public class Reposiotry<TContext, TEntity> : IRepository<TEntity>
        where TEntity : class 
        where TContext : DbContext
    {
        private readonly TContext context;
        protected readonly DbSet<TEntity> set;
       
        public Reposiotry(TContext context)
        {
            this.context = context;
            set = context.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            context.Add(entity);
            if (context.SaveChanges() > 0)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public void Delete(params object[] id)
        {
            TEntity entity =  set.Find(id);
            context.Entry(entity).State = EntityState.Deleted;
            //return context.SaveChanges() > 0 ? true : false; 
        }

        public void Edit(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            //return context.SaveChanges() > 0 ? entity : null;
        }

        public IQueryable<TEntity> GetAll()
        {
            return set;
        }

        public TEntity GetById(params object[] id)
        {
            return set.Find(id);
        }
    }
}

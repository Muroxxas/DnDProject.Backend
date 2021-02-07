using DnDProject.Backend.Repository.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Implementations.Generic
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext Context;

        //Create
        public void Add(TEntity newRecord)
        {
            Context.Set<TEntity>().Add(newRecord);
        }
        public void AddRange(IEnumerable<TEntity> newRecords)
        {
            Context.Set<TEntity>().AddRange(newRecords);
        }

        //Read
        public TEntity Get(Guid id)
        {

            return Context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        //Delete
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public void Remove(Guid id)
        {
            TEntity foundRecord = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(foundRecord);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public Repository(DbContext context)
        {
            Context = context;

        }
    }
}

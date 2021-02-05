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
        protected DbSet<TEntity> _dbSet;

        //Create
        public void Add(TEntity newRecord)
        {
            _dbSet.Add(newRecord);
        }
        public void AddRange(IEnumerable<TEntity> newRecords)
        {
            _dbSet.AddRange(newRecords);
        }

        //Read
        public TEntity Get(Guid id)
        {

            return _dbSet.Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        //Update
        public void Update(TEntity updatedRecord)
        {
            _dbSet.Attach(updatedRecord);
            var entry = Context.Entry(updatedRecord);
            entry.State = EntityState.Modified;
        }


        //Delete
        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public Repository(DbContext context)
        {
            Context = context;
            //Set _dbSet to the DbSet of TEntity.
            _dbSet = context.Set<TEntity>();
        }
    }
}

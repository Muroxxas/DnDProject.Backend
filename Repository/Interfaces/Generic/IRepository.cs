using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Interfaces.Generic
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Generic interface for creating a repository for a model.
        //Declares many of the base functionalities that our implementations will require.

        //Create
        void Add(TEntity newRecord);
        void AddRange(IEnumerable<TEntity> newRecords);

        //Read
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();

        //Allows me to use Linq and lambda statements (x => x.propertyName) to find objects, such as if I want to find all characters with name "John".
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //Update
        void Update(TEntity updatedRecord);
       
        //Delete
        void Remove(TEntity entity);
        void Remove(Guid id);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}

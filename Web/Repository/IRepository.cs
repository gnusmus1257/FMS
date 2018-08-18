using System;
using System.Collections.Generic;

namespace Web.Repository
{
    public interface IRepository<TEntity>: IDisposable where TEntity : class
    {
        void Create(TEntity item);
        TEntity FindById(int id);
        TEntity Find(Func<TEntity, bool> predicate);
        TEntity Find(Func<TEntity, bool> predicate, string children);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate, string children);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
using Microsoft.EntityFrameworkCore;
using SecureData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SecureData.Interface
{
    public interface IGeericRepository<TEntity>
        where TEntity : class
       
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);
        bool Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Save();
    }
}

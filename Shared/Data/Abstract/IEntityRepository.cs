using Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        public Task<T> GetAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T,object>>[] includes);
        public Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes);
        public Task AddAsync(T entity);
        public Task RemoveAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);
        public Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}

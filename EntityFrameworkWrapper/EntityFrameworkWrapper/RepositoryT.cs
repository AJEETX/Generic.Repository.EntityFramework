using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Find(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Remove(int id);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly IDbContext _dbContext;
        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Add(T entity)
        {
            return Task.FromResult(_dbContext.Set<T>().Add(entity));
        }

        public Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(_dbContext.Set<T>().Find(predicate));
        }

        public Task<IEnumerable<T>> Get()
        {
            return Task.FromResult(_dbContext.Set<T>().AsEnumerable());
        }

        public Task Remove(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            return Task.FromResult(_dbContext.Set<T>().Remove(entity));
        }
    }
}

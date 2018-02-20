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
        IEnumerable<T> Get();
        T Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _context;
        public Repository(IDbContext context)
        {
            _context = context;
        }
        public virtual void Add(T entity)
        {
                _context.Set<T>().Add(entity);
                _context.Save();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.Save();
        }
        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Find(predicate);
        }
        public virtual IEnumerable<T> Get()
        {
            return _context.Set<T>();
        }
    }
}

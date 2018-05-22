using System.Collections.Generic;

namespace Generic.Repository.EntityFramework
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Find(int id);
        void Update(T entity);
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
                _context.Set<T>().Add(entity); _context.Save();
        }
        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity); _context.Save();
        }
        public virtual T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public virtual IEnumerable<T> Get()
        {
            return _context.Set<T>();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);_context.Save();
        }
    }
}

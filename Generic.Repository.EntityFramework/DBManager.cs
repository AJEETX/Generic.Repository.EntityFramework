using System;
using System.Collections;

namespace Generic.Repository.EntityFramework
{
    public interface IDBManager
    {
        IRepository<T> GetRepository<T>() where T : class;
    }
    class DBManager : IDBManager
    {
        readonly IDbContext _dbContext;
        static Hashtable _repositories;
        public DBManager(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories == null) _repositories = new Hashtable();
            var type = typeof(T).Name;
            if (!_repositories.ContainsKey(type)) {
                var repoType = typeof(Repository<>);
                var repoInstance = Activator.CreateInstance(repoType.MakeGenericType(typeof(T)), _dbContext);
                _repositories.Add(type, repoInstance);
            }
            return (IRepository<T>)_repositories[type];
        }
    }
}

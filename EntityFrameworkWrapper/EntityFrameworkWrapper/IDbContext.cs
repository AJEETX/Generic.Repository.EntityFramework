using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class;
        int Save();
    }
}

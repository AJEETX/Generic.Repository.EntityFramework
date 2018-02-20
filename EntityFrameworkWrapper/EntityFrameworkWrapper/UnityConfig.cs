using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace EntityFrameworkWrapper
{
    public class UnityConfig
    {
        public static IDBManager GetDBManager()
        {
            IUnityContainer unitycontainer = new UnityContainer();
            unitycontainer.RegisterType<IDBManager, DBManager>();
            unitycontainer.RegisterType(typeof(IRepository<>),typeof(Repository<>));
            return unitycontainer.Resolve<IDBManager>();
        }
    }
}

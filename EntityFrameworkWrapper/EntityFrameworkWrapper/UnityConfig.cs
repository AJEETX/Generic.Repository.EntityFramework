using Unity;

namespace EntityFrameworkWrapper
{
    public class UnityConfig
    {
        public static IUnityContainer UnityContainer;
        static UnityConfig()
        {
            UnityContainer = new UnityContainer();
            UnityContainer.RegisterType<IDBManager, DBManager>();
            UnityContainer.RegisterType(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}

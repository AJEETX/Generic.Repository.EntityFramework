using Unity;

namespace Generic.Repository.EntityFramework
{
    public static class UnityConfig
    {
        public static IUnityContainer Container;
        static UnityConfig()
        {
            Container = new UnityContainer();
            Container.RegisterType<IDBManager, DBManager>();
            Container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}

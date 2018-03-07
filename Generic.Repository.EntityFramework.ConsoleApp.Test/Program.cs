using System;
using ConsoleApp.Service;
using EntityFrameworkWrapper;
using Unity;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var unitycontainer = UnityConfig.UnityContainer;
            unitycontainer.RegisterType<IDbContext, dbModel>();
            var dbMgr = unitycontainer.Resolve<IDBManager>();
            var result=dbMgr.GetRepository<Customer>().Get();
            foreach (var item in result)
            {
                Console.WriteLine($"Name : {item.Name} Age : {item.Age}");
            }
            Console.ReadLine();
        }
    }
}

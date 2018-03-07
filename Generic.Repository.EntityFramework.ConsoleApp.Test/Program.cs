using System;
using Generic.Repository.EntityFramework;
using Generic.Repository.EntityFramework.ConsoleApp.Test.Model;
using Unity;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = UnityConfig.Container;
            container.RegisterType<IDbContext, DataModel>();
            var dbMgr = container.Resolve<IDBManager>();
            var result = dbMgr.GetRepository<Customer>().Get();
            foreach (var item in result)
            {
                Console.WriteLine($"Name : {item.Name} Age : {item.Age}");
            }
            Console.ReadLine();
        }
    }
}

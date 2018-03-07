using Generic.Repository.EntityFramework;
namespace Generic.Repository.EntityFramework.ConsoleApp.Test.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext, IDbContext
    {
        public DataModel() : base("name=DataModel") { }
        public virtual DbSet<Customer> Customers { get; set; }

        public int Save()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }

        IDbSet<T> IDbContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}

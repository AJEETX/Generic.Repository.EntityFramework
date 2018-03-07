namespace ConsoleApp.Service
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EntityFrameworkWrapper;

    public partial class dbModel : DbContext,IDbContext
    {
        public dbModel()
            : base("name=dbModelz")
        {
        }

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

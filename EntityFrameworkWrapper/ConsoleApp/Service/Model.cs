
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EntityFrameworkWrapper;
using ConsoleApp.Service;

public partial class Model : DbContext,IDbContext
    {
    public Model() : base("name=dbModel") { }
    public int Save()
    {
        return base.SaveChanges();
    }

    public virtual DbSet<Customer> Customers { get; set; }
    IDbSet<T> IDbContext.Set<T>()
    {
        return base.Set<T>();
    }
    }
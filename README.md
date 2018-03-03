# EntityFrameworkWrapper [![.Net Framework](https://img.shields.io/badge/DotNet-4.6.1-blue.svg)](https://www.microsoft.com/en-au/download/details.aspx?id=49981)


> [![Release](https://img.shields.io/badge/release-v1.0.7-blue.svg)](https://www.nuget.org/packages/Generic.Repository.EntityFramework/1.0.7)

>[![Downloads](https://img.shields.io/badge/downloads-1K-blue.svg)](https://www.nuget.org/stats/packages/Generic.Repository.EntityFramework?groupby=Version)

> [![Build Status](https://travis-ci.org/AJEETX/EntityFrameworkWrapper.png?branch=master)](https://travis-ci.org/AJEETX/EntityFrameworkWrapper)

> [![dependencies Status](https://img.shields.io/badge/dependency-none-brightgreen.svg)](https://img.shields.io/badge/dependency-none-brightgreen.svg)

### Steps to start working with your sql server database from .net application:
>   Through Visual Studio IDE, 
>	1.  Download the latest nuget package of 'EntityFrameworkWrapper' from http://nuget.org
>	2. Create your EntityFramework DataModel, then tweak the DataModel as below
```

using EntityFrameworkWrapper;       //add this reference
//DB is real data model created from database
//IDbContext is inherited from this nuget package
public partial class DB : DbContext, IDbContext   
    {
        public DB() : base("name=connectionstring"){} 
        IDbSet<T> IDbContext.Set<T>()
        {
            return base.Set<T>();
        }
        public int Save()
        {
            return base.SaveChanges();
        }
        ....
        ...
    }
```
>   3.	Now all set, please add the below lines from your consuming object/component

```
using EntityFrameworkWrapper; //add this reference
using Unity;  //add this reference
public class ConsumeService
{
    ...
     ...
    void ConsumeMethod()
     {
     var unitycontainer = UnityConfig.UnityContainer;//get the Unity container
     unitycontainer.RegisterType<IDbContext, DataModel>(); // register you 'DataModel'
     var dbManager=unitycontainer.Resolve<IDBManager>(); //get the db manager
	
	//DO YOUR CRUD OPERATION //Customer is the table name in DB; 
       //get all the result	
        var result=dbManager.GetRepository<Customer>().Get();  
       
       //Find by id, is the primary key
	var result=dbManager.GetRepository<Customer>().Find(id); 

       // Add, custObj is the Customer object
	var result=dbManager.GetRepository<Customer>().Add(custObj);

       // Delete, custObj is the Customer object
	var result=dbManager.GetRepository<Customer>().Delete(custObj);
     }
```

## Happy Coding

```
### Support or Contact

Having trouble with Pages? Check out our [documentation](https://github.com/AJEETX/EntityFrameworkWrapper/edit/master/README.md) or [contact support](mailto:ajeetkumar@email.com) and we’ll help you sort it out.
```

> [![HitCount](http://hits.dwyl.io/ajeetx/EntityFrameworkWrapper/projects/1.svg)](http://hits.dwyl.io/ajeetx/EntityFrameworkWrapper/projects/1)


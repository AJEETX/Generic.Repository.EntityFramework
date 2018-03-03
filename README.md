# EntityFrameworkWrapper [![.Net Framework](https://img.shields.io/badge/DotNet-4.6.1-blue.svg?style=plastic)](https://www.microsoft.com/en-au/download/details.aspx?id=49981)

> [![Release](https://img.shields.io/badge/release-v1.0.7-blue.svg?style=for-the-badge)](https://www.nuget.org/packages/Generic.Repository.EntityFramework/1.0.7)

> [![Build Status](https://travis-ci.org/AJEETX/EntityFrameworkWrapper.png?branch=master&style=for-the-badge)](https://travis-ci.org/AJEETX/EntityFrameworkWrapper)

> [![dependencies Status](https://img.shields.io/badge/dependency-none-brightgreen.svg?style=plastic)](https://img.shields.io/badge/dependency-none-brightgreen.svg)

### Steps to connect .net application with Sql server database:

>    (https://img.shields.io/badge/EntityFramework-Wrapper-blue.svg)] (https://www.nuget.org/packages/Generic.Repository.EntityFramework/1.0.7) Download the latest nuget package through Visual Studio IDE, 

>   2. Create your EntityFramework DataModel, then tweak the DataModel as below
```
using EntityFrameworkWrapper;       //add this reference

public partial class DB : DbContext, IDbContext   //DB is real data model created from database
    { //IDbContext is inherited from this nuget package
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
using EntityFrameworkWrapper;using Unity;  //add these 2 references
public class ConsumeService
{
     ...
    void ConsumeMethod()
     {
     var unitycontainer = UnityConfig.UnityContainer;//get the Unity container
     unitycontainer.RegisterType<IDbContext, DataModel>(); // register you 'DataModel'
     var dbManager=unitycontainer.Resolve<IDBManager>(); //get the db manager
	//DO YOUR CRUD OPERATION //Customer is the table name in DB; 
       //GET	
        var result=dbManager.GetRepository<Customer>().Get();  
       
       //FIND by id, where id is the primary key
	var result=dbManager.GetRepository<Customer>().Find(id); 

       // ADD, custObj is the Customer object
	var result=dbManager.GetRepository<Customer>().Add(custObj);

       // DELETE, custObj is the Customer object
	var result=dbManager.GetRepository<Customer>().Delete(custObj);
     }
```

### Support or Contact

Having any trouble? Check out our [documentation](https://github.com/AJEETX/EntityFrameworkWrapper/blob/master/README.md) or [contact support](mailto:ajeetkumar@email.com) and we’ll help you sort it out.

>[![Downloads](https://img.shields.io/badge/downloads-1K-blue.svg?style=plastic)](https://www.nuget.org/stats/packages/Generic.Repository.EntityFramework?groupby=Version)

> [![HitCount](http://hits.dwyl.io/ajeetx/EntityFrameworkWrapper/projects/1.svg)](http://hits.dwyl.io/ajeetx/EntityFrameworkWrapper/projects/1)


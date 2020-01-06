# Generic.Repository.EntityFramework ![GitHub release](https://img.shields.io/github/release/ajeetx/Generic.Repository.EntityFramework.svg?style=for-the-badge) ![Maintenance](https://img.shields.io/maintenance/yes/2020.svg?style=for-the-badge)
| ![GitHub Release Date](https://img.shields.io/github/release-date/ajeetx/Generic.Repository.EntityFramework.svg?style=plastic) | ![Website](https://img.shields.io/website-stable-offline-green-red/http/ajeetx.github.io/Generic.Repository.EntityFramework.svg?label=status&style=plastic)| [![azy MyGet Build Status](https://www.myget.org/BuildSource/Badge/azy?identifier=2b65bd31-4a27-42f8-9d25-2615bbaaedae)](https://www.myget.org/)|[![Build Status](https://travis-ci.org/AJEETX/Generic.Repository.EntityFramework.png?branch=master&style=for-the-badge)](https://travis-ci.org/AJEETX/Generic.Repository.EntityFramework) 
|  --- | ---     | ---   | --- |

[![.Net Framework](https://img.shields.io/badge/DotNet-4.6.1-blue.svg?style=plastic)](https://www.microsoft.com/en-au/download/details.aspx?id=49981) | ![GitHub language count](https://img.shields.io/github/languages/count/ajeetx/Generic.Repository.EntityFramework.svg?style=plastic)| ![GitHub top language](https://img.shields.io/github/languages/top/ajeetx/Generic.Repository.EntityFramework.svg) |![GitHub repo size in bytes](https://img.shields.io/github/repo-size/ajeetx/Generic.Repository.EntityFramework.svg) 
| ---          | ---        | ---      | ---        | 



## Purpose of statement 
```
In order to perform database CRUD operation from .net application, 
the wrapper makes it quite easy by following the below steps.
```


#### Steps to use the  [![NuGet](https://img.shields.io/nuget/v/Generic.Repository.EntityFramework.svg)](https://www.nuget.org/packages/Generic.Repository.EntityFramework) package 

 In VS2015 or above, Create .net application [**.net4.6.1**] to interact with Sql server database

 >  1. Search nuget package with name **'Generic.Repository.EntityFramework'**.
 >  2. Download the  [![NuGet](https://img.shields.io/nuget/v/Generic.Repository.EntityFramework.svg)](https://www.nuget.org/packages/Generic.Repository.EntityFramework)  through VS IDE  to install in your project.
>   2. Create your EntityFramework DataModel, then tweak the DataModel as below

IDbContext type is inherited from the installed   [![NuGet](https://img.shields.io/nuget/v/Generic.Repository.EntityFramework.svg)](https://www.nuget.org/packages/Generic.Repository.EntityFramework) package
```
using Generic.Repository.EntityFramework;       //add this reference
//DB is real data model created from database
public partial class DB : DbContext, IDbContext   
{ 
  public DB() : base("name=connectionstring"){} 
  IDbSet<T> IDbContext.Set<T>()
  {
  	return base.Set<T>();
  }
  public DbSet<Customer> Customers {get;set;}
  public int Save()
  {
  	return base.SaveChanges();
  }
  ....
}
```
>   3.	Now all set, please add the below lines from your consuming object/component

```
//add these 2 references
using Generic.Repository.EntityFramework;
using Unity;  

public class ConsumeService
{
     ...
    void ConsumeMethod()
    {           
           var container = UnityConfig.Container; //get the Unity container
             
           container.RegisterType<IDbContext, DB>(); // register your 'DataModel'
     
           var dbManager=container.Resolve<IDBManager>(); //get the db manager
     
	      //All wired up. DO YOUR CRUD OPERATION  & Customer is the table name in DB 
         
         var result=dbManager.GetRepository<Customer>().Get();  //GET	All
       
         //FIND by id, where id is the primary key
	     var result=dbManager.GetRepository<Customer>().Find(id); 

         // custObj is the Customer object
	     var result=dbManager.GetRepository<Customer>().Add(custObj); //ADD

	     var result=dbManager.GetRepository<Customer>().Update(custObj); // UPDATE

 	     var result=dbManager.GetRepository<Customer>().Delete(custObj); // DELETE
     }
```

#### Application list and details

| App Name| Type | Comments|
| --- | --- | --- |
| Generic.Repository.EntityFramework*| Class Library | EntityFramework wrapping business logic|
| Generic.Repository.EntityFramework.Test| Test App |unit tests |
| Generic.Repository.EntityFramework.ConsoleApp.Test | Console   |Test the  wrapping business logic |

> *nuget package **"Generic.Repository.EntityFramework"** is a wrapper around ORM  EntityFramework

<hr />

### Support or Contact

Having any trouble? Check out our [documentation](https://github.com/AJEETX/Generic.Repository.EntityFramework/blob/master/README.md) or [contact support](mailto:ajeetkumar@email.com) and we’ll help you sort it out.

|![GitHub (Pre-)Release Date](https://img.shields.io/github/release-date-pre/ajeetx/Generic.Repository.EntityFramework.svg?label=pre-release) | ![Github commits (since latest release)](https://img.shields.io/github/commits-since/ajeetx/Generic.Repository.EntityFramework/latest.svg)| [![Downloads](https://img.shields.io/nuget/dt/Generic.Repository.EntityFramework.svg?label=nuget-download&style=flat-square)](https://www.nuget.org/stats/packages/Generic.Repository.EntityFramework?groupby=Version) | [![Downloads](https://img.shields.io/myget/ajeetx/dt/Generic.Repository.EntityFramework.svg?style=flat-square&label=myget-download)](https://www.myget.org/feed/azy/package/nuget/Generic.Repository.EntityFramework)|
| ---  | ---  | ---  | ---    |

 [![HitCount](http://hits.dwyl.io/ajeetx/Generic.Repository.EntityFramework/projects/1.svg)](http://hits.dwyl.io/ajeetx/Generic.Repository.EntityFramework/projects/1) | ![GitHub contributors](https://img.shields.io/github/contributors/ajeetx/Generic.Repository.EntityFramework.svg?style=plastic)|![license](https://img.shields.io/github/license/ajeetx/Generic.Repository.EntityFramework.svg?style=plastic)|
 | --- | --- | ---|

# EntityFrameworkWrapper ![GitHub release](https://img.shields.io/github/release/ajeetx/EntityFrameworkWrapper.svg?style=for-the-badge)![Maintenance](https://img.shields.io/maintenance/yes/2018.svg?style=for-the-badge)
| ![GitHub Release Date](https://img.shields.io/github/release-date/ajeetx/EntityFrameworkWrapper.svg?style=plastic) | ![Website](https://img.shields.io/website-stable-offline-green-red/http/ajeetx.github.io/EntityFrameworkWrapper.svg?label=status&style=plastic)|[![Build Status](https://travis-ci.org/AJEETX/EntityFrameworkWrapper.png?branch=master&style=for-the-badge)](https://travis-ci.org/AJEETX/EntityFrameworkWrapper)
|  --- | ---     | ---   |

[![.Net Framework](https://img.shields.io/badge/DotNet-4.6.1-blue.svg?style=plastic)](https://www.microsoft.com/en-au/download/details.aspx?id=49981) | ![GitHub language count](https://img.shields.io/github/languages/count/ajeetx/EntityFrameworkWrapper.svg?style=plastic)| ![GitHub top language](https://img.shields.io/github/languages/top/ajeetx/EntityFrameworkWrapper.svg) |![GitHub repo size in bytes](https://img.shields.io/github/repo-size/ajeetx/EntityFrameworkWrapper.svg) 
| ---          | ---        | ---      | ---        | 



## Purpose of statement 
```
In order to perform database CRUD operation from .net application, 
the wrapper makes it quite easy by following the below steps.
```

#### Application list and details

| App Name| Type | Comments|
| --- | --- | --- |
| EntityFrameworkWrapper| Class Library | EntityFramework wrapping business logic|
| EntityFrameworkWrapper.Test| Test App |unit tests |
| ConsoleApp | Console  |Can be as startup project|

> note: The nuget package **"EntityFrameworkWrapper"** is a wrapper around ORM  EntityFramework

<hr />

#### Steps to use the  ![NuGet](https://img.shields.io/nuget/v/Generic.Repository.EntityFramework.svg) package 

 In VS2015 or above, Create .net application [**.net4.6.1**] to interact with Sql server database

 >  1. Search nuget package with name **'Generic.Repository.EntityFramework'**.
 >  2. Download the ![NuGet](https://img.shields.io/nuget/v/Generic.Repository.EntityFramework.svg)  through VS IDE  to install in your project.
>   2. Create your EntityFramework DataModel, then tweak the DataModel as below

IDbContext type is inherited from the installed  ![NuGet](https://img.shields.io/nuget/v/Generic.Repository.EntityFramework.svg) package
```
using EntityFrameworkWrapper;       //add this reference
//DB is real data model created from database
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
           //get the Unity container
           var unitycontainer = UnityConfig.UnityContainer;
     
           // register your 'DataModel'
           unitycontainer.RegisterType<IDbContext, DataModel>(); 
     
           var dbManager=unitycontainer.Resolve<IDBManager>(); //get the db manager
     
	      //All wired up !!!
          DO YOUR CRUD OPERATION  & Customer is the table name in DB; 
         
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

|![GitHub (Pre-)Release Date](https://img.shields.io/github/release-date-pre/ajeetx/Carz.svg?label=pre-release) | ![Github commits (since latest release)](https://img.shields.io/github/commits-since/ajeetx/carz/latest.svg)| [![Downloads](https://img.shields.io/nuget/dt/Generic.Repository.EntityFramework.svg?label=nuget-download&style=flat-square)](https://www.nuget.org/stats/packages/Generic.Repository.EntityFramework?groupby=Version) | [![Downloads](https://img.shields.io/myget/azy/dt/Generic.Repository.EntityFramework.svg?style=flat-square&label=myget-download)](https://www.myget.org/feed/azy/package/nuget/Generic.Repository.EntityFramework)|
| ---  | ---  | ---  | ---    |

 [![HitCount](http://hits.dwyl.io/ajeetx/EntityFrameworkWrapper/projects/1.svg)](http://hits.dwyl.io/ajeetx/EntityFrameworkWrapper/projects/1) | ![GitHub contributors](https://img.shields.io/github/contributors/ajeetx/EntityFrameworkWrapper.svg?style=plastic)|![license](https://img.shields.io/github/license/ajeetx/EntityFrameworkWrapper.svg?style=plastic)|
 | --- | --- | ---|

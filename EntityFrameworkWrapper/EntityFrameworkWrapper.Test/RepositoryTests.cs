using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper.Tests
{
[TestClass]
    public class RepositoryTest
    {
        private Mock<IDbContext> _IMockCtx;

        private IEnumerable<ClientData> model;
        [TestInitialize]
        public void Init()
        {
            _IMockCtx = new Mock<IDbContext>();
            model =new List<ClientData>{ new ClientData
            {
                ClientId = 10000,
                Id = 999,
                ClientCriterias = new List<ClientCriteria>(){
                    new ClientCriteria{
                         Id=11, Code="NOM", IsSelected=false,ClientDataId=999
                    }
                }
            } };
            SetRepository(model);
        }
        private void SetRepository<T>(IEnumerable<T> data) where T : class
        {
            var dbset = GetIDbset(data);
            _IMockCtx.Setup(m => m.Set<T>()).Returns(dbset);
            _IMockCtx.Setup(m => m.Set<T>().Add(It.IsAny<T>())).Verifiable();
            _IMockCtx.Setup(m => m.Set<T>().Remove(It.IsAny<T>())).Verifiable();
            _IMockCtx.Setup(m => m.SaveChange()).Returns(1);
            _IMockCtx.Setup(m => m.SetEntityStateModified<T>(data.FirstOrDefault()));
        }
        private void StateChange<T>(T data) where T : class
        {
            _IMockCtx.Object.SetEntityStateModified<T>(data);
        }
        private static IDbSet<T> GetIDbset<T>(IEnumerable<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<IDbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(m => m.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.ToList().Add(s)).Returns(() => { return sourceList.Last(); });
            dbSet.Setup(m => m.Attach(It.IsAny<T>())).Callback<T>((s) => sourceList.ToList().Add(s)).Returns(() => { return sourceList.Last(); });
            dbSet.Setup(m => m.Remove(It.IsAny<T>())).Callback<T>((s) => sourceList.ToList().Remove(s)).Returns(() => { return sourceList.Last(); });
            return dbSet.Object;
        }
        [TestMethod]
        public void Get_client_data_from_datastore()
        {
            //Arrange
            var repository = new Repository<ClientData>(_IMockCtx.Object);

            //Act
            var result = repository.Get();

            //Assert
            Assert.IsInstanceOfType(result, typeof(IQueryable<ClientData>));
            _IMockCtx.Verify(v => v.Set<ClientData>(), Times.Once);
        }

        [TestMethod]
        public void Add_client_data_to_datastore_successful()
        {
            //Arrange
            var repository = new Repository<ClientData>(_IMockCtx.Object);
            var data = model.FirstOrDefault();
            //Act
            repository.Add(data);

            //Assert
            _IMockCtx.Verify(v => v.Set<ClientData>().Add(It.IsAny<ClientData>()), Times.Once);
        }

        [TestMethod]
        public void Delete_client_data_from_datastore_successful()
        {
            //Arrange
            var repository = new Repository<ClientData>(_IMockCtx.Object);

            //Act
            repository.Delete(model.FirstOrDefault());

            //Assert
            _IMockCtx.Verify(v => v.Set<ClientData>().Remove(It.IsAny<ClientData>()), Times.Once);
        }
    }}

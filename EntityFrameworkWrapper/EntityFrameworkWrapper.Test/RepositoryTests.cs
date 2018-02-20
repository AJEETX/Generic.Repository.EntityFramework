using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;

namespace EntityFrameworkWrapper.Tests
{
    public class InputModel { public int Id { get; set; } public string Name { get; set; } }
    [TestClass]
    public class RepositoryTest
    {
        private Mock<IDbContext> _IMockCtx;

        private IEnumerable<InputModel> model;
        [TestInitialize]
        public void Init()
        {
            _IMockCtx = new Mock<IDbContext>();
            model = new List<InputModel>{ new InputModel {
                Name = "Test Name",
                Id = 999}
                };
            SetRepository(model);
        }
        private void SetRepository<T>(IEnumerable<T> data) where T : class
        {
            var dbset = GetIDbset(data);
            _IMockCtx.Setup(m => m.Set<T>()).Returns(dbset);
            _IMockCtx.Setup(m => m.Set<T>().Add(It.IsAny<T>())).Verifiable();
            _IMockCtx.Setup(m => m.Set<T>().Remove(It.IsAny<T>())).Verifiable();
            _IMockCtx.Setup(m => m.Save()).Returns(1);
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
            var repository = new Repository<InputModel>(_IMockCtx.Object);

            //Act
            var result = repository.Get();

            //Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<InputModel>));
            _IMockCtx.Verify(v => v.Set<InputModel>(), Times.Once);
        }

        [TestMethod]
        public void Add_client_data_to_datastore_successful()
        {
            //Arrange
            var repository = new Repository<InputModel>(_IMockCtx.Object);
            var data = model.FirstOrDefault();
            //Act
            repository.Add(data);

            //Assert
            _IMockCtx.Verify(v => v.Set<InputModel>().Add(It.IsAny<InputModel>()), Times.Once);
        }

        [TestMethod]
        public void Delete_client_data_from_datastore_successful()
        {
            //Arrange
            var repository = new Repository<InputModel>(_IMockCtx.Object);

            //Act
            repository.Delete(new InputModel { });

            //Assert
            _IMockCtx.Verify(v => v.Set<InputModel>().Remove(It.IsAny<InputModel>()), Times.Once);
        }
    }
}

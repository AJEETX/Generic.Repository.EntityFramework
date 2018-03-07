using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Data.Entity;

namespace Generic.Repository.EntityFramework.Tests
{
    public class InputModel { public int Id { get; set; } public string Name { get; set; } }
    [TestClass]
    public class RepositoryTest
    {
        private Mock<IDbContext> _IMockCtx; private IEnumerable<InputModel> model;
        [TestInitialize]
        public void Init()
        {
            model = new List<InputModel>{ new InputModel { Name = "Test Name", Id = 999} };
            SetRepository(model);
        }
        [TestCleanup]
        public void CleanUp()
        {
            _IMockCtx = null;model = null;
        }
        private void SetRepository<T>(IEnumerable<T> data) where T : class
        {
            var dbSet = new Mock<IDbSet<T>>();
            _IMockCtx = new Mock<IDbContext>();
            _IMockCtx.Setup(m => m.Set<T>()).Returns(dbSet.Object);
            _IMockCtx.Setup(m => m.Set<T>().Add(It.IsAny<T>())).Verifiable();
            _IMockCtx.Setup(m => m.Set<T>().Remove(It.IsAny<T>())).Verifiable();
            _IMockCtx.Setup(m => m.Save()).Returns(1);
        }

        [TestMethod]
        public void Get_data_from_datastore_returns_collection_of_result()
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
        public void Add_data_to_datastore_successful()
        {
            //Arrange
            var repository = new Repository<InputModel>(_IMockCtx.Object);
            var data = model.FirstOrDefault();
            //Act
            repository.Add(data);

            //Assert
            _IMockCtx.Verify(v => v.Set<InputModel>().Add(It.IsAny<InputModel>()), Times.Once);
            _IMockCtx.Verify(v => v.Save(), Times.Once);
        }

        [TestMethod]
        public void Delete_data_from_datastore_successful()
        {
            //Arrange
            var repository = new Repository<InputModel>(_IMockCtx.Object);

            //Act
            repository.Delete(new InputModel { });

            //Assert
            _IMockCtx.Verify(v => v.Save(), Times.Once);
            _IMockCtx.Verify(v => v.Set<InputModel>().Remove(It.IsAny<InputModel>()), Times.Once);
        }
    }
}

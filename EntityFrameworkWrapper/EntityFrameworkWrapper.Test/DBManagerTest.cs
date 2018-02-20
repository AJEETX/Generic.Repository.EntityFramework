using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EntityFrameworkWrapper.Test
{
    [TestClass]
    public class UnitTestDBManager
    {
        public class InputModel { public int Id { get; set; } public string Name { get; set; } }

        [TestMethod]
        public void TestMethod_GetRepository_returns_the_type_requested_repository()
        {
            //Arrange
            var _IMockIDbcontext = new Mock<IDbContext>();
            var transationManager = new DBManager(_IMockIDbcontext.Object);

            //Act
            var result = transationManager.GetRepository<InputModel>();

            //Assert
            Assert.IsInstanceOfType(result, typeof(IRepository<InputModel>));
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestMethod_Save_returns_point_integer_on_succesfull_operation()
        {
            //Arrange
            var input = new InputModel { Id = 1, Name = "Azy" };
            var _IMockIDbcontext = new Mock<IDbContext>();
            _IMockIDbcontext.Setup(m => m.Save()).Returns(1);
            _IMockIDbcontext.Setup(m => m.Set<InputModel>().Add(It.IsAny<InputModel>())).Returns(input);
            var moqDbSet = new Mock<IDbSet<InputModel>>();
            _IMockIDbcontext.Setup(m => m.Set<InputModel>()).Returns(moqDbSet.Object);
            var transationManager = new DBManager(_IMockIDbcontext.Object);

            //Act
            transationManager.GetRepository<InputModel>().Add(input);

            //Assert
            _IMockIDbcontext.Verify(v => v.Save(), Times.Once);

        }
    }
}

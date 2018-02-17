using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityFrameworkWrapper.Test
{
    [TestClass]
    public class UnitTestDBManager
    {
        [TestMethod]
        public void TestMethod_GetRepository_returns_the_type_requested_repository()
        {
            //Arrange
            _IMockIDbcontext = new Mock<IDbContext>();
            var transationManager = new DBManager(_IMockIDbcontext.Object);

            //Act
            var result = transationManager.CreateRepository<InputModel>();

            //Assert
            Assert.IsInstanceOfType(result, typeof(IRepository<InputModel>));
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestMethod_Save_returns_point_integer_on_succesfull_operation()
        {
            //Arrange
            _IMockIDbcontext = new Mock<IDbContext>();
            _IMockIDbcontext.Setup(m => m.SaveChange()).Returns(1);
            var transationManager = new DBManager(_IMockIDbcontext.Object);

            //Act
            var result = transationManager.Save();

            //Assert
            Assert.IsInstanceOfType(result, typeof(int));
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 1);
            _IMockIDbcontext.Verify(v => v.SaveChange(), Times.Once);
        
        }
    }
}

//using System;
//using System.Threading.Tasks;
//using EntityFrameworkWrapper.Tests;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;

//namespace EntityFrameworkWrapper.Test
//{
//    [TestClass]
//    public class UnitTestDBManager
//    {
//        [TestMethod]
//        public void TestMethod_GetRepository_returns_the_type_requested_repository()
//        {
//            //Arrange
//            var _IMockIDbcontext = new Mock<IDbContext>();
//            var transationManager = new DBManager(_IMockIDbcontext.Object);

//            //Act
//            var result = transationManager.GetRepository<InputModel>();

//            //Assert
//            Assert.IsInstanceOfType(result, typeof(IRepository<InputModel>));
//            Assert.IsNotNull(result);
//        }
//        [TestMethod]
//        public void TestMethod_Save_returns_point_integer_on_succesfull_operation()
//        {
//            //Arrange
//            var _IMockIDbcontext = new Mock<IDbContext>();
//            _IMockIDbcontext.Setup(m => m.SaveAsync()).ReturnsAsync(1);
//            var transationManager = new DBManager(_IMockIDbcontext.Object);

//            //Act
//            var result = transationManager.SaveAsync();

//            //Assert
//            Assert.IsInstanceOfType(result, typeof(Task<int>));
//            Assert.IsNotNull(result);
//            Assert.AreEqual(result.Result, 1);
//            _IMockIDbcontext.Verify(v => v.SaveAsync(), Times.Once);

//        }
//    }
//}

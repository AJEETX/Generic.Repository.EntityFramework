using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Generic.Repository.EntityFramework.Test
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
    }
}

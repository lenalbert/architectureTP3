using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using TP3.Controllers;

namespace TP3.Tests.Controllers
{
    [TestClass]
    public class DoctorsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            DoctorsController controller = new DoctorsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            DoctorsController controller = new DoctorsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow(6)]
        public void Edit(int? id)
        {
            // Arrange
            DoctorsController controller = new DoctorsController();

            // Act
            ViewResult result = controller.Edit(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow(6)]
        public void Delete(int? id)
        {
            // Arrange
            DoctorsController controller = new DoctorsController();

            // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3;
using TP3.Controllers;

namespace TP3.Tests.Controllers
{
    [TestClass]
    public class EquipmentsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            EquipmentsController controller = new EquipmentsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            EquipmentsController controller = new EquipmentsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow(1)]
        public void Edit(int? id)
        {
            // Arrange
            EquipmentsController controller = new EquipmentsController();

            // Act
            ViewResult result = controller.Edit(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow(1)]
        public void Delete(int? id)
        {
            // Arrange
            EquipmentsController controller = new EquipmentsController();

            // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

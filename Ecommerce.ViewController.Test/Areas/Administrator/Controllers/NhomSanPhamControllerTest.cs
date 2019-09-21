using Ecommerce.Areas.Administrator.Controllers;
using Ecommerce.Business.IBus;
using Ecommerce.Common.Struct;
using Ecommerce.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ecommerce.ViewController.Test.Areas.Administrator.Controllers
{
    [TestClass]
    public class NhomSanPhamControllerTest
    {
        private Mock<IPhanQuyenBusiness> phanQuyenBusinessMock;
        private Mock<INhomSanPhamBusiness> nhomSanPhamBusinessMock;
        private NhomSanPhamController controller;

        [TestInitialize]
        public void Initialize()
        {
            phanQuyenBusinessMock = new Mock<IPhanQuyenBusiness>();
            nhomSanPhamBusinessMock = new Mock<INhomSanPhamBusiness>();
            controller = new NhomSanPhamController(phanQuyenBusinessMock.Object, nhomSanPhamBusinessMock.Object);
        }

        [TestMethod]
        public void Create_SignedIn_ReturnView()
        {
            //Arrange
            NhomSanPhamViewModel viewModel = new NhomSanPhamViewModel();

            //Action
            nhomSanPhamBusinessMock.Setup(m => m.InitInsert()).Returns(viewModel);
            ViewResult view = controller.Create() as ViewResult;

            //Assert
            Assert.AreEqual("", view.ViewName);
            Assert.IsTrue(ReferenceEquals(viewModel, view.Model));
        }

        [TestMethod]
        public void Create_Saved_ReturnJson()
        {
            //Arrange
            ResultHandle result = new ResultHandle();
            NhomSanPhamViewModel viewModel = It.IsAny<NhomSanPhamViewModel>();

            //Action
            nhomSanPhamBusinessMock.Setup(m => m.Insert(viewModel)).Returns(result);
            JsonResult json = controller.Create(viewModel);

            //Assert
            Assert.IsTrue(ReferenceEquals(result, json.Data));
            Assert.AreEqual(JsonRequestBehavior.AllowGet, json.JsonRequestBehavior);
        }
    }
}

using Ecommerce.Business.BUS;
using Ecommerce.Common.Struct;
using Ecommerce.DataLayer.IRepositories;
using Ecommerce.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Test.Bus
{
    [TestClass]
    public class NhomSanPhamBusinessTest
    {
        private Mock<IUnitOfWork> unitOfWorkMock;
        private Mock<INhomSanPhamRepository> nhomSanPhamRepositoryMock;
        private Mock<IThuocTinhRepository> thuocTinhRepositoryMock;
        private NhomSanPhamBusiness business;

        [TestInitialize]
        public void Initialize()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            nhomSanPhamRepositoryMock = new Mock<INhomSanPhamRepository>();
            thuocTinhRepositoryMock = new Mock<IThuocTinhRepository>();
            business = new NhomSanPhamBusiness(unitOfWorkMock.Object);
        }

        [TestMethod]
        public void Insert_MaEmpty_ReturnInvalidInput()
        {
            //Arrange
            int expectedResult = CommonCode.InvalidInput;
            NhomSanPhamViewModel viewModel = new NhomSanPhamViewModel()
            {
                MaNhomSanPham = string.Empty,
                TenNhomSanPham = "Tin học",
            };

            //Action
            ResultHandle result = business.Insert(viewModel);

            //Arrange
            Assert.AreEqual(expectedResult, result.Number);
        }

        [TestMethod]
        public void Insert_TenEmpty_ReturnInvalidInput()
        {
            //Arrange
            int expectedResult = CommonCode.InvalidInput;
            NhomSanPhamViewModel viewModel = new NhomSanPhamViewModel()
            {
                MaNhomSanPham = "TINHOC",
                TenNhomSanPham = string.Empty,
            };

            //Action
            ResultHandle result = business.Insert(viewModel);

            //Arrange
            Assert.AreEqual(expectedResult, result.Number);
        }

        [TestMethod]
        public void Insert_Successful_Return0()
        {
            //Arrange
            ResultHandle expectedResult = new ResultHandle()
            {
                Number = 0,
            };
            NhomSanPhamViewModel viewModel = new NhomSanPhamViewModel()
            {
                MaNhomSanPham = "TINHOC",
                TenNhomSanPham = "Tin học",
            };
            unitOfWorkMock.SetupGet(m => m.NhomSanPhamRepository).Returns(nhomSanPhamRepositoryMock.Object);
            unitOfWorkMock.SetupGet(m => m.ThuocTinhRepository).Returns(thuocTinhRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m.Save()).Returns(expectedResult);

            //Action
            ResultHandle result = business.Insert(viewModel);

            //Arrange
            Assert.AreEqual(expectedResult.Number, result.Number);
        }

        [TestMethod]
        public void Insert_Unsuccessful_ReturnNot0()
        {
            //Arrange
            ResultHandle expectedResult = new ResultHandle()
            {
                Number = 1,
            };
            NhomSanPhamViewModel viewModel = new NhomSanPhamViewModel()
            {
                MaNhomSanPham = "TINHOC",
                TenNhomSanPham = "Tin học",
            };
            unitOfWorkMock.SetupGet(m => m.NhomSanPhamRepository).Returns(nhomSanPhamRepositoryMock.Object);
            unitOfWorkMock.SetupGet(m => m.ThuocTinhRepository).Returns(thuocTinhRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m.Save()).Returns(expectedResult);

            //Action
            ResultHandle result = business.Insert(viewModel);

            //Arrange
            Assert.AreEqual(expectedResult.Number, result.Number);
        }
    }
}

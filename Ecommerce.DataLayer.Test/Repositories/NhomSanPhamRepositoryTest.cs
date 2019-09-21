using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataLayer.Test.Repositories
{
    [TestClass]
    public class NhomSanPhamRepositoryTest
    {
        private EcommerceEntities context;
        private NhomSanPhamRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            context = new EcommerceEntities();
            repository = new NhomSanPhamRepository(context);
        }

        [TestMethod]
        public void Insert_MaExisted_Return0()
        {
            using (DbContextTransaction transaction = context.Database.BeginTransaction())
            {
                //Arrange
                NhomSanPham entity = new NhomSanPham()
                {
                    MaNhomSanPham = "SACH",
                    TenNhomSanPham = "Sách",
                };
                int actualResult = 0;

                //Action
                try
                {
                    repository.Insert(entity);
                    actualResult = context.SaveChanges();
                }
                catch { }

                //Asert
                Assert.AreEqual(0, actualResult);

                transaction.Rollback();
            }
        }

        [TestMethod]
        public void Insert_Successful_Return1()
        {
            using (DbContextTransaction transaction = context.Database.BeginTransaction())
            {
                //Arrange
                NhomSanPham entity = new NhomSanPham()
                {
                    MaNhomSanPham = "TINHOC",
                    TenNhomSanPham = "Tin học",
                };
                int actualResult = 0;

                //Action
                try
                {
                    repository.Insert(entity);
                    actualResult = context.SaveChanges();
                }
                catch { }

                //Asert
                Assert.AreEqual(1, actualResult);

                transaction.Rollback();
            }
        }

        [TestMethod]
        public void Update_IdNotFound_Return0()
        {
            using (DbContextTransaction transaction = context.Database.BeginTransaction())
            {
                //Arrange
                NhomSanPham entity = new NhomSanPham()
                {
                    ID = 0,
                    MaNhomSanPham = "TINHOC",
                    TenNhomSanPham = "Tin học",
                };
                int actualResult = 0;

                //Action
                try
                {
                    repository.Update(entity);
                    actualResult = context.SaveChanges();
                }
                catch { }

                //Asert
                Assert.AreEqual(0, actualResult);

                transaction.Rollback();
            }
        }

        [TestMethod]
        public void Update_Successful_Return1()
        {
            using (DbContextTransaction transaction = context.Database.BeginTransaction())
            {
                //Arrange
                NhomSanPham entity = new NhomSanPham()
                {
                    ID = 1,
                    MaNhomSanPham = "TINHOC",
                    TenNhomSanPham = "Tin học",
                };
                int actualResult = 0;

                //Action
                try
                {
                    repository.Update(entity);
                    actualResult = context.SaveChanges();
                }
                catch { }

                //Asert
                Assert.AreEqual(1, actualResult);

                transaction.Rollback();
            }
        }

        [TestMethod]
        public void Delete_IdNotFound_Return0()
        {
            using (DbContextTransaction transaction = context.Database.BeginTransaction())
            {
                //Arrange
                int id = 0;
                int actualResult = 0;

                //Action
                try
                {
                    repository.Delete(id);
                    actualResult = context.SaveChanges();
                }
                catch { }

                //Asert
                Assert.AreEqual(0, actualResult);

                transaction.Rollback();
            }
        }

        [TestMethod]
        public void Delete_Successful_Return1()
        {
            using (DbContextTransaction transaction = context.Database.BeginTransaction())
            {
                //Arrange
                int id = 11;
                int actualResult = 0;

                //Action
                try
                {
                    repository.Delete(id);
                    actualResult = context.SaveChanges();
                }
                catch { }

                //Asert
                Assert.AreEqual(1, actualResult);

                transaction.Rollback();
            }
        }
    }
}

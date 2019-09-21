using Ecommerce.Common.Struct;
using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.IRepositories;
using Ecommerce.DataLayer.Repositories;
using System;
using System.Data.Entity.Infrastructure;

namespace Ecommerce.Business
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EcommerceEntities context;

        private IDonHangRepository donHangRepository;
        public IDonHangRepository DonHangRepository
        {
            get
            {
                donHangRepository = donHangRepository ?? new DonHangRepository(context);
                return donHangRepository;
            }
        }

        public IHinhThucThanhToanRepository hinhThucThanhToanRepository;
        public IHinhThucThanhToanRepository HinhThucThanhToanRepository
        {
            get
            {
                hinhThucThanhToanRepository = hinhThucThanhToanRepository ?? new HinhThucThanhToanRepository(context);
                return hinhThucThanhToanRepository;
            }
        }

        public INhomSanPhamRepository nhomSanPhamRepository;
        public INhomSanPhamRepository NhomSanPhamRepository
        {
            get
            {
                nhomSanPhamRepository = nhomSanPhamRepository ?? new NhomSanPhamRepository(context);
                return nhomSanPhamRepository;
            }
        }

        private IPhanQuyenRepository phanQuyenRepository;
        public IPhanQuyenRepository PhanQuyenRepository
        {
            get
            {
                phanQuyenRepository = phanQuyenRepository ?? new PhanQuyenRepository(context);
                return phanQuyenRepository;
            }
        }

        private ISanPhamRepository sanPhamRepository;
        public ISanPhamRepository SanPhamRepository
        {
            get
            {
                sanPhamRepository = sanPhamRepository ?? new SanPhamRepository(context);
                return sanPhamRepository;
            }
        }

        private ITaiKhoanRepository taiKhoanRepository;
        public ITaiKhoanRepository TaiKhoanRepository
        {
            get
            {
                taiKhoanRepository = taiKhoanRepository ?? new TaiKhoanRepository(context);
                return taiKhoanRepository;
            }
        }

        private IThuocTinhRepository thuocTinhRepository;
        public IThuocTinhRepository ThuocTinhRepository
        {
            get
            {
                thuocTinhRepository = thuocTinhRepository ?? new ThuocTinhRepository(context);
                return thuocTinhRepository;
            }
        }

        public UnitOfWork()
        {
            context = new EcommerceEntities();
        }

        public ResultHandle Save()
        {
            ResultHandle result = new ResultHandle();
            try { context.SaveChanges(); }
            catch (DbUpdateException ex) { result = new ResultHandle(ex); }
            catch (Exception ex) { result = new ResultHandle(69, ex.Message); }
            return result;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

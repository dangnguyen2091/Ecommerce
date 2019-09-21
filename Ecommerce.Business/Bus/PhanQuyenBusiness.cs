using Ecommerce.Business.IBus;
using Ecommerce.DataLayer.Context;
using Ecommerce.ViewModel;

namespace Ecommerce.Business.BUS
{
    public class PhanQuyenBusiness : Business<PhanQuyenViewModel, PhanQuyenViewModel>, IPhanQuyenBusiness
    {
        public PhanQuyenBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public bool KiemTraPhanQuyen(int nhomNguoiDungId, string controller, string action)
        {
            if (controller == "Home") { return true; }
            PhanQuyen entity = unitOfWork.PhanQuyenRepository.Find(
                filter: p => p.NhomNguoiDungID == nhomNguoiDungId && p.ChucNang.MaChucNang == controller,
                includeProperties: "ChucNang");
            if (entity == null) { return false; }
            switch (action.ToLower())
            {
                case "create":
                    return entity.Them == null ? false : entity.Them.Value;
                case "update":
                    return entity.Sua == null ? false : entity.Sua.Value;
                case "delete":
                    return entity.Xoa == null ? false : entity.Xoa.Value;
                default:
                    return true;
            }
        }

        public void GetPhanQuyen(int nhomNguoiDungId, string controller, out bool them, out bool sua, out bool xoa)
        {
            them = sua = xoa = false;
            PhanQuyen entity = unitOfWork.PhanQuyenRepository.Find(
                filter: p => p.NhomNguoiDungID == nhomNguoiDungId && p.ChucNang.MaChucNang == controller,
                includeProperties: "ChucNang");
            if (entity != null)
            {
                them = entity.Them == null ? false : entity.Them.Value;
                sua = entity.Sua == null ? false : entity.Sua.Value;
                xoa = entity.Xoa == null ? false : entity.Xoa.Value;
            }
        }
    }
}

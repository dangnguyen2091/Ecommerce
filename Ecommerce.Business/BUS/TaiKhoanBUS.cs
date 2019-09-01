using Ecommerce.Common.Struct;
using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.DAO;
using Ecommerce.ViewModel;

namespace Ecommerce.Business.BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanViewModel Cast(TaiKhoan taiKhoan)
        {
            TaiKhoanViewModel taiKhoanViewModel = new TaiKhoanViewModel()
            {
                NhanVienID = taiKhoan.NhanVien.ID,
                MaNhanVien = taiKhoan.NhanVien.MaNhanVien,
                TenNhanVien = taiKhoan.NhanVien.TenNhanVien,
                NhomNguoiDungID = taiKhoan.NhanVien.NhomNguoiDungID,
                TenDangNhap = taiKhoan.TenDangNhap
            };
            return taiKhoanViewModel;
        }

        private string Validate(DangNhapViewModel viewModel)
        {
            string error = "";
            if (string.IsNullOrEmpty(viewModel.TenDangNhap))
                error += "Tên đăng nhập không được rỗng\n";
            if (string.IsNullOrEmpty(viewModel.MatKhau))
                error += "Mật khẩu không được rỗng\n";
            return error;
        }

        public ResultHandle KiemTraDangNhap(DangNhapViewModel viewModel)
        {
            string validation = Validate(viewModel);
            if (!string.IsNullOrEmpty(validation))
            {
                return ResultHandle.InvalidInput(validation);
            }
            ResultHandle result = new ResultHandle();
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            TaiKhoan taiKhoan = taiKhoanDAO.KiemTraDangNhap(viewModel.TenDangNhap, viewModel.MatKhau);
            if (taiKhoan == null)
            {
                result.Number = CommonCode.DataNotExists;
                result.Message = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
            }
            else
            {
                TaiKhoanViewModel taiKhoanViewModel = Cast(taiKhoan);
                result.Outputs.Add("TaiKhoanDangNhap", taiKhoanViewModel);
            }
            return result;
        }
    }
}

using Ecommerce.Business.IBus;
using Ecommerce.Common.Struct;
using Ecommerce.DataLayer.Context;
using Ecommerce.ViewModel;

namespace Ecommerce.Business.BUS
{
    public class TaiKhoanBusiness : Business<TaiKhoanViewModel, TaiKhoanViewModel>, ITaiKhoanBusiness
    {
        public TaiKhoanBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

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
            TaiKhoan taiKhoan = unitOfWork.TaiKhoanRepository.Find(
                filter: e => e.TenDangNhap == viewModel.TenDangNhap && e.MatKhau == viewModel.MatKhau);
            if (taiKhoan == null)
            {
                result.Number = CommonCode.DataNotExists;
                result.Message = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
            }
            else
            {
                TaiKhoanViewModel taiKhoanViewModel = new TaiKhoanViewModel();
                taiKhoanViewModel.BindEntity(taiKhoan);
                result.Outputs.Add("TaiKhoanDangNhap", taiKhoanViewModel);
            }
            return result;
        }
    }
}

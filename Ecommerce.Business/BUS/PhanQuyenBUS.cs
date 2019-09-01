using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.BUS
{
    public class PhanQuyenBUS
    {
        public bool KiemTraPhanQuyen(int nhomNguoiDungId, string controller, string action)
        {
            if (controller == "Home") { return true; }
            PhanQuyenDAO dao = new PhanQuyenDAO();
            PhanQuyen entity = dao.GetPhanQuyen(nhomNguoiDungId, controller);
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
            PhanQuyenDAO dao = new PhanQuyenDAO();
            PhanQuyen entity = dao.GetPhanQuyen(nhomNguoiDungId, controller);
            if (entity != null)
            {
                them = entity.Them == null ? false : entity.Them.Value;
                sua = entity.Sua == null ? false : entity.Sua.Value;
                xoa = entity.Xoa == null ? false : entity.Xoa.Value;
            }
        }
    }
}

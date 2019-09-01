using Ecommerce.Common.Struct;
using Ecommerce.Common.Utilities;
using Ecommerce.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataLayer.DAO
{
    public class NhomSanPhamDAO
    {
        public ResultHandle Insert(NhomSanPham entity)
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                db.NhomSanPham.Add(entity);
                ResultHandle result = db.Save();
                return result;
            }
        }

        public ResultHandle Update(NhomSanPham entity)
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                NhomSanPham dbEntity = db.NhomSanPham.Find(entity.ID);
                if (dbEntity == null)
                {
                    return ResultHandle.DataNotExist();
                }
                db.ThuocTinh.RemoveRange(dbEntity.ThuocTinhs);
                db.Entry(dbEntity).CurrentValues.SetValues(entity);
                db.ThuocTinh.AddRange(entity.ThuocTinhs);
                ResultHandle result = db.Save();
                return result;
            }
        }

        public ResultHandle Delete(int id)
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                NhomSanPham dbEntity = db.NhomSanPham.Find(id);
                if (dbEntity == null)
                {
                    return ResultHandle.DataNotExist();
                }
                db.ThuocTinh.RemoveRange(dbEntity.ThuocTinhs);
                db.NhomSanPham.Remove(dbEntity);
                ResultHandle result = db.Save();
                return result;
            }
        }

        public List<NhomSanPham> GetAll()
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                List<NhomSanPham> list = new List<NhomSanPham>();
                list = db.NhomSanPham.Include("NhomSanPham2").ToList();
                return list;
            }
        }

        public NhomSanPham GetById(int id)
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                NhomSanPham dbEntity = db.NhomSanPham
                    .Include("NhomSanPham2")
                    .Include("ThuocTinhs")
                    .FirstOrDefault(e => e.ID == id);
                return dbEntity;
            }
        }
    }
}

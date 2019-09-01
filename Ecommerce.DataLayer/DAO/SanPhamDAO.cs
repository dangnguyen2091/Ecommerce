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
    public class SanPhamDAO
    {
        public ResultHandle Insert(SanPham entity)
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                db.SanPham.Add(entity);
                ResultHandle result = db.Save();
                return result;
            }
        }

        public ResultHandle Update(SanPham entity)
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                SanPham dbEntity = db.SanPham.Find(entity.ID);
                if (dbEntity == null)
                {
                    return ResultHandle.DataNotExist();
                }
                db.Entry(dbEntity).CurrentValues.SetValues(entity);
                ResultHandle result = db.Save();
                return result;
            }
        }

        public ResultHandle Delete(int id)
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                SanPham dbEntity = db.SanPham.Find(id);
                if (dbEntity == null)
                {
                    return ResultHandle.DataNotExist();
                }
                db.SanPham.Remove(dbEntity);
                ResultHandle result = db.Save();
                return result;
            }
        }

        public List<SanPham> GetAll()
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                List<SanPham> list = new List<SanPham>();
                list = db.SanPham.Include("NhomSanPham").ToList();
                return list;
            }
        }

        public SanPham GetById(int id)
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                SanPham dbEntity = db.SanPham.Include("NhomSanPham").FirstOrDefault(e => e.ID == id);
                return dbEntity;
            }
        }
    }
}

using Ecommerce.Common.Struct;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Ecommerce.Common.Utilities
{
    public static class DbContextHelper
    {
        public static ResultHandle Save(this DbContext db)
        {
            ResultHandle result = new ResultHandle();
            try { db.SaveChanges(); }
            catch (DbUpdateException ex) { result = new ResultHandle(ex); }
            catch (Exception ex) { result = new ResultHandle(69, ex.Message); }
            return result;
        }
    }
}

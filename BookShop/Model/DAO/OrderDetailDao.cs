using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class OrderDetailDao
    {
        BookStoreDbContext db = null;

        public OrderDetailDao()
        {
            db = new BookStoreDbContext();
        }

        // thêm chi tiết đơn hàng
        public bool Insert(ChiTietDH detail)
        {
            try
            {
                db.ChiTietDHs.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

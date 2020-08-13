using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.DAO
{
    public class ProductCategoryDao
    {
        BookStoreDbContext db = null;

        public ProductCategoryDao()
        {
            db = new BookStoreDbContext();
        }

        public List<DanhMucSP> ListAll()
        {
            return db.DanhMucSPs.OrderBy(x => x.MaDM).ToList();
        }

        public DanhMucSP ViewDetail(long id)
        {
            return db.DanhMucSPs.Find(id);
        }
    }
}

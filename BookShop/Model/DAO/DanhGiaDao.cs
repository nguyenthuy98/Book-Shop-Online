using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class DanhGiaDao
    {
        BookStoreDbContext db = null;

        public DanhGiaDao()
        {
            db = new BookStoreDbContext();
        }
        public IEnumerable<DanhGia> ListAllPaging(int page, int pageSize)
        {
            return db.DanhGias.OrderBy(x => x.MaDanhGia).ToPagedList(page, pageSize);
        }
    }
}

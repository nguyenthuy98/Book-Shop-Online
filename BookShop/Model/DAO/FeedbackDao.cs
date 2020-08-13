using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class FeedbackDao
    {
        BookStoreDbContext db = null;

        public FeedbackDao()
        {
            db = new BookStoreDbContext();
        }

        public IEnumerable<DanhGia> ListAllPaging(int page, int pageSize)
        {
            return db.DanhGias.OrderBy(x => x.MaDanhGia).ToPagedList(page, pageSize);
        }

        public long Insert(DanhGia entity)
        {
            db.DanhGias.Add(entity);
            db.SaveChanges();
            return entity.MaDanhGia;
        }
    }
}

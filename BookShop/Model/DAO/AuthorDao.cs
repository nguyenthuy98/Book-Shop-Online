using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class AuthorDao
    {
        BookStoreDbContext db = null;

        public AuthorDao()
        {
            db = new BookStoreDbContext();
        }

        // Insert
        public long Insert(TacGia entity)
        {
            db.TacGias.Add(entity);
            db.SaveChanges();
            return entity.MaTG;
        }

        // update
        public bool Update(TacGia entity)
        {
            try
            {
                var xb = db.TacGias.Find(entity.MaTG);
                xb.MaTG = entity.MaTG;
                xb.TenTG = entity.TenTG;
                xb.MoTa = entity.MoTa;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public TacGia ViewDetail(int id)
        {
            return db.TacGias.Find(id);
        }

        // pagedlist
        public IEnumerable<TacGia> ListAllPaging(int page, int pageSize)
        {
            return db.TacGias.OrderBy(x => x.MaTG).ToPagedList(page, pageSize);
        }

        // delete
        public bool Delete(int id)
        {
            try
            {
                var xb = db.TacGias.Find(id);
                db.TacGias.Remove(xb);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<TacGia> ListAll()
        {
            return db.TacGias.OrderBy(x => x.MaTG).ToList();
        }
    }
}

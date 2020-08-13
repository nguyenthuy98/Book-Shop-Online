using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class NewsDao
    {
        BookStoreDbContext db = null;

        public NewsDao()
        {
            db = new BookStoreDbContext();
        }
        // admin
        // Insert
        public long Insert(TinTuc entity)
        {
            db.TinTucs.Add(entity);
            db.SaveChanges();
            return entity.MaTinTuc;
        }

        // update
        public bool Update(TinTuc entity)
        {
            try
            {
                var tt = db.TinTucs.Find(entity.MaTinTuc);
                tt.TieuDe = entity.TieuDe;
                tt.NoiDung = entity.NoiDung;
                tt.NgayTao = entity.NgayTao;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public TinTuc ViewDetail(long id)
        {
            return db.TinTucs.Find(id);
        }


        // pagedlist
        public IEnumerable<TinTuc> ListAllPaging(int page, int pageSize)
        {
            return db.TinTucs.OrderBy(x => x.MaTinTuc).ToPagedList(page, pageSize);
        }

        // delete
        public bool Delete(int id)
        {
            try
            {
                var user = db.TinTucs.Find(id);
                db.TinTucs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // client
        public List<TinTuc> ListAll()
        {
            return db.TinTucs.OrderBy(x => x.MaTinTuc).ToList();
        }

        // tin tức liên quan
        public List<TinTuc> ListSameNews(long newId)
        {
            var tt = db.TinTucs.Find(newId);
            return db.TinTucs.Where(x => x.MaTinTuc != newId).ToList();
        }


    }
}

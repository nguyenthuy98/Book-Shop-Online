using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class PublisherDao
    {
        BookStoreDbContext db = null;

        public PublisherDao()
        {
            db = new BookStoreDbContext();
        }

        // Insert
        public long Insert(NhaXB entity)
        {
            db.NhaXBs.Add(entity);
            db.SaveChanges();
            return entity.MaNXB;
        }

        // update
        public bool Update(NhaXB entity)
        {
            try
            {
                var xb = db.NhaXBs.Find(entity.MaNXB);
                xb.MaNXB = entity.MaNXB;
                xb.TenNXB = entity.TenNXB;
                xb.MoTa = entity.MoTa;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public NhaXB ViewDetail(int id)
        {
            return db.NhaXBs.Find(id);
        }

        // pagedlist
        public IEnumerable<NhaXB> ListAllPaging(int page, int pageSize)
        {
            return db.NhaXBs.OrderBy(x => x.MaNXB).ToPagedList(page, pageSize);
        }

        // delete
        public bool Delete(int id)
        {
            try
            {
                var xb = db.NhaXBs.Find(id);
                db.NhaXBs.Remove(xb);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<NhaXB> ListAll()
        {
            return db.NhaXBs.OrderBy(x => x.MaNXB).ToList();
        }
    }
}

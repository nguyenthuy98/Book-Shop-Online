using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class CategoryDao
    {
        BookStoreDbContext db = null;

        public CategoryDao()
        {
            db = new BookStoreDbContext();
        }

        // Insert
        public long Insert(DanhMucSP entity)
        {
            db.DanhMucSPs.Add(entity);
            db.SaveChanges();
            return entity.MaDM;
        }

        // update
        public bool Update(DanhMucSP entity)
        {
            try
            {
                var xb = db.DanhMucSPs.Find(entity.MaDM);
                xb.MaDM = entity.MaDM;
                xb.TenDM = entity.TenDM;
               
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public DanhMucSP ViewDetail(long id)
        {
            return db.DanhMucSPs.Find(id);
        }

        // pagedlist
        public IEnumerable<DanhMucSP> ListAllPaging(int page, int pageSize)
        {
            return db.DanhMucSPs.OrderBy(x => x.MaDM).ToPagedList(page, pageSize);
        }

        // delete
        public bool Delete(int id)
        {
            try
            {
                var xb = db.DanhMucSPs.Find(id);
                db.DanhMucSPs.Remove(xb);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<DanhMucSP> ListAll()
        {
            return db.DanhMucSPs.OrderBy(x => x.MaDM).ToList();
        }
    }
}

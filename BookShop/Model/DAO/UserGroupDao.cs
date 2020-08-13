using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class UserGroupDao
    {
        BookStoreDbContext db = null;

        public UserGroupDao()
        {
            db = new BookStoreDbContext();
        }

        // Insert
        public long Insert(NhomTK entity)
        {
            db.NhomTKs.Add(entity);
            db.SaveChanges();
            return entity.MaNhomTK;
        }

        // update
        public bool Update(NhomTK entity)
        {
            try
            {
                var tt = db.NhomTKs.Find(entity.MaNhomTK);
                tt.MaNhomTK = entity.MaNhomTK;
                tt.TenNhomTK = entity.TenNhomTK;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public NhomTK ViewDetail(int id)
        {
            return db.NhomTKs.Find(id);
        }


        // pagedlist
        public IEnumerable<NhomTK> ListAllPaging(int page, int pageSize)
        {
            return db.NhomTKs.OrderBy(x => x.MaNhomTK).ToPagedList(page, pageSize);
        }

        // delete
        public bool Delete(int id)
        {
            try
            {
                var tk = db.NhomTKs.Find(id);
                db.NhomTKs.Remove(tk);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}

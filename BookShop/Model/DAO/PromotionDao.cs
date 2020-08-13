using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class PromotionDao
    {
        BookStoreDbContext db = null;

        public PromotionDao()
        {
            db = new BookStoreDbContext();
        }

        // Insert
        public long Insert(KhuyenMai entity)
        {
            db.KhuyenMais.Add(entity);
            db.SaveChanges();
            return entity.MaKM;
        }

        // update
        public bool Update(KhuyenMai entity)
        {
            try
            {
                var km = db.KhuyenMais.Find(entity.MaKM);
                km.MaKM = entity.MaKM;
                km.TenKM = entity.TenKM;
                km.MoTa = entity.MoTa;
                km.ChietKhau = entity.ChietKhau;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public KhuyenMai ViewDetail(int id)
        {
            return db.KhuyenMais.Find(id);
        }


        // pagedlist
        public IEnumerable<KhuyenMai> ListAllPaging(int page, int pageSize)
        {
            return db.KhuyenMais.OrderBy(x => x.MaKM).ToPagedList(page, pageSize);
        }

        // delete
        public bool Delete(int id)
        {
            try
            {
                var km = db.KhuyenMais.Find(id);
                db.KhuyenMais.Remove(km);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // client
        public List<KhuyenMai> ListAll()
        {
            return db.KhuyenMais.Where(x => x.MaKM != 1).OrderBy(x => x.MaKM).ToList();
        }

        public List<KhuyenMai> ListAl()
        {
            return db.KhuyenMais.OrderBy(x => x.MaKM).ToList();
        }
    }
}

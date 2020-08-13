using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using Model.ViewModel;

namespace Model.DAO
{
    public class ProductDao
    {
        BookStoreDbContext db = null;
        public ProductDao()
        {
            db = new BookStoreDbContext();
        }
        // admin
        // Insert item
        public long Insert(Sach entity)
        {
            db.Saches.Add(entity);
            db.SaveChanges();
            return entity.MaSach;
        }

        // update item
        public bool Update(Sach entity)
        {
            try
            {
                var sach = db.Saches.Find(entity.MaSach);
                sach.MaSach = entity.MaSach;
                sach.MaTG = entity.MaTG;
                sach.MaDM = entity.MaDM;
                sach.MaKM = entity.MaKM;
                sach.MaNXB = entity.MaNXB;
                sach.TenSach = entity.TenSach;
                sach.NgayPhatHanh = entity.NgayPhatHanh;
                sach.MoTa = entity.MoTa;
                sach.GiaBan = entity.GiaBan;
                sach.SoLuong = entity.SoLuong;
                sach.HinhAnh = entity.HinhAnh;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        // update số lượng
        public bool UpdateQuantity(Sach entity, int soluong)
        {
            try
            {
                var sach = db.Saches.Find(entity.MaSach);
                sach.SoLuong = sach.SoLuong - soluong;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        // pagedlist
        public IEnumerable<Sach> ListAllPaging(int page, int pageSize)
        {
            return db.Saches.OrderBy(x => x.MaSach).ToPagedList(page, pageSize);
        }


        public bool Delete(int id)
        {
            try
            {
                var bo = db.Saches.Find(id);
                db.Saches.Remove(bo);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        // list tất cả sách
        public List<Sach> ListBookByCategoryId(long categoryID)
        {
            return db.Saches.Where(x => x.MaDM == categoryID).OrderBy(x => x.MaSach).ToList();
        }

        // list sách bán chạy
        public List<Sach> ListHotProduct(int hot)
        {
            return db.Saches.Where(x => x.MaDM == 1).OrderBy(x => x.TenSach).Take(hot).ToList();
        }

        // list sách mới phát hành
        public List<Sach> ListNewProduct(int hot)
        {
            return db.Saches.Where(x => x.MaDM == 2).OrderBy(x => x.TenSach).Take(hot).ToList();
        }

        // list tác phẩm kinh điển
        public List<Sach> ListOldProduct(int hot)
        {
            return db.Saches.Where(x => x.MaDM == 10).OrderBy(x => x.TenSach).Take(hot).ToList();
        }

        // list tủ sách doanh nhân
        public List<Sach> ListBussinessProduct(int hot)
        {
            return db.Saches.Where(x => x.MaDM == 9).OrderBy(x => x.TenSach).Take(hot).ToList();
        }

        // view detail
        public Sach ViewDetail(long id)
        {
            return db.Saches.Find(id);
        }
        // sp lien quan
        public List<Sach> ListSameProducts(long productId)
        {
            var product = db.Saches.Find(productId);
            return db.Saches.Where(x => x.MaSach != productId && x.MaDM == product.MaDM).ToList();
        }

        // list name tim kiem sp
        public List<string> ListName(string keyword)
        {
            return db.Saches.Where(x => x.TenSach.Contains(keyword)).Select(x => x.TenSach).ToList();
        }

        // tim kiem sp
        public List<ProductViewModel> Search(string keyword, ref int totalRecord)
        {
            totalRecord = db.Saches.Where(x => x.TenSach == keyword || x.TacGia.TenTG == keyword || x.NhaXB.TenNXB == keyword).Count();
            var model = (from a in db.Saches
                         join b in db.DanhMucSPs
                         on a.MaDM equals b.MaDM
                         where (a.TenSach.Contains(keyword) || a.TacGia.TenTG.Contains(keyword) || a.NhaXB.TenNXB.Contains(keyword))
                         select new
                         {
                             MaSach = a.MaSach,
                             HinhAnh = a.HinhAnh,
                             TenSach = a.TenSach,
                             GiaBan = a.GiaBan
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             MaSach = x.MaSach,
                             HinhAnh = x.HinhAnh,
                             TenSach = x.TenSach,
                             GiaBan = x.GiaBan
                         });
            model.OrderByDescending(x => x.TenSach);
            return model.ToList();
        }

        // thông tin tác giả
        public Sach AuthorDetail(long id)
        {
            return db.Saches.Find(id);
        }

        // sách cùng tác giả
        public List<Sach> ListSameAuthor(long id)
        {
            var item = db.Saches.Find(id);
            return db.Saches.Where(x => x.MaTG == item.MaTG).ToList();
        }

        // thông tin nhà xuất bản
        public Sach PublisherDetail(long id)
        {
            return db.Saches.Find(id);
        }

        // sách cùng nhà xuất bản
        public List<Sach> ListSamePublisher(long id)
        {
            var item = db.Saches.Find(id);
            return db.Saches.Where(x => x.MaNXB == item.MaNXB).ToList();
        }


    }
}

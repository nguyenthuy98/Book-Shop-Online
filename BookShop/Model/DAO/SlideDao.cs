using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class SlideDao
    {
        BookStoreDbContext db = null;
        public SlideDao()
        {
            db = new BookStoreDbContext();
        }

        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.TrangThai == 1).OrderBy(y => y.TTHienThi).ToList();
        }
        public IEnumerable<Slide> ListAllPaging(int page, int pageSize)
        {
            return db.Slides.OrderBy(x => x.MaSlide).ToPagedList(page, pageSize);
        }
        // Insert
        public long Insert(Slide entity)
        {
            db.Slides.Add(entity);
            db.SaveChanges();
            return entity.MaSlide;
        }

        // update
        public bool Update(Slide entity)
        {
            try
            {
                var xb = db.Slides.Find(entity.MaSlide);
                xb.MaSlide = entity.MaSlide;
                xb.TenSlide = entity.TenSlide;
                xb.HinhAnh = entity.HinhAnh;
                xb.Url = entity.Url;
                xb.TitleID = entity.TitleID;
                xb.TTHienThi = entity.TTHienThi;
                xb.TrangThai = entity.TrangThai;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Slide ViewDetail(int id)
        {
            return db.Slides.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var xb = db.Slides.Find(id);
                db.Slides.Remove(xb);
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

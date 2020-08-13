using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class UserDao
    {
        BookStoreDbContext db = null;

        public UserDao()
        {
            db = new BookStoreDbContext();
        }

        // Insert acc
        public long Insert(TaiKhoan entity)
        {
            db.TaiKhoans.Add(entity);
            db.SaveChanges();
            return entity.MaTK;
        }

        // update acc
        public bool Update(TaiKhoan entity)
        {
            try
            {
                var user = db.TaiKhoans.Find(entity.MaTK);
                user.MaNhomTK = entity.MaNhomTK;
                user.TenTK = entity.TenTK;
                user.MatKhau = entity.MatKhau;
                user.HoTen = entity.HoTen;
                user.DiaChi = entity.DiaChi;
                user.NgaySinh = entity.NgaySinh;
                user.Email = entity.Email;
                user.SDT = entity.SDT;
                user.AnhDaiDien = entity.AnhDaiDien;
                user.NgayTao = entity.NgayTao;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // chi tiết tài khoản
        public TaiKhoan ViewDetail(long id)
        {
            return db.TaiKhoans.Find(id);
        }

        // pagedlist
        public IEnumerable<TaiKhoan> ListAllPaging(int page, int pageSize)
        {
            return db.TaiKhoans.OrderBy(x => x.MaTK).ToPagedList(page, pageSize);
        }


        
        // get acc
        public TaiKhoan GetByUserName(string userName)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.TenTK == userName);
        }
        // login
        public int Login(string userName, string passWord)
        {
            var result = db.TaiKhoans.SingleOrDefault(x => x.TenTK == userName && x.MatKhau == passWord);
            if (result == null)
            {
                return 0;
            }            
            else
            {
                return 1;
            }
        }

        // delete
        public bool Delete(int id)
        {
            try
            {
                var user = db.TaiKhoans.Find(id);
                db.TaiKhoans.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        // client
        public bool CheckUserName(string userName)
        {
            return db.TaiKhoans.Count(x => x.TenTK == userName) > 0;
        }

    }
}

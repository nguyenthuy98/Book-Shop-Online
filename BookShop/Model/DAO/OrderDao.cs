using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class OrderDao
    {
        BookStoreDbContext db = null;

        public OrderDao()
        {
            db = new BookStoreDbContext();
        }

        public DonHang ViewDetail(long id)
        {
            return db.DonHangs.Find(id);
        }
        // pagedlist
        public IEnumerable<DonHang> ListAllPaging(int page, int pageSize)
        {
            return db.DonHangs.OrderBy(x => x.MaDH).ToPagedList(page, pageSize);
        }

        // list order for month
        public List<DonHang> ListMonth(int month)
        {
            return db.DonHangs.Where(x => x.NgayDatHang.Month == month).ToList();
        }
        // update item
        public bool Update(DonHang entity)
        {
            try
            {
                var sach = db.DonHangs.Find(entity.MaDH);
                sach.MaDH = entity.MaDH;
                sach.MaTK = entity.MaTK;
                sach.NguoiDat = entity.NguoiDat;
                sach.NguoiNhan = entity.NguoiNhan;
                sach.NgayDatHang = entity.NgayDatHang;
                sach.DiaChiNguoiNhan = entity.DiaChiNguoiNhan;
                sach.SDTNguoiNhan = entity.SDTNguoiNhan;
                sach.TongTien = entity.TongTien;
                sach.TrangThai = entity.TrangThai;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        // delete
        public bool Delete(int id)
        {
            try
            {
                var dh = db.DonHangs.Find(id);
                db.DonHangs.Remove(dh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // thêm đơn hàng
        public long Insert(DonHang order)
        {
            db.DonHangs.Add(order);
            db.SaveChanges();
            return order.MaDH;
        }

        // get đơn hàng
        public List<DonHang> GetOrderByID(long userID)
        {
            return db.DonHangs.Where(x => x.MaTK == userID).OrderBy(x => x.MaDH).ToList();
        }

        // update trạng thái đơn hàng
        public bool UpdateStatus(DonHang entity, int trangthai)
        {
            try
            {
                var dh = db.DonHangs.Find(entity.MaDH);
                dh.TrangThai = trangthai;
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

using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopOnline.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // get order by id
        public ActionResult GetOrder(long id)
        {
            var model = new OrderDao().GetOrderByID(id);
            return View(model);
        }

        // get chi tiết đơn hàng
        public ActionResult GetOrderDetail(long id)
        {
            var model = new OrderDao().ViewDetail(id);
            return View(model);
        }
        //[HttpPost]
        //public ActionResult ConfirmOrder(long matk, string nguoidat, string nguoinhan, DateTime ngaydat, string diachi, string sdt, int tongtien)
        //{
        //    var od = new DonHang();
        //    od.MaTK = matk;
        //    od.NguoiDat = nguoidat;
        //    od.NguoiNhan = nguoinhan;
        //    od.NgayDatHang = ngaydat;
        //    od.DiaChiNguoiNhan = diachi;
        //    od.SDTNguoiNhan = sdt;
        //    od.TongTien = tongtien;
        //    od.TrangThai = 3;
        //    var th = new OrderDao();
        //    var result = th.UpdateStatus(od, 3);
        //    if (result == true)
        //    {
        //        return Redirect("Order/GetOrder");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Không thành công");
        //    }
        //    return Redirect("Order/GetOrder");
        //}
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var od = new OrderDao().ViewDetail(id);
            return View(od);
        }

        [HttpPost]
        public ActionResult Edit(DonHang tt)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDao();
                var result = dao.Update(tt);
                if (result)
                {
                    return RedirectToAction("GetOrder", "Order",new { id = tt.MaTK });
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông tin sản phẩm không thành công");
                }
            }
            return RedirectToAction("GetOrder", "Order", new {id = tt.MaTK });
        }
    }
}
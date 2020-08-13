using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopOnline.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        BookStoreDbContext db = new BookStoreDbContext();
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new OrderDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        // GET: Admin/Order/Details/
        public ActionResult Details(int id)
        {
            var order = new OrderDao().ViewDetail(id);
            return View(order);
        }

        // detail month
        public ActionResult DetailsMonth(int month)
        {
            var order = new OrderDao();
            var model = order.ListMonth(month);
            return View(model);
        }
        // edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var order = new OrderDao().ViewDetail(id);
            return View(order);
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
                    SetAlert("Cập nhật đơn hàng thành công", "success");
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật đơn hàng không thành công");
                }
            }
            return View("Index");
        }
        // delete
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            DonHang s = db.DonHangs.Where(x => x.MaDH == id).SingleOrDefault();
            if (s != null)
            {
                new OrderDao().Delete(id);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}

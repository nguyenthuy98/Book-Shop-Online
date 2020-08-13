using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookShopOnline.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        BookStoreDbContext db = new BookStoreDbContext();

        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        // Create
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao1 = new AuthorDao();
            ViewBag.MaTG = new SelectList(dao1.ListAll(), "MaTG", "TenTG", selectedId);
            var dao2 = new CategoryDao();
            ViewBag.MaDM = new SelectList(dao2.ListAll(), "MaDM", "TenDM", selectedId);
            var dao3 = new PublisherDao();
            ViewBag.MaNXB = new SelectList(dao3.ListAll(), "MaNXB", "TenNXB", selectedId);
            var dao4 = new PromotionDao();
            ViewBag.MaKM = new SelectList(dao4.ListAl(), "MaKM", "MaKM", selectedId);

        }
        [HttpPost]
        public ActionResult Create(Sach tt)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long id = dao.Insert(tt);
                if (id > 0)
                {
                    SetAlert("Thêm sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm không thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }

        // edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetViewBag();
            var sach = new ProductDao().ViewDetail(id);
            return View(sach);
        }

        [HttpPost]
        public ActionResult Edit(Sach tt)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(tt);
                if (result)
                {
                    SetAlert("Cập nhật thông tin sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông tin sản phẩm không thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }

        // delete
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            ChiTietDH ct = db.ChiTietDHs.Where(x => x.MaSach == id).SingleOrDefault();
            if(ct == null)
            {
                Sach s = db.Saches.Where(x => x.MaSach == id).SingleOrDefault();
                if (s != null)
                {
                    new ProductDao().Delete(id);
                    db.SaveChanges();
                    result = true;
                }
            }            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
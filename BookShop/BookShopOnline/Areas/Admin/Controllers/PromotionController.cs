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
    public class PromotionController : BaseController
    {
        // GET: Admin/User
        BookStoreDbContext db = new BookStoreDbContext();
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new PromotionDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        // Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(KhuyenMai tt)
        {
            if (ModelState.IsValid)
            {
                var dao = new PromotionDao();
                long id = dao.Insert(tt);
                if (id > 0)
                {
                    SetAlert("Thêm khuyến mại thành công", "success");
                    return RedirectToAction("Index", "Promotion");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm khuyến mại không thành công");
                }
            }
            return View("Index");
        }

        // edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var xb = new PromotionDao().ViewDetail(id);
            return View(xb);
        }

        [HttpPost]
        public ActionResult Edit(KhuyenMai km)
        {
            if (ModelState.IsValid)
            {
                var dao = new PromotionDao();
                var result = dao.Update(km);
                if (result)
                {
                    SetAlert("Sửa thông tin khuyến mại thành công", "success");
                    return RedirectToAction("Index", "Promotion");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông tin khuyến mại không thành công");
                }
            }
            return View("Index");
        }

        // delete acc
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            Sach ct = db.Saches.Where(x => x.MaKM == id).FirstOrDefault();
            if (ct == null)
            {
                KhuyenMai s = db.KhuyenMais.Where(x => x.MaKM == id).SingleOrDefault();
                if (s != null)
                {
                    new PromotionDao().Delete(id);
                    db.SaveChanges();
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopOnline.Areas.Admin.Controllers
{
    public class SlideController : BaseController
    {
        // GET: Admin/Slide
        BookStoreDbContext db = new BookStoreDbContext();

        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new SlideDao();
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
        public ActionResult Create(Slide tt)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDao();
                long id = dao.Insert(tt);
                if (id > 0)
                {
                    SetAlert("Thêm slide thành công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm slide không thành công");
                }
            }
            return View("Index");
        }

        // edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var xb = new SlideDao().ViewDetail(id);
            return View(xb);
        }

        [HttpPost]
        public ActionResult Edit(Slide xb)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDao();
                var result = dao.Update(xb);
                if (result)
                {
                    SetAlert("Sửa thông tin slide thành công!", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật slide không thành công!");
                }
            }
            return View("Index");
        }

        // delete acc
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;

            Slide s = db.Slides.Where(x => x.MaSlide == id).SingleOrDefault();
            if (s != null)
            {
                new SlideDao().Delete(id);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
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
    public class NewsController : BaseController
    {
        // GET: Admin/User
        BookStoreDbContext db = new BookStoreDbContext();
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new NewsDao();
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
        public ActionResult Create(TinTuc tt)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
                long id = dao.Insert(tt);
                if (id > 0)
                {
                    SetAlert("Thêm tin tức thành công", "success");
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tin tức không thành công");
                }
            }
            return View("Index");
        }

        // edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new NewsDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(TinTuc tt)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
                var result = dao.Update(tt);
                if (result)
                {
                    SetAlert("Sửa tin tức thành công", "success");
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tin tức không thành công");
                }
            }
            return View("Index");
        }

        // delete acc
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            
                TinTuc s = db.TinTucs.Where(x => x.MaTinTuc == id).SingleOrDefault();
                if (s != null)
                {
                    new NewsDao().Delete(id);
                    db.SaveChanges();
                    result = true;
                }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
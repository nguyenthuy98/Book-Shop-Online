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
    public class AuthorController : BaseController
    {
        // GET: Admin/User
        BookStoreDbContext db = new BookStoreDbContext();

        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new AuthorDao();
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
        public ActionResult Create(TacGia tt)
        {
            if (ModelState.IsValid)
            {
                var dao = new AuthorDao();
                long id = dao.Insert(tt);
                if (id > 0)
                {
                    SetAlert("Thêm tác giả thành công", "success");
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tác giả không thành công");
                }
            }
            return View("Index");
        }

        // edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var xb = new AuthorDao().ViewDetail(id);
            return View(xb);
        }

        [HttpPost]
        public ActionResult Edit(TacGia xb)
        {
            if (ModelState.IsValid)
            {
                var dao = new AuthorDao();
                var result = dao.Update(xb);
                if (result)
                {
                    SetAlert("Sửa thông tin tác giả thành công", "success");
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông tin tác giả không thành công");
                }
            }
            return View("Index");
        }

        // delete acc
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            Sach ct = db.Saches.Where(x => x.MaTG == id).FirstOrDefault();
            if (ct == null)
            {
                TacGia s = db.TacGias.Where(x => x.MaTG == id).FirstOrDefault();
                if (s != null)
                {
                    new AuthorDao().Delete(id);
                    db.SaveChanges();
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
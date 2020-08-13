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
    public class PublisherController : BaseController
    {
        // GET: Admin/User
        BookStoreDbContext db = new BookStoreDbContext();
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new PublisherDao();
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
        public ActionResult Create(NhaXB tt)
        {
            if (ModelState.IsValid)
            {
                var dao = new PublisherDao();
                long id = dao.Insert(tt);
                if (id > 0)
                {
                    SetAlert("Thêm nhà xuất bản thành công", "success");
                    return RedirectToAction("Index", "Publisher");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm nhà xuất bản không thành công");
                }
            }
            return View("Index");
        }

        // edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var xb = new PublisherDao().ViewDetail(id);
            return View(xb);
        }

        [HttpPost]
        public ActionResult Edit(NhaXB xb)
        {
            if (ModelState.IsValid)
            {
                var dao = new PublisherDao();
                var result = dao.Update(xb);
                if (result)
                {
                    SetAlert("Sửa thông tin nhà xuất bản thành công", "success");
                    return RedirectToAction("Index", "Publisher");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông tin nhà xuất bản không thành công");
                }
            }
            return View("Index");
        }

        // delete acc
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            Sach ct = db.Saches.Where(x => x.MaNXB == id).FirstOrDefault();
            if (ct == null)
            {
                NhaXB s = db.NhaXBs.Where(x => x.MaNXB == id).SingleOrDefault();
                if (s != null)
                {
                    new PublisherDao().Delete(id);
                    db.SaveChanges();
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
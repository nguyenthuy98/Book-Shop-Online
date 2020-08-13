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
    public class UserGroupController : BaseController
    {
        // GET: Admin/User
        BookStoreDbContext db = new BookStoreDbContext();
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new UserGroupDao();
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
        public ActionResult Create(NhomTK tt)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserGroupDao();
                long id = dao.Insert(tt);
                if (id > 0)
                {
                    SetAlert("Thêm nhóm user thành công", "success");
                    return RedirectToAction("Index", "UserGroup");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm nhóm tài khoản không thành công");
                }
            }
            return View("Index");
        }

        // edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tk = new UserGroupDao().ViewDetail(id);
            return View(tk);
        }

        [HttpPost]
        public ActionResult Edit(NhomTK tt)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserGroupDao();
                var result = dao.Update(tt);
                if (result)
                {
                    SetAlert("Sửa thông tin nhóm tài khoản thành công", "success");
                    return RedirectToAction("Index", "UserGroup");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật nhóm tài khoản không thành công");
                }
            }
            return View("Index");
        }

        // delete acc
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            TaiKhoan ct = db.TaiKhoans.Where(x => x.MaNhomTK == id).FirstOrDefault();
            if (ct == null)
            {
                NhomTK s = db.NhomTKs.Where(x => x.MaNhomTK == id).SingleOrDefault();
                if (s != null)
                {
                    new UserGroupDao().Delete(id);
                    db.SaveChanges();
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
using BookShopOnline.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using BookShopOnline.Common;
using Model.EF;

namespace BookShopOnline.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                TaiKhoan us = dao.GetByUserName(model.TenTK);
                if (us != null)
                {
                    if (us.MaNhomTK == 1)
                    {
                        var result = dao.Login(model.TenTK, model.MatKhau);
                        if (result == 1)
                        {
                            var user = dao.GetByUserName(model.TenTK);
                            var userSession = new UserLogin();
                            userSession.UserName = user.TenTK;
                            userSession.UserID = user.MaTK;
                            userSession.Image = user.AnhDaiDien;
                            Session.Add(CommonConstants.USER_SESSION, userSession);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.error = "Tên tài khoản hoặc mật khẩu không chính xác!";
                            ModelState.AddModelError("", "Đăng nhập không thành công!");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng nhập không thành công!");
                    }
                }else
                {
                    ModelState.AddModelError("", "Tên đăng nhập không chính xác");
                }
            }
            return View("Index");
        }
    }
}
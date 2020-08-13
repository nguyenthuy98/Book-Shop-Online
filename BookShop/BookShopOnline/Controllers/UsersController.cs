using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShopOnline.Models;
using Model.DAO;
using Model.EF;
using BotDetect.Web.Mvc;
using BookShopOnline.Common;

namespace BookShopOnline.Controllers
{
    public class UsersController : Controller
    {
        // GET: User
        // đăng ký
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "RegisterCaptcha", "Mã captcha không đúng!")]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(model.TenTK))
                {
                    ModelState.AddModelError("", "Tên tài khoản đã tồn tại");
                }
                else
                {
                    var user = new TaiKhoan();
                    user.TenTK = model.TenTK;
                    user.MatKhau = model.MatKhau;
                    user.HoTen = model.HoTen;
                    user.DiaChi = model.DiaChi;
                    user.NgaySinh = model.NgaySinh;
                    user.Email = model.Email;
                    user.MaNhomTK = 2;
                    user.SDT = model.SDT;
                    user.AnhDaiDien = model.AnhDaiDien;
                    user.NgayTao = DateTime.Now;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        return Redirect("/Users/Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }

        // đăng nhập
       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result == 1)
                {
                    var user = dao.GetByUserName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.TenTK;
                    userSession.UserID = user.MaTK;
                    userSession.GroupID = user.MaNhomTK;
                    userSession.Image = user.AnhDaiDien;
                    userSession.Name = user.HoTen;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không đúng.");
                }                              
            }
            return View(model);
        }

        // đăng xuất
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }

        // thông tin tài khoản
        public ActionResult Detail(long id)
        {
            var acc = new UserDao().ViewDetail(id);
            return View(acc);
        }

        // update tài khoản
        [HttpGet]
        public ActionResult Update(long id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Update(TaiKhoan user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Detail", "Users", new { id =  user.MaTK });
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật hồ sơ không thành công!");
                }
            }
            return View(user);
        }

        


    }
}
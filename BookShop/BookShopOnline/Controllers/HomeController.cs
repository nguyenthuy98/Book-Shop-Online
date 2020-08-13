using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using BookShopOnline.Common;
using BookShopOnline.Models;
using Model.EF;

namespace BookShopOnline.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.Slides = new SlideDao().ListAll();
            ViewBag.NewProducts = productDao.ListNewProduct(5);
            ViewBag.HotProducts = productDao.ListHotProduct(5);
            ViewBag.OldProducts = productDao.ListOldProduct(5);
            ViewBag.BussinessProducts = productDao.ListBussinessProduct(5);
            return View();
        }

        // view trang about us
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        // view trang contactus
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        // header cart
        [ChildActionOnly]
        public PartialViewResult Cart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }

        // send feedback
        [HttpPost]
        public ActionResult SendFeedBack(long matk, string tentk, string noidung)
        {
            var fb = new DanhGia();
            fb.MaTK = matk;
            fb.TenTK = tentk;
            fb.NoiDung = noidung;
            fb.NgayDanhGia = DateTime.Now;
            var fback = new FeedbackDao();
            long tc = fback.Insert(fb);
            if (tc > 0)
            {
                return Redirect("Contact");
            }
            else
            {
                ModelState.AddModelError("", "Không thành công");
            }
            return Redirect("Contact");
        }
    }
}
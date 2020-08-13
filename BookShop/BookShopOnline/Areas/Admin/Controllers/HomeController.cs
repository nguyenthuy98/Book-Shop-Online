using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using BookShopOnline.Areas.Admin.Models;

namespace BookShopOnline.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        BookStoreDbContext db = new BookStoreDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            // order in 01/2020
            var start1 = Convert.ToDateTime("01/01/2020");
            var end1 = Convert.ToDateTime("31/01/2020");
            List<DonHang> systems1 = db.DonHangs.Where(c => c.TrangThai == 3 && c.NgayDatHang >= start1 && c.NgayDatHang <= end1).ToList();
            int total1 = 0;
            foreach (var item in systems1)
            {
                total1+=item.TongTien;
            }
            ViewBag.Total1 = total1;
            ViewBag.Counts1 = systems1.Count();

            // order in 02/2020
            var start2 = Convert.ToDateTime("01/02/2020");
            var end2 = Convert.ToDateTime("29/02/2020");
            List<DonHang> systems2 = db.DonHangs.Where(c => c.TrangThai == 3 && c.NgayDatHang >= start2 && c.NgayDatHang <= end2).ToList();
            int total2 = 0;
            foreach (var item in systems2)
            {
                total2 += item.TongTien;
            }
            ViewBag.Total2 = total2;
            ViewBag.Counts2 = systems2.Count();

            // order in 03/2020
            var start3 = Convert.ToDateTime("01/03/2020");
            var end3 = Convert.ToDateTime("31/03/2020");
            List<DonHang> systems3 = db.DonHangs.Where(c => c.TrangThai == 3 && c.NgayDatHang >= start3 && c.NgayDatHang <= end3).ToList();
            int total3 = 0;
            foreach (var item in systems3)
            {
                total3 += item.TongTien;
            }
            ViewBag.Total3 = total3;
            ViewBag.Counts3 = systems3.Count();

            // order in 04/2020
            var start4 = Convert.ToDateTime("01/04/2020");
            var end4 = Convert.ToDateTime("30/04/2020");
            List<DonHang> systems4 = db.DonHangs.Where(c => c.TrangThai == 3 && c.NgayDatHang >= start4 && c.NgayDatHang <= end4).ToList();
            int total4 = 0;
            foreach (var item in systems4)
            {
                total4 += item.TongTien;
            }
            ViewBag.Total4 = total4;
            ViewBag.Counts4 = systems4.Count();

            // order in 05/2020
            var start5 = Convert.ToDateTime("01/05/2020");
            var end5 = Convert.ToDateTime("30/05/2020");
            List<DonHang> systems5 = db.DonHangs.Where(c => c.TrangThai == 3 && c.NgayDatHang >= start5 && c.NgayDatHang <= end5).ToList();
            int total5 = 0;
            foreach (var item in systems5)
            {
                total5 += item.TongTien;
            }
            ViewBag.Total5 = total5;
            ViewBag.Counts5 = systems5.Count();

            return View();
        }                
    }
}
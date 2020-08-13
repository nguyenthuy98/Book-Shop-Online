using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopOnline.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        [HttpGet]
        public ActionResult Index()
        {
            var model = new NewsDao().ListAll();
            return View(model);
        }

        public ActionResult Detail(long id)
        {
            var tt = new NewsDao().ViewDetail(id);
            ViewBag.SameNews = new NewsDao().ListSameNews(id);
            return View(tt);
        }

    }
}
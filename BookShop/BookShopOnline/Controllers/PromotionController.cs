using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopOnline.Controllers
{
    public class PromotionController : Controller
    {
        // GET: Promotion
        [HttpGet]
        public ActionResult Index()
        {
            var model = new PromotionDao().ListAll();
            return View(model);
        }
    }
}
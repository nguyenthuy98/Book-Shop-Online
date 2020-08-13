using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopOnline.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Admin/Feedback
        public ActionResult Index(int page =1, int pageSize=5)
        {
            var dao = new FeedbackDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace BookShopOnline.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // danh muc san pham
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }
        
        // danh mục sp
        public ActionResult Category(long id)
        {
            var category = new CategoryDao().ViewDetail(id);
            ViewBag.Category = category;
            var model = new ProductDao().ListBookByCategoryId(id);
            return View(model);
        }

        // chi tiet san pham
        public ActionResult Detail(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.MaDM);
            ViewBag.SameProducts = new ProductDao().ListSameProducts(id);
            return View(product);
        }

        // data tim kiem autocomplete
        public JsonResult ListName(string q)
        {
            var data = new ProductDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        // tim kiem
        public ActionResult Search(string keyword)
        {
            int totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord);
            ViewBag.Total = totalRecord;
            ViewBag.Keyword = keyword;
            return View(model);
        }

        // get thông tin tác giả
        public ActionResult AuthorDetail(long id)
        {
            var author = new ProductDao().AuthorDetail(id);
            ViewBag.ListSameAuthor = new ProductDao().ListSameAuthor(id);         
            return View(author);
        }

        // get thông tin nhà xuất bản
        public ActionResult PublisherDetail(long id)
        {
            var publisher = new ProductDao().PublisherDetail(id);
            ViewBag.ListSamePublisher = new ProductDao().ListSamePublisher(id);
            return View(publisher);
        }

    }
}
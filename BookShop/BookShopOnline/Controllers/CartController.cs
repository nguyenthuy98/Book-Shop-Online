using BookShopOnline.Models;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Model.EF;
using BookShopOnline.Common;
using System.Configuration;

namespace BookShopOnline.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";

        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        // them vao gio hang
        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Sach.MaSach == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Sach.MaSach == productId)
                        {
                            item.SoLuong += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Sach = product;
                    item.SoLuong = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Sach = product;
                item.SoLuong = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        // xoa tat ca san pham
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        // xoa 1 san pham
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Sach.MaSach == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        // cap nhat gio hang
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Sach.MaSach == item.Sach.MaSach);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        // thanh toán
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(long matk, int tongtien,string nguoidat, string nguoinhan, string diachi, string sdt)
        {
            var order = new DonHang();
            order.NgayDatHang = DateTime.Now;
            order.NguoiDat = nguoidat;
            order.NguoiNhan = nguoinhan;
            order.DiaChiNguoiNhan = diachi;
            order.SDTNguoiNhan = sdt;
            order.TrangThai = 1;
            order.MaTK = matk;
            order.TongTien = tongtien;
            var dataDate = DateTime.Now.ToString();
            try
            {
                var id = new OrderDao().Insert(order);
                var product = new ProductDao();
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new OrderDetailDao();
                decimal total = tongtien;
                foreach (var item in cart)
                {
                    var orderDetail = new ChiTietDH();
                    orderDetail.MaSach = item.Sach.MaSach;
                    orderDetail.MaDH = id;
                    orderDetail.TenSP = item.Sach.TenSach;
                    orderDetail.DonGia = item.Sach.GiaBan;
                    orderDetail.SoLuong = item.SoLuong;
                    detailDao.Insert(orderDetail);
                    Sach book = product.ViewDetail(item.Sach.MaSach);
                    product.UpdateQuantity(book, item.SoLuong);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/template/order.html"));

                content = content.Replace("{{CustomerName}}", nguoidat);
                content = content.Replace("{{Phone}}",sdt );
                content = content.Replace("{{Date}}",dataDate);
                content = content.Replace("{{Address}}", diachi);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);
            }
            catch (Exception)
            {
                //return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }

        // thanh toán thành công
        public ActionResult Success()
        {
            Session[CommonConstants.CartSession] = null;
            return View();
        }

    }
}
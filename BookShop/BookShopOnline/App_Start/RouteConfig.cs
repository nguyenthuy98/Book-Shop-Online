using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookShopOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}",
              new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "Users", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "BookShopOnline.Controllers" }
            );

            routes.MapRoute(
               name: "Home",
               url: "trang-chu",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "BookShopOnline.Controllers" }
           );

            routes.MapRoute(
               name: "Promotion",
               url: "khuyen-mai",
               defaults: new { controller = "Promotion", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "BookShopOnline.Controllers" }
           );

            routes.MapRoute(
               name: "News",
               url: "tin-tuc",
               defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "BookShopOnline.Controllers" }
           );

            routes.MapRoute(
               name: "About",
               url: "ve-chung-toi",
               defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
               namespaces: new[] { "BookShopOnline.Controllers" }
           );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
                namespaces: new[] { "BookShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "BookShopOnline.Controllers" }
            );

            routes.MapRoute(
               name: "Login",
               url: "dang-nhap",
               defaults: new { controller = "Users", action = "Login", id = UrlParameter.Optional },
               namespaces: new[] { "BookShopOnline.Controllers" }
           );

            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "BookShopOnline.Controllers" }
           );

            routes.MapRoute(
              name: "Payment",
              url: "thanh-toan",
              defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
              namespaces: new[] { "BookShopOnline.Controllers" }
          );

            routes.MapRoute(
             name: "Success",
             url: "hoan-thanh",
             defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
             namespaces: new[] { "BookShopOnline.Controllers" }
         );           
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "BookShopOnline.Controllers" }
           );


        }
    }
}


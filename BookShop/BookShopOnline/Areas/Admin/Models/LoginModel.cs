using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShopOnline.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Hãy nhập tên tài khoản")]
        public string TenTK { set; get; }

        [Required(ErrorMessage = "Hãy nhập mật  khẩu")]
        public string MatKhau { set; get; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShopOnline.Models
{
    public class Register
    {
        [Key]
        [Display(Name = "Mã tài khoản")]
        public long MaTK { get; set; }

        [Display(Name = "Mã nhóm tài khoản")]
        public long MaNhomTK { get; set; }

        [Required(ErrorMessage = "* Tên tài khoản không được để trống")]
        [StringLength(50)]
        [Display(Name = "Tên tài khoản")]
        public string TenTK { get; set; }

        [Required(ErrorMessage = "* Mật khẩu không được để trống")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "* Mật khẩu phải có ít nhất 6 ký tự")]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }       

        [Required(ErrorMessage = "* Họ tên không được để trống")]
        [StringLength(100)]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }


        [Required(ErrorMessage = "* Địa chỉ không được để trống")]
        [StringLength(300)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "* Địa chỉ email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Số điện thoại không được để trống")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "* Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(100)]
        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        [Display(Name = "Ngày tạo")]
        public DateTime NgayTao { get; set; }
    }
}
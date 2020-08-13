namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        [Display(Name = "Mã tài khoản")]
        public long MaTK { get; set; }

        [Required(ErrorMessage = "* Hãy nhập nhóm tài khoản")]
        [Display(Name = "Mã nhóm tài khoản")]
        public long MaNhomTK { get; set; }

        [Required(ErrorMessage = "* Hãy nhập tên tài khoản")]
        [StringLength(50)]
        [Display(Name = "Tên tài khoản")]
        public string TenTK { get; set; }

        [Required(ErrorMessage = "* Hãy nhập mật khẩu")]
        [StringLength(20)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "* Hãy nhập họ tên")]
        [StringLength(100)]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "* Hãy nhập địa chỉ")]
        [StringLength(300)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [Required(ErrorMessage = "* Hãy nhập email")]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Hãy nhập số điện thoại")]
        [StringLength(15)]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "* Hãy chọn ảnh đại diện")]
        [StringLength(100)]
        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }

        [Required(ErrorMessage = "* Hãy nhập ngày")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        [Display(Name = "Ngày tạo")]
        public DateTime NgayTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        public virtual NhomTK NhomTK { get; set; }       
    }
}

namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDHs = new HashSet<ChiTietDH>();
        }

        [Key]
        [Display(Name = "Mã đơn hàng")]
        public long MaDH { get; set; }

        [Display(Name = "Mã tài khoản")]
        public long MaTK { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Người đặt")]
        public string NguoiDat { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Người nhận")]
        public string NguoiNhan { get; set; }

        [Required(ErrorMessage = "* Hãy chọn ngày đặt hàng")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày đặt hàng")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NgayDatHang { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [Display(Name = "Địa chỉ người nhận")]
        public string DiaChiNguoiNhan { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Số điện thoại người nhận")]
        public string SDTNguoiNhan { get; set; }

        [Display(Name = "Tổng tiền")]
        public int TongTien { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDH> ChiTietDHs { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}

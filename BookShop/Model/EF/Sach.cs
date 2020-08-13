namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ChiTietDHs = new HashSet<ChiTietDH>();
        }

        [Key]
        [Display(Name = "Mã sách")]
        public long MaSach { get; set; }

        [Required(ErrorMessage = "* Hãy chọn tác giả")]
        [Display(Name = "Tác giả")]
        public long MaTG { get; set; }

        [Required(ErrorMessage = "* Hãy chọn nhà xuất bản")]
        [Display(Name = "Nhà xuất bản")]
        public long MaNXB { get; set; }

        [Required(ErrorMessage = "* Hãy chọn danh mục sản phẩm")]
        [Display(Name = "Danh mục")]
        public long MaDM { get; set; }

        [Required(ErrorMessage = "* Hãy chọn khuyến mại")]
        [Display(Name = "Khuyến mại")]
        public long MaKM { get; set; }

        [Required(ErrorMessage = "* Hãy nhập tên sách")]
        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "Tên sách")]
        public string TenSach { get; set; }

        [Required(ErrorMessage = "* Hãy chọn ngày phát hành")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày phát hành")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NgayPhatHanh { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "* Hãy nhập mô tả")]
        [StringLength(1000, MinimumLength = 20)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Required(ErrorMessage = "* Hãy chọn ảnh đại diện")]
        [StringLength(100)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [Required(ErrorMessage = "* Hãy nhập giá sản phẩm")]
        [DataType(DataType.Currency)]
        [Display(Name = "Giá bán")]
        public int GiaBan { get; set; }

        [Required(ErrorMessage = "* Hãy nhập số lượng sản phẩm")]
        [Range(1, 1000)]
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        public virtual DanhMucSP DanhMucSP { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }

        public virtual NhaXB NhaXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDH> ChiTietDHs { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}

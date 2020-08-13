namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        [Display(Name = "Mã slide")]
        public int MaSlide { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên slide")]
        public string TenSlide { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        [Display(Name = "Đường dẫn")]
        public string Url { get; set; }

        [StringLength(20)]
        [Display(Name = "Title ID")]
        public string TitleID { get; set; }

        [Display(Name ="Thứ tự hiển thị")]
        public int? TTHienThi { get; set; }

        [Display(Name = "Trạng thái")]
        public int? TrangThai { get; set; }

    }
}

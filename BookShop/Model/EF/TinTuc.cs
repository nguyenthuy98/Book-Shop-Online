namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        [Display(Name = "Mã tin tức")]
        public long MaTinTuc { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày tạo")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime NgayTao { get; set; }
    }
}

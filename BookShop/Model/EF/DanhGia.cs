namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGia")]
    public partial class DanhGia
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaDanhGia { get; set; }

        public long MaTK { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTK { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayDanhGia { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}

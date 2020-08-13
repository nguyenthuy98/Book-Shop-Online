namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TacGia")]
    public partial class TacGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TacGia()
        {
            Saches = new HashSet<Sach>();
        }

        [Key]
        [Display(Name = "Mã tác giả")]
        public long MaTG { get; set; }

        [StringLength(150)]
        [Display(Name = "Tên tác giả")]
        [Required(ErrorMessage = "* Hãy nhập tên tác giả")]
        public string TenTG { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "* Hãy nhập mô tả")]
        public string MoTa { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "* Hãy chọn hình ảnh")]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Saches { get; set; }
    }
}

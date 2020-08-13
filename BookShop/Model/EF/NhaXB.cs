namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaXB")]
    public partial class NhaXB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaXB()
        {
            Saches = new HashSet<Sach>();
        }

        [Key]
        [Display(Name = "Mã nhà xuất bản")]
        public long MaNXB { get; set; }

        [Required(ErrorMessage = "* Hãy nhập tên nhà xuất bản")]
        [StringLength(300)]
        [Display(Name = "Tên nhà xuất bản")]
        public string TenNXB { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "* Hãy nhập mô tả")]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Saches { get; set; }
    }
}

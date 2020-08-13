namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuyenMai")]
    public partial class KhuyenMai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhuyenMai()
        {
            Saches = new HashSet<Sach>();
        }

        [Key]
        [Display(Name = "Mã khuyến mãi")]
        public long MaKM { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên khuyến mại")]
        public string TenKM { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Chiết khấu")]
        public int ChietKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Saches { get; set; }
    }
}


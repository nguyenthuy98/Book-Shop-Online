namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomTK")]
    public partial class NhomTK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhomTK()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        [Key]
        [Display(Name = "Mã nhóm tài khoản")]
        public long MaNhomTK { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên nhóm tài khoản")]
        public string TenNhomTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}

namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext()
            : base("name=BookStore")
        {
        }

        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<DanhMucSP> DanhMucSPs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<NhaXB> NhaXBs { get; set; }
        public virtual DbSet<NhomTK> NhomTKs { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<ChiTietDH> ChiTietDHs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhGia>()
                .Property(e => e.TenTK)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.SDTNguoiNhan)
                .IsUnicode(false);

            //modelBuilder.Entity<KhuyenMai>()
            //    .HasMany(e => e.Saches)
            //    .WithOptional(e => e.KhuyenMai);

            modelBuilder.Entity<Sach>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.TenSlide)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenTK)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.AnhDaiDien)
                .IsUnicode(false);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }
        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey("MaDh");
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh=>dh.NguoiNhan).IsRequired().HasMaxLength(255);
            });
            modelBuilder.Entity<DonHangChiTiet>(e =>
            {
                e.ToTable("ChiTietDonHang");
                e.HasKey(e => new { e.MaDh, e.MaHh });
                e.HasOne(e => e.DonHang).WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaDh)
                .HasConstraintName("FK_DonHangCT_DonHang");

                e.HasOne(e => e.HangHoa)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaHh)
                .HasConstraintName("FK_DonHangCT_HangHoa");
            });
        }
    }
}

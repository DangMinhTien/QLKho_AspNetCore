using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QLKHO.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ChiTietPhieuXuat> chiTietPhieuXuats { get; set; } 
        public DbSet<PhieuXuat> phieuXuats { get; set; } 
        public DbSet<ChiTietPhieuNhap> chiTietPhieuNhaps { get; set; }
        public DbSet<PhieuNhap> phieuNhaps { get; set; }
        public DbSet<KhachHang> khachHangs { get; set; }
        public DbSet<ChiTietNhaCungCap> chiTietNhaCungCaps { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<NhaCungCap> nhaCungCaps { get; set; }
        public DbSet<DonViTinh> donViTinhs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
            modelBuilder.Entity<ChiTietNhaCungCap>()
                .HasKey(d => new { d.MaNcc, d.MaSp });

            modelBuilder.Entity<ChiTietPhieuNhap>()
                .HasKey(d => new { d.MaPN, d.MaSp });

            modelBuilder.Entity<ChiTietPhieuXuat>()
                .HasKey(d => new { d.MaPX, d.MaSp });
        }
    }
}

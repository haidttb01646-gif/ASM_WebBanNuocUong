using Microsoft.EntityFrameworkCore;
using ASM_WebBanNuocUong.Models;

namespace ASM_WebBanNuocUong.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<NguoiDung> NguoiDungs { get; set; }
    public DbSet<SanPham> SanPhams { get; set; }
    public DbSet<DanhMuc> DanhMucs { get; set; }
    public DbSet<DonHang> DonHangs { get; set; }
    public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
    public DbSet<Combo> Combos { get; set; }
    public DbSet<ChiTietCombo> ChiTietCombos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        // ========== CẤU HÌNH PRECISION CHO DECIMAL FIELDS ==========
        modelBuilder.Entity<SanPham>().Property(p => p.Gia).HasPrecision(18, 2);
        modelBuilder.Entity<Combo>().Property(c => c.Gia).HasPrecision(18, 2);
        modelBuilder.Entity<ChiTietDonHang>().Property(od => od.Gia).HasPrecision(18, 2);
        modelBuilder.Entity<DonHang>().Property(dh => dh.TongTien).HasPrecision(18, 2);
        
        // ========== CẤU HÌNH QUAN HỆ GIỮA CÁC BẢNG ==========
        
        // DanhMuc ↔ SanPham (1-n)
        modelBuilder.Entity<SanPham>()
            .HasOne(sp => sp.DanhMuc)
            .WithMany(dm => dm.DanhSachSanPham)
            .HasForeignKey(sp => sp.MaDanhMuc)
            .OnDelete(DeleteBehavior.Restrict);
        
        // SanPham ↔ ChiTietCombo (1-n)
        modelBuilder.Entity<ChiTietCombo>()
            .HasOne(ctc => ctc.SanPham)
            .WithMany(sp => sp.DanhSachChiTietCombo)
            .HasForeignKey(ctc => ctc.MaSanPham)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Combo ↔ ChiTietCombo (1-n)
        modelBuilder.Entity<ChiTietCombo>()
            .HasOne(ctc => ctc.Combo)
            .WithMany(c => c.DanhSachChiTietCombo)
            .HasForeignKey(ctc => ctc.MaCombo)
            .OnDelete(DeleteBehavior.Cascade);
        
        // NguoiDung ↔ DonHang (1-n)
        modelBuilder.Entity<DonHang>()
            .HasOne(dh => dh.NguoiDung)
            .WithMany(nd => nd.DanhSachDonHang)
            .HasForeignKey(dh => dh.MaNguoiDung)
            .OnDelete(DeleteBehavior.Restrict);
        
        // DonHang ↔ ChiTietDonHang (1-n)
        modelBuilder.Entity<ChiTietDonHang>()
            .HasOne(ctdh => ctdh.DonHang)
            .WithMany(dh => dh.DanhSachChiTiet)
            .HasForeignKey(ctdh => ctdh.MaDonHang)
            .OnDelete(DeleteBehavior.Cascade);
        
        // SanPham ↔ ChiTietDonHang (1-n)
        modelBuilder.Entity<ChiTietDonHang>()
            .HasOne(ctdh => ctdh.SanPham)
            .WithMany(sp => sp.DanhSachChiTietDonHang)
            .HasForeignKey(ctdh => ctdh.MaSanPham)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Combo ↔ ChiTietDonHang (1-n)
        modelBuilder.Entity<ChiTietDonHang>()
            .HasOne(ctdh => ctdh.Combo)
            .WithMany(c => c.DanhSachChiTietDonHang)
            .HasForeignKey(ctdh => ctdh.MaCombo)
            .OnDelete(DeleteBehavior.Restrict);
        
        // ========== RÀNG BUỘC LOGIC CHO ChiTietDonHang ==========
        // Chỉ được có MaSanPham HOẶC MaCombo, không được có cả hai
        modelBuilder.Entity<ChiTietDonHang>()
            .HasCheckConstraint("CK_ChiTietDonHang_SanPhamOrCombo", 
                "([MaSanPham] IS NOT NULL AND [MaCombo] IS NULL) OR ([MaSanPham] IS NULL AND [MaCombo] IS NOT NULL)");
        
        // LoaiSanPham phải khớp với loại thực tế
        modelBuilder.Entity<ChiTietDonHang>()
            .HasCheckConstraint("CK_ChiTietDonHang_LoaiSanPham", 
                "(LoaiSanPham = 'SanPham' AND MaSanPham IS NOT NULL) OR " +
                "(LoaiSanPham = 'Combo' AND MaCombo IS NOT NULL)");
        
        // ========== CẤU HÌNH GIÁ TRỊ MẶC ĐỊNH ==========
        
        // Giá trị mặc định cho trạng thái
        modelBuilder.Entity<SanPham>()
            .Property(sp => sp.TrangThai)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<DanhMuc>()
            .Property(dm => dm.TrangThai)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Combo>()
            .Property(c => c.TrangThai)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<NguoiDung>()
            .Property(nd => nd.TrangThai)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<NguoiDung>()
            .Property(nd => nd.VaiTro)
            .HasDefaultValue("Customer");
        
        modelBuilder.Entity<DonHang>()
            .Property(dh => dh.TrangThai)
            .HasDefaultValue("Chờ xác nhận");
        
        // Giá trị mặc định cho ngày tạo (sử dụng SQL Server function)
        modelBuilder.Entity<SanPham>()
            .Property(sp => sp.NgayTao)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<Combo>()
            .Property(c => c.NgayTao)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<DanhMuc>()
            .Property(dm => dm.NgayTao)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<NguoiDung>()
            .Property(nd => nd.NgayTao)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<DonHang>()
            .Property(dh => dh.NgayDat)
            .HasDefaultValueSql("GETDATE()");
        
        // ========== CẤU HÌNH ĐỘ DÀI CHO STRING FIELDS ==========
        
        modelBuilder.Entity<SanPham>()
            .Property(s => s.TenSanPham)
            .HasMaxLength(200);
        
        modelBuilder.Entity<SanPham>()
            .Property(s => s.MoTa)
            .HasMaxLength(1000);
        
        modelBuilder.Entity<SanPham>()
            .Property(s => s.ChuDe)
            .HasMaxLength(100);
        
        modelBuilder.Entity<Combo>()
            .Property(c => c.TenCombo)
            .HasMaxLength(200);
        
        modelBuilder.Entity<Combo>()
            .Property(c => c.MoTa)
            .HasMaxLength(1000);
        
        modelBuilder.Entity<DonHang>()
            .Property(d => d.TrangThai)
            .HasMaxLength(50);
        
        modelBuilder.Entity<DonHang>()
            .Property(d => d.GhiChu)
            .HasMaxLength(500);
        
        modelBuilder.Entity<NguoiDung>()
            .Property(n => n.HoTen)
            .HasMaxLength(100);
        
        modelBuilder.Entity<NguoiDung>()
            .Property(n => n.Email)
            .HasMaxLength(100);
        
        modelBuilder.Entity<NguoiDung>()
            .Property(n => n.VaiTro)
            .HasMaxLength(20);
        
        modelBuilder.Entity<DanhMuc>()
            .Property(d => d.TenDanhMuc)
            .HasMaxLength(100);
        
        modelBuilder.Entity<ChiTietDonHang>()
            .Property(c => c.LoaiSanPham)
            .HasMaxLength(10);
        
        // ========== CẤU HÌNH UNIQUE CONSTRAINTS ==========
        
        modelBuilder.Entity<NguoiDung>()
            .HasIndex(nd => nd.Email)
            .IsUnique();
        
        modelBuilder.Entity<SanPham>()
            .HasIndex(sp => sp.TenSanPham)
            .IsUnique();
        
        modelBuilder.Entity<DanhMuc>()
            .HasIndex(dm => dm.TenDanhMuc)
            .IsUnique();
        
        modelBuilder.Entity<Combo>()
            .HasIndex(c => c.TenCombo)
            .IsUnique();
        
        // ========== CẤU HÌNH TÊN BẢNG ==========
        // (Giữ nguyên cấu hình tên bảng của bạn)
        modelBuilder.Entity<NguoiDung>().ToTable("Users");
        modelBuilder.Entity<SanPham>().ToTable("Products");
        modelBuilder.Entity<DanhMuc>().ToTable("Categories");
        modelBuilder.Entity<DonHang>().ToTable("Orders");
        modelBuilder.Entity<ChiTietDonHang>().ToTable("OrderDetails");
        modelBuilder.Entity<Combo>().ToTable("Combos");
        modelBuilder.Entity<ChiTietCombo>().ToTable("ComboDetails");
    }
}
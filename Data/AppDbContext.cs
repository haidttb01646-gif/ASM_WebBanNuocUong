using Microsoft.EntityFrameworkCore;
using ASM_WebBanNuocUong.Models;

namespace ASM_WebBanNuocUong.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Combo> Combos { get; set; }
    public DbSet<ComboDetail> ComboDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // Cấu hình Fluent API để tránh lỗi làm tròn tiền
        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);
        modelBuilder.Entity<Combo>().Property(c => c.Price).HasPrecision(18, 2);
        modelBuilder.Entity<OrderDetail>().Property(od => od.Price).HasPrecision(18, 2);
    }
}
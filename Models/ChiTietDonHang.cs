using System.ComponentModel.DataAnnotations;

namespace ASM_WebBanNuocUong.Models;

public class ChiTietDonHang {
    [Key]
    public Guid MaChiTietDonHang { get; set; }
    public Guid MaDonHang { get; set; }
    public virtual DonHang? DonHang { get; set; }
    
    // Có thể là sản phẩm riêng lẻ hoặc combo
    public Guid? MaSanPham { get; set; }
    public virtual SanPham? SanPham { get; set; }
    
    public Guid? MaCombo { get; set; }
    public virtual Combo? Combo { get; set; }
    
    public int SoLuong { get; set; }
    public decimal Gia { get; set; }
    public string LoaiSanPham { get; set; } = "SanPham"; // "SanPham" hoặc "Combo"
}
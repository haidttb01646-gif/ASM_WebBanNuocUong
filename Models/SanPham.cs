using System.ComponentModel.DataAnnotations;

namespace ASM_WebBanNuocUong.Models;

public class SanPham {
    [Key]
    public Guid MaSanPham { get; set; }
    [Required] public string TenSanPham { get; set; }
    public decimal Gia { get; set; }
    public string? HinhAnh { get; set; }
    public string? MoTa { get; set; }
    public string? ChuDe { get; set; }
    public bool TrangThai { get; set; } = true; // true: đang bán, false: ngừng bán
    public int SoLuongTon { get; set; } = 0;
    public DateTime NgayTao { get; set; } = DateTime.Now;
    public DateTime? NgayCapNhat { get; set; }
    
    public Guid MaDanhMuc { get; set; }
    public virtual DanhMuc? DanhMuc { get; set; }
    
    public virtual ICollection<ChiTietCombo>? DanhSachChiTietCombo { get; set; }
    public virtual ICollection<ChiTietDonHang>? DanhSachChiTietDonHang { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace ASM_WebBanNuocUong.Models;

public class Combo {
    [Key]
    public Guid MaCombo { get; set; }
    [Required] public string TenCombo { get; set; }
    public decimal Gia { get; set; }
    public string? MoTa { get; set; }
    public string? HinhAnh { get; set; }
    public bool TrangThai { get; set; } = true; // true: đang bán, false: ngừng bán
    public DateTime NgayTao { get; set; } = DateTime.Now;
    public DateTime? NgayCapNhat { get; set; }
    
    public virtual ICollection<ChiTietCombo>? DanhSachChiTietCombo { get; set; }
    public virtual ICollection<ChiTietDonHang>? DanhSachChiTietDonHang { get; set; }
}
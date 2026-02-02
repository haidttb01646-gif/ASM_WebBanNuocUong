using System.ComponentModel.DataAnnotations;

namespace ASM_WebBanNuocUong.Models;

public class DonHang {
    [Key]
    public Guid MaDonHang { get; set; }
    public DateTime NgayDat { get; set; }
    public DateTime? NgayGiao { get; set; }
    public string TrangThai { get; set; } = "Chờ xác nhận"; // "Chờ xác nhận", "Đang giao", "Đã giao", "Đã hủy"
    public string? GhiChu { get; set; }
    public decimal TongTien { get; set; }
    
    public Guid MaNguoiDung { get; set; }
    public virtual NguoiDung? NguoiDung { get; set; }
    public virtual ICollection<ChiTietDonHang>? DanhSachChiTiet { get; set; }
}
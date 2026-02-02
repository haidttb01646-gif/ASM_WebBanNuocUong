using System.ComponentModel.DataAnnotations;

namespace ASM_WebBanNuocUong.Models;

public class DanhMuc {
    [Key]
    public Guid MaDanhMuc { get; set; }
    [Required]
    public string TenDanhMuc { get; set; }
    public bool TrangThai { get; set; } = true;
    public virtual ICollection<SanPham>? DanhSachSanPham { get; set; }
    public DateTime NgayTao { get; set; } = DateTime.Now;
    public DateTime? NgayCapNhat { get; set; }
}
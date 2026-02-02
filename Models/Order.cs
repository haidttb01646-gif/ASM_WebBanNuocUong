using System.ComponentModel.DataAnnotations;

namespace ASM_WebBanNuocUong.Models;

public class Order {
    [Key]
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } // "Chưa giao", "Đang giao", "Đã giao"
    
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
    public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
}
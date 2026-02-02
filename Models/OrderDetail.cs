using System.ComponentModel.DataAnnotations;

namespace ASM_WebBanNuocUong.Models;

public class OrderDetail {
    [Key]
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public virtual Order? Order { get; set; }
    public Guid ProductId { get; set; }
    public virtual Product? Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace ASM_WebBanNuocUong.Models;

public class Product {
    [Key]
    public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
    public string? Theme { get; set; } // Phục vụ tìm kiếm theo chủ đề
    
    public Guid CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}
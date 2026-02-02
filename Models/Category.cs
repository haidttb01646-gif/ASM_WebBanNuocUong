using System.ComponentModel.DataAnnotations;

namespace ASM_WebBanNuocUong.Models;

public class Category {
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}
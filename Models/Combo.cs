using System.ComponentModel.DataAnnotations;

namespace ASM_WebBanNuocUong.Models;

public class Combo {
    [Key]
    public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<ComboDetail>? ComboDetails { get; set; }
}
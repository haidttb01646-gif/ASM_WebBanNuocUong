using System.ComponentModel.DataAnnotations;

namespace ASM_WebBanNuocUong.Models;

public class ComboDetail {
    [Key]
    public Guid Id { get; set; }
    public Guid ComboId { get; set; }
    public virtual Combo? Combo { get; set; }
    public Guid ProductId { get; set; }
    public virtual Product? Product { get; set; }
}
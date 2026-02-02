using System.ComponentModel.DataAnnotations;

namespace ASM_WebBanNuocUong.Models;

public class User {
    [Key]
    public Guid Id { get; set; }
    [Required] public string FullName { get; set; } // 1
    [Required] public string Email { get; set; }    // 2
    [Required] public string Password { get; set; } // 3
    public string? Phone { get; set; }               // 4
    public string? Address { get; set; }             // 5
    public DateTime Birthday { get; set; }          // 6
    public string Role { get; set; } // "Admin" hoặc "Customer"
}
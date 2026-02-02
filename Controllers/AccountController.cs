using Microsoft.AspNetCore.Mvc;
using ASM_WebBanNuocUong.Models;

namespace ASM_WebBanNuocUong.Controllers;

public class AccountController : Controller
{
    // Trang Đăng nhập (View tĩnh)
    public IActionResult Login() => View();

    // Trang Đăng ký (View tĩnh)
    public IActionResult Register() => View();
}
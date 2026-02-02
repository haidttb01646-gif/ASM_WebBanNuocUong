using Microsoft.AspNetCore.Mvc;

namespace ASM_WebBanNuocUong.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
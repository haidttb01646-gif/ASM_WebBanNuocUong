using Microsoft.AspNetCore.Mvc;

namespace ASM_WebBanNuocUong.Controllers;

public class OrderController : Controller
{
    // Trang danh sách tất cả đơn hàng
    public IActionResult Index() => View();

    // Trang xem chi tiết một đơn hàng cụ thể
    public IActionResult Details() => View();
    // Trang lịch sử đơn hàng dành cho Khách hàng
public IActionResult History()
{
    return View();
}
}
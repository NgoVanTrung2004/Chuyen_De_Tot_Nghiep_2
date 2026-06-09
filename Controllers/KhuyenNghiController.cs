using Microsoft.AspNetCore.Mvc;
using QuanLyPhongKhachSan.Models;

namespace QuanLyPhongKhachSan.Controllers
{
    public class KhuyenNghiController : Controller
    {
        private readonly QlpksContext _context;

        public KhuyenNghiController(QlpksContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(
                _context.KhuyenNghis
                .OrderByDescending(x => x.MaKhuyenNghi)
                .ToList()
            );
        }
    }
}
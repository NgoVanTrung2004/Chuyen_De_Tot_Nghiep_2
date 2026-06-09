using Microsoft.AspNetCore.Mvc;
using QuanLyPhongKhachSan.Models;

namespace QuanLyPhongKhachSan.Controllers
{
    public class DanhGiaMoHinhController : Controller
    {
        private readonly QlpksContext _context;

        public DanhGiaMoHinhController(QlpksContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ds = _context.DanhGiaMoHinhs
                .OrderByDescending(x => x.NgayDanhGia)
                .ToList();

            return View(ds);
        }
    }
}
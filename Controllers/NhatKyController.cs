using Microsoft.AspNetCore.Mvc;
using QuanLyPhongKhachSan.Models;

namespace QuanLyPhongKhachSan.Controllers
{
    public class NhatKyController : Controller
    {
        private readonly QlpksContext _context;

        public NhatKyController(QlpksContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ds = _context.NhatKyHeThongs
                .OrderByDescending(x => x.ThoiGian)
                .ToList();

            return View(ds);
        }
    }
}
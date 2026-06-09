using Microsoft.AspNetCore.Mvc;
using QuanLyPhongKhachSan.Models;

namespace QuanLyPhongKhachSan.Controllers
{
    public class CongSuatPhongController : Controller
    {
        private readonly QlpksContext _context;

        public CongSuatPhongController(QlpksContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ds = _context.CongSuatPhongs.ToList();

            return View(ds);
        }
    }
}
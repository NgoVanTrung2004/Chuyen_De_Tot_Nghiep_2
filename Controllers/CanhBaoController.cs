using Microsoft.AspNetCore.Mvc;
using QuanLyPhongKhachSan.Models;

namespace QuanLyPhongKhachSan.Controllers
{
    public class CanhBaoController : Controller
    {
        private readonly QlpksContext _context;

        public CanhBaoController(QlpksContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(
                _context.CanhBaos
                .OrderByDescending(x => x.MaCanhBao)
                .ToList()
            );
        }
    }
}
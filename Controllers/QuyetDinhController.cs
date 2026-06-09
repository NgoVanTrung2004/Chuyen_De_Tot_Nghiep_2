using Microsoft.AspNetCore.Mvc;
using QuanLyPhongKhachSan.Models;
using Microsoft.AspNetCore.Http;

namespace QuanLyPhongKhachSan.Controllers
{
    public class QuyetDinhController : Controller
    {
        private readonly QlpksContext _context;

        public QuyetDinhController(QlpksContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction(
                    "Index",
                    "Dashboard");
            }

            var ds = _context.QuyetDinhs
                .OrderByDescending(x => x.MaQuyetDinh)
                .ToList();

            return View(ds);
        }

        public IActionResult Duyet(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction(
                    "Index",
                    "Dashboard");
            }

            var qd = _context.QuyetDinhs.Find(id);

            if (qd != null)
            {
                qd.TrangThai = "Đã duyệt";

                _context.SaveChanges();

                var userName =
    HttpContext.Session.GetString("UserName");

                var user = _context.NguoiDungs
                    .FirstOrDefault(x => x.TenDangNhap == userName);

                if (user != null)
                {
                    _context.NhatKyHeThongs.Add(
                        new NhatKyHeThong
                        {
                            MaNguoiDung = user.MaNguoiDung,
                            HanhDong = $"Duyệt quyết định #{id}",
                            ThoiGian = DateTime.Now
                        });

                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult TuChoi(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction(
                    "Index",
                    "Dashboard");
            }

            var qd = _context.QuyetDinhs.Find(id);

            if (qd != null)
            {
                qd.TrangThai = "Từ chối";

                _context.SaveChanges();

                var userName =
    HttpContext.Session.GetString("UserName");

                var user = _context.NguoiDungs
                    .FirstOrDefault(x => x.TenDangNhap == userName);

                if (user != null)
                {
                    _context.NhatKyHeThongs.Add(
                        new NhatKyHeThong
                        {
                            MaNguoiDung = user.MaNguoiDung,
                            HanhDong = $"Từ chối quyết định #{id}",
                            ThoiGian = DateTime.Now
                        });

                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
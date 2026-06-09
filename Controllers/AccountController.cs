using Microsoft.AspNetCore.Mvc;
using QuanLyPhongKhachSan.Models;

namespace QuanLyPhongKhachSan.Controllers
{
    public class AccountController : Controller
    {
        private readonly QlpksContext _context;

        public AccountController(QlpksContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _context.NguoiDungs
                .FirstOrDefault(x =>
                    x.TenDangNhap == model.TenDangNhap
                    && x.MatKhau == model.MatKhau);

            if (user == null)
            {
                ViewBag.Error = "Sai tài khoản hoặc mật khẩu";
                return View(model);
            }

            HttpContext.Session.SetString(
                "UserName",
                user.TenDangNhap);

            HttpContext.Session.SetString(
                "Role",
                user.VaiTro ?? "");

            var log = new NhatKyHeThong();

            log.MaNguoiDung = user.MaNguoiDung;
            log.HanhDong = "Đăng nhập hệ thống";
            log.ThoiGian = DateTime.Now;

            _context.NhatKyHeThongs.Add(log);

            _context.SaveChanges();

            return RedirectToAction(
                "Index",
                "Dashboard");
        }

        public IActionResult Logout()
        {
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
                        HanhDong = "Đăng xuất",
                        ThoiGian = DateTime.Now
                    });

                _context.SaveChanges();
            }
            HttpContext.Session.Clear();

            return RedirectToAction(
                "Login",
                "Account");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using QuanLyPhongKhachSan.Models;

namespace QuanLyPhongKhachSan.Controllers
{
    public class DashboardController : Controller
    {
        private readonly QlpksContext _context;

        public DashboardController(QlpksContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(
    HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }

            var latest = _context.CongSuatPhongs
                     .OrderByDescending(x => x.Ngay)
                     .FirstOrDefault();

            DashboardViewModel model = new DashboardViewModel();

            if (latest != null)
            {
                model.Ngay = latest.Ngay;
                model.TongPhong = latest.TongPhong;
                model.PhongDaDat = latest.PhongDaDat;
                model.TyLeCongSuat = latest.TyLeCongSuat;
            }

            model.TongKhachHang = _context.KhachHangs.Count();

            model.TongDatPhong = _context.DatPhongs.Count();

            model.CongSuatTrungBinh =
                _context.CongSuatPhongs.Average(x => x.TyLeCongSuat);

            model.CongSuatCaoNhat =
                _context.CongSuatPhongs.Max(x => x.TyLeCongSuat);

            model.CongSuatThapNhat =
                _context.CongSuatPhongs.Min(x => x.TyLeCongSuat);


            // Dự báo mới nhất
            var duBaoMoiNhat = _context.DuBaos
                .OrderByDescending(x => x.MaDuBao)
                .FirstOrDefault();

            if (duBaoMoiNhat != null)
            {
                model.MoHinhTotNhat = duBaoMoiNhat.MoHinhSuDung;
                model.DoTinCay = duBaoMoiNhat.DoTinCay ?? 0;
            }

            var danhGia = _context.DanhGiaMoHinhs
                .OrderByDescending(x => x.MaDanhGia)
                .FirstOrDefault();

            if (danhGia != null)
            {
                model.RMSE = danhGia.Rmse ?? 0;

                model.MAE = danhGia.Mae ?? 0;

                model.MAPE = danhGia.Mape ?? 0;
            }

            //Khuyến nghị mới nhất
            var khuyenNghi = _context.KhuyenNghis
                .OrderByDescending(x => x.MaKhuyenNghi)
                .FirstOrDefault();

            if (khuyenNghi != null)
            {
                model.KhuyenNghiMoiNhat = khuyenNghi.NoiDung;
            }

            //Quyết định mới nhất
            var quyetDinh = _context.QuyetDinhs
                .OrderByDescending(x => x.MaQuyetDinh)
                .FirstOrDefault();
            if (quyetDinh != null)
            {
                model.QuyetDinhMoiNhat = quyetDinh.NoiDung;
            }

            //Cảnh báo mới nhất
            var canhBao = _context.CanhBaos
                .OrderByDescending(x => x.MaCanhBao)
                .FirstOrDefault();

            if (canhBao != null)
            {
                model.CanhBaoMoiNhat = canhBao.NoiDung;
            }
            var chartData = _context.CongSuatPhongs
                .OrderBy(x => x.Ngay)
                .Take(100)
                .ToList();

            model.Labels = chartData
                .Select(x => x.Ngay.ToString())
                .ToList();

            model.Values = chartData
                .Select(x => x.TyLeCongSuat)
                .ToList();

            var forecastData = _context.ChiTietDuBaos
                .OrderBy(x => x.Ngay)
                .Take(30)
                .ToList();

            model.ForecastLabels = forecastData
                .Select(x => x.Ngay.ToString())
                .ToList();

            model.ForecastValues = forecastData
                .Select(x => x.CongSuatDuBao ?? 0)
                .ToList();

            return View(model);
        }
    }
}
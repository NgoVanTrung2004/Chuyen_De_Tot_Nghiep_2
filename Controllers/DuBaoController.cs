using Microsoft.AspNetCore.Mvc;
using QuanLyPhongKhachSan.Models;

namespace QuanLyPhongKhachSan.Controllers
{
    public class DuBaoController : Controller
    {
        private readonly QlpksContext _context;

        public DuBaoController(QlpksContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ds = _context.DuBaos
        .OrderByDescending(x => x.MaDuBao)
        .ToList();

            var vm = new LichSuDuBaoViewModel();

            vm.DanhSachDuBao = ds;

            vm.TongLanDuBao = ds.Count;

            vm.DoTinCayCaoNhat =
                ds.Any()
                ? ds.Max(x => x.DoTinCay ?? 0)
                : 0;

            vm.CongSuatTrungBinh =
                ds.Any()
                ? ds.Average(x => x.CongSuatTrungBinh ?? 0)
                : 0;

            vm.Labels = ds
                .Select(x =>
                    x.NgayDuBao.HasValue
                    ? x.NgayDuBao.Value.ToString("dd/MM")
                    : "")
                .ToList();

            vm.Values = ds
                .Select(x => x.CongSuatTrungBinh ?? 0)
                .ToList();
            return View(vm);
        }
    }
}
namespace QuanLyPhongKhachSan.Models
{
    public class DashboardViewModel
    {
        public int TongPhong { get; set; }

        public int PhongDaDat { get; set; }

        public double TyLeCongSuat { get; set; }

        public DateOnly Ngay { get; set; }

        public int TongKhachHang { get; set; }

        public int TongDatPhong { get; set; }

        public double CongSuatTrungBinh { get; set; }

        public double CongSuatCaoNhat { get; set; }

        public double CongSuatThapNhat { get; set; }

        public string? MoHinhTotNhat { get; set; }

        public double RMSE { get; set; }

        public double MAE { get; set; }

        public double MAPE { get; set; }

        public double DoTinCay { get; set; }

        public string? KhuyenNghiMoiNhat { get; set; }

        public string? QuyetDinhMoiNhat { get; set; }

        public string? CanhBaoMoiNhat { get; set; }

        public List<string>? Labels { get; set; }

        public List<double>? Values { get; set; }

        public List<string>? ForecastLabels { get; set; }

        public List<double>? ForecastValues { get; set; }
    }
}
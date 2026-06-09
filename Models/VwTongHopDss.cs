using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class VwTongHopDss
{
    public int MaDuBao { get; set; }

    public DateTime? NgayDuBao { get; set; }

    public double? CongSuatTrungBinh { get; set; }

    public string? MoHinhSuDung { get; set; }

    public double? DoTinCay { get; set; }

    public double? Rmse { get; set; }

    public double? Mae { get; set; }

    public double? Mape { get; set; }
}

using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class NhatKyDuBao
{
    public int MaNhatKy { get; set; }

    public DateTime? ThoiGian { get; set; }

    public string? MoHinh { get; set; }

    public int? SoNgayDuBao { get; set; }

    public double? Rmse { get; set; }

    public double? Mae { get; set; }

    public double? Mape { get; set; }

    public string? GhiChu { get; set; }
}

using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class DanhGiaMoHinh
{
    public int MaDanhGia { get; set; }

    public string? TenMoHinh { get; set; }

    public double? Rmse { get; set; }

    public double? Mae { get; set; }

    public double? Mape { get; set; }

    public DateTime? NgayDanhGia { get; set; }
}

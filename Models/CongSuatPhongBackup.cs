using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class CongSuatPhongBackup
{
    public int MaCongSuat { get; set; }

    public DateOnly Ngay { get; set; }

    public int TongPhong { get; set; }

    public int PhongDaDat { get; set; }

    public double TyLeCongSuat { get; set; }
}

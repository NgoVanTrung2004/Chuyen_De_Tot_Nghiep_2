using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class PhongBackup
{
    public int MaPhong { get; set; }

    public string? SoPhong { get; set; }

    public int? MaLoaiPhong { get; set; }

    public string? TrangThai { get; set; }

    public int? Tang { get; set; }

    public int? SucChua { get; set; }

    public string? GhiChu { get; set; }
}

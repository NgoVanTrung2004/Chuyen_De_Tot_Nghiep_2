using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class HoaDonBackup
{
    public int MaHoaDon { get; set; }

    public int MaDatPhong { get; set; }

    public DateTime? NgayLap { get; set; }

    public decimal? TongTien { get; set; }

    public string? TrangThaiThanhToan { get; set; }
}

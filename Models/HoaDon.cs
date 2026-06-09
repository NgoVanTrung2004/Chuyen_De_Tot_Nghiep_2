using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class HoaDon
{
    public int MaHoaDon { get; set; }

    public int MaDatPhong { get; set; }

    public DateTime? NgayLap { get; set; }

    public decimal? TongTien { get; set; }

    public string? TrangThaiThanhToan { get; set; }

    public virtual DatPhong MaDatPhongNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class KhachHang
{
    public int MaKhachHang { get; set; }

    public string? HoTen { get; set; }

    public string? Cccd { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<DatPhong> DatPhongs { get; set; } = new List<DatPhong>();
}

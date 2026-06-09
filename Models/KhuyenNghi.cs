using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class KhuyenNghi
{
    public int MaKhuyenNghi { get; set; }

    public int? MaDuBao { get; set; }

    public string? NoiDung { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual DuBao? MaDuBaoNavigation { get; set; }
}

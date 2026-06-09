using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class VwHoTroRaQuyetDinh
{
    public int MaDuBao { get; set; }

    public DateTime? NgayDuBao { get; set; }

    public string? KhuyenNghi { get; set; }

    public string? QuyetDinh { get; set; }
}

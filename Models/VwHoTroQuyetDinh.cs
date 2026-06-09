using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class VwHoTroQuyetDinh
{
    public DateOnly? Ngay { get; set; }

    public double? CongSuatDuBao { get; set; }

    public string DeXuat { get; set; } = null!;
}

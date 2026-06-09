using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class ChiTietDuBao
{
    public int MaChiTiet { get; set; }

    public int? MaDuBao { get; set; }

    public DateOnly? Ngay { get; set; }

    public double? CongSuatDuBao { get; set; }

    public virtual DuBao? MaDuBaoNavigation { get; set; }
}

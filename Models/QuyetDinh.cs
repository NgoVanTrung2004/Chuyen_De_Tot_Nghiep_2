using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class QuyetDinh
{
    public int MaQuyetDinh { get; set; }

    public int? MaDuBao { get; set; }

    public string? LoaiQuyetDinh { get; set; }

    public string? NoiDung { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? TrangThai { get; set; }

    public virtual DuBao? MaDuBaoNavigation { get; set; }
}

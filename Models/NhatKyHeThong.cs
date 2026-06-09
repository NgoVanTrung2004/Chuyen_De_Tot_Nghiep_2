using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class NhatKyHeThong
{
    public int MaNhatKy { get; set; }

    public int? MaNguoiDung { get; set; }

    public string? HanhDong { get; set; }

    public DateTime? ThoiGian { get; set; }

    public virtual NguoiDung? MaNguoiDungNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class NguoiDung
{
    public int MaNguoiDung { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? VaiTro { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<NhatKyHeThong> NhatKyHeThongs { get; set; } = new List<NhatKyHeThong>();
}

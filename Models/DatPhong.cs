using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class DatPhong
{
    public int MaDatPhong { get; set; }

    public int MaKhachHang { get; set; }

    public int MaPhong { get; set; }

    public DateOnly? NgayNhanPhong { get; set; }

    public DateOnly? NgayTraPhong { get; set; }

    public decimal? TongTien { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}

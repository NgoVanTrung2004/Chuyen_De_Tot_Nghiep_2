using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class DuBao
{
    public int MaDuBao { get; set; }

    public DateTime? NgayDuBao { get; set; }

    public int? SoNgayDuBao { get; set; }

    public double? CongSuatTrungBinh { get; set; }

    public string? MoHinhSuDung { get; set; }

    public double? DoTinCay { get; set; }

    public virtual ICollection<ChiTietDuBao> ChiTietDuBaos { get; set; } = new List<ChiTietDuBao>();

    public virtual ICollection<KhuyenNghi> KhuyenNghis { get; set; } = new List<KhuyenNghi>();

    public virtual ICollection<QuyetDinh> QuyetDinhs { get; set; } = new List<QuyetDinh>();
}

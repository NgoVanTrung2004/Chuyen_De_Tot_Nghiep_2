using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class VwCanhBaoTuDong
{
    public DateOnly Ngay { get; set; }

    public double TyLeCongSuat { get; set; }

    public string MucDo { get; set; } = null!;
}

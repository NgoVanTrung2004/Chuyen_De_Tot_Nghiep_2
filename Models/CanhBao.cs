using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class CanhBao
{
    public int MaCanhBao { get; set; }

    public DateOnly? NgayCanhBao { get; set; }

    public string? MucDo { get; set; }

    public string? NoiDung { get; set; }
}

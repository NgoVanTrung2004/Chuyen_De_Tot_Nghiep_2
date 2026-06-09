using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class CongSuatPhongImport
{
    public DateOnly Date { get; set; }

    public byte BookedRooms { get; set; }

    public double OccupancyRate { get; set; }

    public double? RollingMean7 { get; set; }

    public byte Month { get; set; }

    public string DayOfWeek { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models;

public partial class CongSuatPhongTemp
{
    public DateOnly? Date { get; set; }

    public int? BookedRooms { get; set; }

    public double? OccupancyRate { get; set; }

    public double? RollingMean7 { get; set; }

    public int? Month { get; set; }

    public int? DayOfWeek { get; set; }
}

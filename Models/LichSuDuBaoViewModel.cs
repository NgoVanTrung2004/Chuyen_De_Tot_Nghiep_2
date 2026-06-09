using System.Collections.Generic;

namespace QuanLyPhongKhachSan.Models
{
    public class LichSuDuBaoViewModel
    {
        public int TongLanDuBao { get; set; }

        public double DoTinCayCaoNhat { get; set; }

        public double CongSuatTrungBinh { get; set; }

        public List<DuBao> DanhSachDuBao { get; set; }
            = new List<DuBao>();

        public List<string> Labels { get; set; }
            = new List<string>();

        public List<double> Values { get; set; }
            = new List<double>();
    }
}
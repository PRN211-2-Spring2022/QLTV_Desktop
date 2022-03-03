using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbPhieubangiaosach
    {
        public TbPhieubangiaosach()
        {
            TbCtPhieubangiaos = new HashSet<TbCtPhieubangiao>();
        }

        public int Maphieubangiao { get; set; }
        public int Mathedocgia { get; set; }
        public int Manhanvien { get; set; }
        public DateTime Ngaymuon { get; set; }
        public DateTime Ngaydukientra { get; set; }
        public string Tinhtrangkhigiao { get; set; }

        public virtual TbNhanVien ManhanvienNavigation { get; set; }
        public virtual TbDocgium MathedocgiaNavigation { get; set; }
        public virtual ICollection<TbCtPhieubangiao> TbCtPhieubangiaos { get; set; }
    }
}

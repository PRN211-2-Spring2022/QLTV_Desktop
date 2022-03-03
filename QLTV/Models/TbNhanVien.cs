using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbNhanVien
    {
        public TbNhanVien()
        {
            TbBbNhanlaisaches = new HashSet<TbBbNhanlaisach>();
            TbPhieubangiaosaches = new HashSet<TbPhieubangiaosach>();
        }

        public int Manhanvien { get; set; }
        public string Tennhanvien { get; set; }

        public virtual ICollection<TbBbNhanlaisach> TbBbNhanlaisaches { get; set; }
        public virtual ICollection<TbPhieubangiaosach> TbPhieubangiaosaches { get; set; }
    }
}

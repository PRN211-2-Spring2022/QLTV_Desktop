using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbBbNhanlaisach
    {
        public TbBbNhanlaisach()
        {
            TbCtNhanlais = new HashSet<TbCtNhanlai>();
            TbPhieuphats = new HashSet<TbPhieuphat>();
        }

        public int Mabbnhanlai { get; set; }
        public int Mathedocgia { get; set; }
        public int Manhanvien { get; set; }
        public DateTime Ngaytra { get; set; }

        public virtual TbNhanVien ManhanvienNavigation { get; set; }
        public virtual TbDocgium MathedocgiaNavigation { get; set; }
        public virtual ICollection<TbCtNhanlai> TbCtNhanlais { get; set; }
        public virtual ICollection<TbPhieuphat> TbPhieuphats { get; set; }
    }
}

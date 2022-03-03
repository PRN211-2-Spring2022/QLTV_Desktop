using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbPhieuphat
    {
        public TbPhieuphat()
        {
            TbCtPhieuphats = new HashSet<TbCtPhieuphat>();
        }

        public int Maphieuphat { get; set; }
        public int Mabbnhanlai { get; set; }
        public int? Tongtien { get; set; }

        public virtual TbBbNhanlaisach MabbnhanlaiNavigation { get; set; }
        public virtual ICollection<TbCtPhieuphat> TbCtPhieuphats { get; set; }
    }
}

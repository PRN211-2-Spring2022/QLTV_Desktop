using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbSach
    {
        public TbSach()
        {
            TbCtNhanlais = new HashSet<TbCtNhanlai>();
            TbCtPhieubangiaos = new HashSet<TbCtPhieubangiao>();
            TbCtPhieuphats = new HashSet<TbCtPhieuphat>();
        }

        public int Maquyensach { get; set; }
        public int Madausach { get; set; }
        public int Tinhtrangsach { get; set; }

        public virtual TbDausach MadausachNavigation { get; set; }
        public virtual ICollection<TbCtNhanlai> TbCtNhanlais { get; set; }
        public virtual ICollection<TbCtPhieubangiao> TbCtPhieubangiaos { get; set; }
        public virtual ICollection<TbCtPhieuphat> TbCtPhieuphats { get; set; }
    }
}

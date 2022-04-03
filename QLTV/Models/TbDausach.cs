using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbDausach
    {
        public TbDausach()
        {
            TbCtTacgia = new HashSet<TbCtTacgium>();
            TbSaches = new HashSet<TbSach>();
        }

        public int Madausach { get; set; }
        public string Tendausach { get; set; }
        public int Soluong { get; set; }
        public int Sotrang { get; set; }
        public int? Tansuat { get; set; }
        public int Manhaxuatban { get; set; }

        public virtual TbNhaXuatBan ManhaxuatbanNavigation { get; set; }
        public virtual ICollection<TbCtTacgium> TbCtTacgia { get; set; }
        public virtual ICollection<TbSach> TbSaches { get; set; }
    }
}

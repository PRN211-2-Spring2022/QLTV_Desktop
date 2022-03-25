using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbNhaXuatBan
    {
        public TbNhaXuatBan()
        {
            TbDausaches = new HashSet<TbDausach>();
        }

        public int Manhaxuatban { get; set; }
        public string Tennhaxuatban { get; set; }

        public virtual ICollection<TbDausach> TbDausaches { get; set; }
    }
}

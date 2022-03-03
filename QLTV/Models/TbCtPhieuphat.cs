using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbCtPhieuphat
    {
        public int Maphieuphat { get; set; }
        public int Maquyensach { get; set; }
        public int Songayquahan { get; set; }
        public string Tinhtranghong { get; set; }

        public virtual TbPhieuphat MaphieuphatNavigation { get; set; }
        public virtual TbSach MaquyensachNavigation { get; set; }
    }
}

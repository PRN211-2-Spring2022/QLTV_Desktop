using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbCtPhieubangiao
    {
        public int Maquyensach { get; set; }
        public int Maphieubangiao { get; set; }

        public virtual TbPhieubangiaosach MaphieubangiaoNavigation { get; set; }
        public virtual TbSach MaquyensachNavigation { get; set; }
    }
}

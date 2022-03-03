using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbCtNhanlai
    {
        public int Mabbnhanlai { get; set; }
        public int Maquyensach { get; set; }
        public string Tinhtrangnhanlai { get; set; }

        public virtual TbBbNhanlaisach MabbnhanlaiNavigation { get; set; }
        public virtual TbSach MaquyensachNavigation { get; set; }
    }
}

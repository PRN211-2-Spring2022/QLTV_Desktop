using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbDocgium
    {
        public TbDocgium()
        {
            TbBbNhanlaisaches = new HashSet<TbBbNhanlaisach>();
            TbPhieubangiaosaches = new HashSet<TbPhieubangiaosach>();
        }

        public int Mathedocgia { get; set; }
        public string Hoten { get; set; }
        public DateTime Ngaysinh { get; set; }
        public DateTime Ngaylamthe { get; set; }
        public string Diachi { get; set; }
        public string Doituongdocgia { get; set; }

        public virtual ICollection<TbBbNhanlaisach> TbBbNhanlaisaches { get; set; }
        public virtual ICollection<TbPhieubangiaosach> TbPhieubangiaosaches { get; set; }
    }
}

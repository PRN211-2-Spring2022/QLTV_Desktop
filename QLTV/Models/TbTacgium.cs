using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbTacgium
    {
        public TbTacgium()
        {
            TbCtTacgia = new HashSet<TbCtTacgium>();
        }

        public int Matacgia { get; set; }
        public string Tentacgia { get; set; }

        public virtual ICollection<TbCtTacgium> TbCtTacgia { get; set; }
    }
}

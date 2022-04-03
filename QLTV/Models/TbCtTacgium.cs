using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbCtTacgium
    {
        public int Matacgia { get; set; }
        public int Madausach { get; set; }
        public string Vaitrotacgia { get; set; }

        public virtual TbDausach MadausachNavigation { get; set; }
        public virtual TbTacgium MatacgiaNavigation { get; set; }
    }
}

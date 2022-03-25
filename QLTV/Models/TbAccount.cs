using System;
using System.Collections.Generic;

#nullable disable

namespace QLTV.Models
{
    public partial class TbAccount
    {
        public string Username { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public int Manhanvien { get; set; }
        public int Quyen { get; set; }

        public virtual TbNhanVien ManhanvienNavigation { get; set; }
    }
}

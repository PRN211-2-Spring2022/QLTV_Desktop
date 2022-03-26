using System;
using QLTV.Models;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QLTV
{
    public partial class frmlichsu : Form
    {
        public frmlichsu()
        {
            InitializeComponent();
        }

        QLTV_DesktopContext qltv = new QLTV_DesktopContext();

        public void loadlichsu()
        {
            var lichsu = (
                from s in qltv.TbPhieubangiaosaches
                join d in qltv.TbCtPhieubangiaos on s.Maphieubangiao equals d.Maphieubangiao
                select new
                {
                    d.Maquyensach,
                    s.Maphieubangiao,
                    s.Mathedocgia,
                    s.Manhanvien,
                    s.Ngaymuon,
                    s.Ngaydukientra,
                    s.Tinhtrangkhigiao
                }
            ).ToList();
            dgvlichsu.DataSource = lichsu;
        }

        private void frmlichsu_Load(object sender, EventArgs e)
        {
            loadlichsu();
        }

        public void loadsearch()
        {
            var phieu = qltv.TbPhieubangiaosaches
                .Where(m => m.Maphieubangiao == int.Parse(txtfind.Text))
                .ToList();
            dgvlichsu.DataSource = phieu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadsearch();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadlichsu();
        }
    }
}

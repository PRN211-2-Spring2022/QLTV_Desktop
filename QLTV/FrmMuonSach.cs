using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLTV.Models;

namespace BookLoanManager
{
    public partial class FrmMuonSach : Form
    {

        public FrmMuonSach()
        {
            InitializeComponent();
        }
        
        QLTV_DesktopContext qlms = new QLTV_DesktopContext();

        public void Loadmuonsach()
        {
            var loadsachmuon = (from a in qlms.TbDausaches
                               join b in qlms.TbSaches on a.Madausach equals b.Madausach
                               join c in qlms.TbCtTacgia on a.Madausach equals c.Madausach
                               select new { b.Maquyensach, b.Madausach, a.Soluong, c.Matacgia }).ToList();
            lbltensach.DataBindings.Clear();
            lblMaLoai.DataBindings.Clear();
            lblSoLuong.DataBindings.Clear();
            lblMaTG.DataBindings.Clear();
            //cbChonMaSach.DataBindings.Clear();
            //cbChonMaSach.DataBindings.Add("Text")
            lbltensach.DataBindings.Add("Text", loadsachmuon, "Maquyensach");
            lblMaLoai.DataBindings.Add("Text", loadsachmuon, "Madausach");
            lblSoLuong.DataBindings.Add("Text", loadsachmuon, "Soluong");
            lblMaTG.DataBindings.Add("Text", loadsachmuon, "Matacgia");
        }

        private void FrmMuonSach_Load(object sender, EventArgs e)
        {
            try
            {
                Loadmuonsach();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void MuonTraSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.No)
                e.Cancel = true;
        }

        private void btnCreatePhieu_Click(object sender, EventArgs e)
        {

        }
    }
}

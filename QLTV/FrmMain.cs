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

namespace BookLoanManager
{
    public partial class FrmMain : UserControl
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        QLTV_DesktopContext QLTV = new QLTV_DesktopContext();

        public void LoadDG()
        {
            var docgia = (
                from d in QLTV.TbDocgia
                select new { d.Mathedocgia, d.Hoten, d.Diachi }
            ).ToList();
            dgvthongtindocgia.DataSource = docgia;
        }
        public void Loadsach()
        {
            var sach = (
                from d in QLTV.TbDausaches
                join b in QLTV.TbSaches on d.Madausach equals b.Madausach
                join c in QLTV.TbCtTacgia on b.Madausach equals c.Madausach
                join e in QLTV.TbTacgia on c.Matacgia equals e.Matacgia
                select new { b.Madausach, d.Tendausach, e.Tentacgia }
            ).Distinct().ToList();
            dgvthongtinsach.DataSource = sach;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDG();
                Loadsach();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        public void Loadbtnsearchma()
        {
            var findbyma = QLTV.TbDocgia
                .Where(m => m.Mathedocgia == int.Parse(txtfind.Text))
                .ToList();
            dgvthongtindocgia.DataSource = findbyma;
        }

        public void Loadbtsearchname()
        {
            var findbyten = QLTV.TbDocgia
                .Where(t => t.Hoten.Contains(txtfind.Text))
                .ToList();
            dgvthongtindocgia.DataSource = findbyten;
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            if (txtfind.Text == "")
            {
                MessageBox.Show("Thông tin tìm kiếm không thể để trống");
                txtfind.Focus();
            }
            else if (rbtnmathe.Checked == true)
            {
                Loadbtnsearchma();
            }
            else if (rbtnten.Checked == true)
            {
                Loadbtsearchname();
            }
            else if (rbtnmathe.Checked == false && rbtnten.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn thông tin tìm kiếm");
                rbtnmathe.Focus();
            }

        }
    }
}

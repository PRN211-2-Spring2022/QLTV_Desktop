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
    public partial class FrmPhieuPhat : Form
    {
        public FrmPhieuPhat()
        {
            InitializeComponent();
        }

        QLTV_DesktopContext QLTV = new QLTV_DesktopContext();

        public void load_phieuphat()
        {
            var phieuphat = (
                from ppb in QLTV.TbCtPhieubangiaos
                join pb in QLTV.TbPhieubangiaosaches on ppb.Maphieubangiao equals pb.Maphieubangiao
                join d in QLTV.TbDocgia on pb.Mathedocgia equals d.Mathedocgia
                join nl in QLTV.TbBbNhanlaisaches on d.Mathedocgia equals nl.Mathedocgia
                join pp in QLTV.TbPhieuphats on nl.Mabbnhanlai equals pp.Mabbnhanlai
                select new
                {
                    pp.Maphieuphat,
                    d.Hoten,
                    ppb.Maquyensach,
                    pb.Ngaydukientra,
                    nl.Ngaytra,
                    pp.Tongtien
                }
            ).ToList();
            txtName.DataBindings.Clear();
            txtMaSach.DataBindings.Clear();
            txtngayhethan.DataBindings.Clear();
            txtngaytra.DataBindings.Clear();

            txtName.DataBindings.Add("Text", phieuphat, "Hoten");
            txtMaSach.DataBindings.Add("Text", phieuphat, "Maquyensach");
            txtngayhethan.DataBindings.Add("Text", phieuphat, "Ngaydukientra");
            txtngaytra.DataBindings.Add("Text", phieuphat, "Ngaytra");

            dataGridView1.DataSource = phieuphat;
        }

        public DataGridView dataGriview
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }

        private void FrmPhieuPhat_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = dataGriview.DataSource;


            load_phieuphat();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}

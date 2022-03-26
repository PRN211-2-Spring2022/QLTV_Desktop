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
    public partial class FrmPhieuPhat : Form
    {
        public FrmPhieuPhat()
        {
            InitializeComponent();
        }

        QLTV_DesktopContext QLTV = new QLTV_DesktopContext();

        public void load_phieuphat()
        {
            var showphieu = (from ctpp in QLTV.TbCtPhieuphats
                              join pp in QLTV.TbPhieuphats on ctpp.Maphieuphat equals pp.Maphieuphat
                              join nl in QLTV.TbBbNhanlaisaches on pp.Mabbnhanlai equals nl.Mabbnhanlai
                              join ctnl in QLTV.TbCtNhanlais on nl.Mabbnhanlai equals ctnl.Mabbnhanlai
                              join d in QLTV.TbDocgia on nl.Mathedocgia equals d.Mathedocgia
                              select new
                              {
                                  ctpp.Maphieuphat,
                                  d.Hoten,
                                  ctpp.Maquyensach,
                                  ctpp.Songayquahan,
                                  ctnl.Tinhtrangnhanlai,
                                  pp.Tongtien
                              }
                         ).Distinct().ToList(); 
            
            txtName.DataBindings.Clear();
            txtMaSach.DataBindings.Clear();
            txtngayhethan.DataBindings.Clear();
            txtngaytra.DataBindings.Clear();

            txtName.DataBindings.Add("Text", showphieu, "Hoten");
            txtMaSach.DataBindings.Add("Text", showphieu, "Maquyensach");
            txtngayhethan.DataBindings.Add("Text", showphieu, "Songayquahan");
            txtngaytra.DataBindings.Add("Text", showphieu, "Tongtien");

            dataGridView1.DataSource = showphieu;
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

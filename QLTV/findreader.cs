using QLTV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class findreader : UserControl
    {
        public findreader()
        {
            InitializeComponent();
        }
        QLTV_DesktopContext QLTV_qldg = new QLTV_DesktopContext();

        public void Loadinforreader()
        {
            var thongtindocgia = (from c in QLTV_qldg.TbDocgia
                                     select new {c.Mathedocgia, c.Hoten, c.Ngaysinh, c.Ngaylamthe}).ToList();
            dgvthongtindocgia.DataSource = thongtindocgia;
            txtfind.DataBindings.Clear();

        }
        private void findreader_Load(object sender, EventArgs e)
        {
            try
            {
                Loadinforreader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}

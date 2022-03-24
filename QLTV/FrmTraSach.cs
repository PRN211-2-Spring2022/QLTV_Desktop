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
   
    public partial class FrmTraSach : Form
    {
       QLTV_DesktopContext db = new QLTV_DesktopContext();
        public FrmTraSach()
        {
            InitializeComponent();
        }

         public string mapbg="";
        public  string madg="";

       
            private void FrmTraSach_Load(object sender, EventArgs e)
        {
            txtmadg.Text = madg;
            txtmaphieubg.Text = mapbg;
            dtpngaytra.Value = DateTime.Now;

            var nhanvien = (from nv in db.TbNhanViens select new { nv.Manhanvien }).FirstOrDefault();
            comboBox1.DataBindings.Add("text",
                nhanvien, "Manhanvien");


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btntra_Click(object sender, EventArgs e)
        {
            try
            {

                MessageBox.Show("Trả Sách Thành Công!");

               /* if (true)
                {
                    

                }
                else
                {
                    MessageBox.Show("Trả Sách Thất bại!");

                }
*/

               

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

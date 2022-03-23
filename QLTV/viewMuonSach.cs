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

namespace BookLoanManager
{
    public partial class viewMuonSach : Form
    {
        public viewMuonSach()
        {
            InitializeComponent();
        }

        private void viewMuonSach_Load(object sender, EventArgs e)
        {
            try
            {
                load_Phieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
        QLTV_DesktopContext QLTV = new QLTV_DesktopContext();
        public void load_Phieu()
        {
            var docgia = (from p in QLTV.TbPhieubangiaosaches 
                           join d in QLTV.TbDocgia on p.Mathedocgia equals d.Mathedocgia
                           select new {p.Maphieubangiao,p.Mathedocgia ,p.Manhanvien
                           ,p.Ngaymuon,p.Ngaydukientra,p.Tinhtrangkhigiao,
                               d.Hoten 

                           }).ToList();
            
            

                             



            txtName.DataBindings.Clear();
            
            

           // txtName.DataBindings.Add("Text", docgia, "Hoten");
          
           


            dataGridView1.DataSource=docgia;
          
        }

       

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string search = txtName.Text;

            
            try
            {
                var docgia = (from p in QLTV.TbPhieubangiaosaches
                              join d in QLTV.TbDocgia on p.Mathedocgia equals d.Mathedocgia
                               where   d.Hoten.Contains(search)
                               select new
                              {
                                  p.Maphieubangiao,
                                  p.Mathedocgia,
                                  p.Manhanvien
                              ,
                                  p.Ngaymuon,
                                  p.Ngaydukientra,
                                  p.Tinhtrangkhigiao,
                                  d.Hoten

                              }).ToList();


                if (txtName.Text.Trim().Length > 0)
                {
                    dataGridView1.DataSource = docgia;

                }
                else
                {
                    load_Phieu();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

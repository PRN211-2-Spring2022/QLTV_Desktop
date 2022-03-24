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
using QLTV;

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


            var docgia = (
                from p in QLTV.TbPhieubangiaosaches
                join d in QLTV.TbDocgia on p.Mathedocgia equals d.Mathedocgia
                select new
                {
                    p.Maphieubangiao,
                    p.Mathedocgia,
                    p.Manhanvien,
                    p.Ngaymuon,
                    p.Ngaydukientra,
                    p.Tinhtrangkhigiao,
                    d.Hoten
                }
            ).ToList();
           
            txtName.DataBindings.Clear();
            
            txtMapbg.DataBindings.Add("Text",docgia, "Maphieubangiao");
            txtmadg.DataBindings.Add("Text",docgia, "Mathedocgia");

            // txtName.DataBindings.Add("Text", docgia, "Hoten");




            dataGridView1.DataSource = docgia;
        }
        
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string search = txtName.Text;

            try
            {
                var docgia = (
                    from p in QLTV.TbPhieubangiaosaches
                    join d in QLTV.TbDocgia on p.Mathedocgia equals d.Mathedocgia
                  
                    where p.Maphieubangiao.ToString() == search

                    select new
                    {
                        p.Maphieubangiao,
                        p.Mathedocgia,
                        p.Manhanvien,
                        p.Ngaymuon,
                        p.Ngaydukientra,
                        p.Tinhtrangkhigiao,
                        d.Hoten
                    }
                ).ToList();
                
                    txtMapbg.DataBindings.Add("Text", docgia, "Maphieubangiao");
                    txtmadg.DataBindings.Add("Text", docgia, "Mathedocgia");
                
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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmTraSach frmTraSach   = new FrmTraSach();
            frmTraSach.madg = txtmadg.Text;
            frmTraSach.mapbg= txtMapbg.Text;

            frmTraSach.ShowDialog();
        }

        private void btntraSach_Click(object sender, EventArgs e)
        {
            ViewTraSach frmTraSach = new ViewTraSach();
            frmTraSach.ShowDialog();
        }
    }
}

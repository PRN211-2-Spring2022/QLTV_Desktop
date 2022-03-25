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
            

            var phieu = (
                from 

                 p in QLTV.TbPhieubangiaosaches

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
           
            txtmadg.DataBindings.Clear();
            txtMapbg.DataBindings.Clear();  
            txtsearchbyname.DataBindings.Clear();
            txtsearchbyphieu.DataBindings.Clear();  


            
            txtMapbg.DataBindings.Add("Text", phieu, "Maphieubangiao");
            txtmadg.DataBindings.Add("Text", phieu, "Mathedocgia");

            // txtName.DataBindings.Add("Text", docgia, "Hoten");




            dataGridView1.DataSource = phieu;
        }
        
        private void txtName_TextChanged(object sender, EventArgs e)
        {
          
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

        private void btntimen_Click(object sender, EventArgs e)
        {

            txtmadg.DataBindings.Clear();
            txtMapbg.DataBindings.Clear();
            txtsearchbyname.DataBindings.Clear();
            txtsearchbyphieu.DataBindings.Clear();
            txtsearchbyphieu.DataBindings.Clear();


            string search = txtsearchbyname.Text;
            
            try
            {
                var docgia0 = (
                   from

                 p in QLTV.TbPhieubangiaosaches
                   join d in QLTV.TbDocgia on p.Mathedocgia equals d.Mathedocgia

                   where d.Hoten.Contains(search)

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

               
                if (txtsearchbyname.Text.Trim().Length > 0)
                {

                    dataGridView1.DataSource = docgia0;
                }
                else
                {
                    load_Phieu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"error");
            }
        }

        private void btntimpbg_Click(object sender, EventArgs e)
        {
            


            txtmadg.DataBindings.Clear();
            txtMapbg.DataBindings.Clear();
            txtsearchbyname.DataBindings.Clear();
            txtsearchbyphieu.DataBindings.Clear();
            string search = txtsearchbyphieu.Text;

            try
            {
                var docgia1 = (
                   from

                 p in QLTV.TbPhieubangiaosaches
                   join d in QLTV.TbDocgia on p.Mathedocgia equals d.Mathedocgia

                   where p.Maphieubangiao.ToString()==search

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
               

                if (txtsearchbyphieu.Text.Length >0)
                {
                    dataGridView1.DataSource = docgia1;
                }
                else
                {
                    load_Phieu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
            }
        }
    }
}

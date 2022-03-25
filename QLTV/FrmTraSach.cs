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

         public string mapbg="560";
        public  string madg="508";
        public string masach ="";
        public  string mabbnn="";
        public  string TenDg="";
        public DateTime datedukien ;
     

     
        
            private void FrmTraSach_Load(object sender, EventArgs e)

        {

            txtmadg.Text = madg;

            txtmaphieubg.Text = mapbg;


            var  trasach = (from s in db.TbSaches 
                            join ctpg in db.TbCtPhieubangiaos on s.Maquyensach equals ctpg.Maquyensach 
                            join pbg in db.TbPhieubangiaosaches on ctpg.Maphieubangiao equals pbg.Maphieubangiao
                            join  nv in db.TbNhanViens on pbg.Manhanvien equals nv.Manhanvien

                          
                            // join nl in db.TbBbNhanlaisaches on nv.Manhanvien equals nl.Manhanvien 
                            join d in db. TbDocgia on pbg.Mathedocgia equals d.Mathedocgia 
                           
                            
                            where pbg.Maphieubangiao.ToString()== txtmaphieubg.Text
                            where pbg.Mathedocgia.ToString()== txtmadg.Text
                           
                            


                            select new

                            {
                                s.Maquyensach,
                                 pbg.Maphieubangiao,
                                 pbg.Mathedocgia,
                                 d.Hoten,
                                 nv.Manhanvien,
                                 pbg.Ngaydukientra,
                                 

                                 
                            }

                            ).Distinct().ToList();  

          

            

            dtpngaytra.Value = DateTime.Now;
            dtpdu.DataBindings.Add("Text", trasach, "Ngaydukientra");

            txttendg.DataBindings.Add("Text", trasach, "Hoten");

     
            txtmasach.DataBindings.Add("Text", trasach, "Maquyensach");
            

            //dataGridView1.DataSource = trasach;


            DateTime dt1 = dtpngaytra.Value;
           
             DateTime dt2 = dtpdu.Value;
              TimeSpan diff1 = dt1.Subtract(dt2);
            
            if(diff1.Days > 0)
            {

               
                txtngayquahan.Text = diff1.Days.ToString();
                txtngayquahan.ForeColor = Color.Red;
                
                lbltienphat.Text = "Tiền Phạt: "+diff1.Days*1000+".0";

            }
            else
            {
                txtngayquahan.Text = "Trả Sách Đúng Hạn!";
                lbltienphat.Text = "0.0";
            }
            





            cbtinhtrangsach.SelectedIndex = 0;  





        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int day = Convert.ToInt32(txtngayquahan.Text);
            int tong = 0;
            int tien = day * 1000;
            if (cbtinhtrangsach.SelectedIndex==0)
            {
                lbltienphat.Text = "Tiền Phạt: " ;
                textBox1.Text = tien.ToString();

            }
            else if(cbtinhtrangsach.SelectedIndex == 1)
            {
                tong =tien+ 50000;
                lbltienphat.Text = "Tiền Phạt: "+tien+"+50000 :";
                textBox1.Text = tong.ToString();
            }
            else if(cbtinhtrangsach.SelectedIndex == 2)
            {
                tong = tien + 100000;
                lbltienphat.Text = "Tiền Phạt: " + tien + "+100000 :" ;
                textBox1.Text = tong.ToString();
            }
            
            else if (cbtinhtrangsach.SelectedIndex == 3)
            {
                tong = tien + 200000;
                lbltienphat.Text = "Tiền Phạt: " + tien + "+200000 :";
                textBox1.Text = tong.ToString();
            }


        }

        private void btntra_Click(object sender, EventArgs e)
        {
            try
            {
                int a =Convert.ToInt32(textBox1.Text);

                if (a < 0)
                { 
                    // insert to bảng nhận lại không có tiền phạt
                }
                else
                {
                    // insert to bảng nhận lại kèm bảng phiếu phạt
                }

               

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtngayquahan_TextChanged(object sender, EventArgs e)
        {
           

           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

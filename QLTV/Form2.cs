using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLoanManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public String Madg;
        public String ngaydukien;
        public String ngaytra;
        public String masach;
        private void Form2_Load(object sender, EventArgs e)
        {
          //DateTime  dt = DateTime.ParseExact(txtngaydukien.Text.ToString(), "dd-MM-yyyy-HH", CultureInfo.InvariantCulture);
          // DateTime dt2 = DateTime.ParseExact(txtngayTra.Text.ToString(), "dd-MM-yyyy-HH", CultureInfo.InvariantCulture);
            txtmaDG.Text = Madg  ;
            txtMaSach.Text = masach;
            txtngaydukien.Text = ngaydukien;
            txtngayTra.Text = ngaytra;
          //  compareDate(dt,dt2);

        }

        public void compareDate(DateTime dt,DateTime dt2)
        {

            dt =DateTime.ParseExact(txtngaydukien.Text.ToString(), "dd-MM-yyyy-HH", CultureInfo.InvariantCulture); 
            dt2= DateTime.ParseExact(txtngayTra.Text.ToString(), "dd-MM-yyyy-HH", CultureInfo.InvariantCulture);
            int yeardu= dt.Year;
            int monthdu= dt.Month;
            
            int yeartra = dt2.Year;
            int monthtra = dt2.Month;
            
            
            int tien = 0;
            int num = 0;

            if (yeardu<=yeartra && monthdu<monthtra)
            {

                txtName.Text = "tra Sach Dung han";
                txtTienPhat.Text = "Tổng tiền:" + tien;

            }
            else if (yeardu >= yeartra && monthdu > monthtra)
                    {
                txtName.Text = "Qua han tra sach " + num+" ngay";
                tien = num * 1000;
                txtTienPhat.Text = "Tổng Tiền:" + tien;
            }


           
                }
        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPhieuPhat frmPhieuPhat = new FrmPhieuPhat();
            MessageBox.Show("Thanh Toan Thanh Cong!");

           
            frmPhieuPhat.ShowDialog();  
        }
    }
}

using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookLoanManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public String Madg="";
        public String ngaydukien="";
        public String ngaytra="";
        public String masach="";

        private void Form2_Load(object sender, EventArgs e)
        {
           // DateTime  dt = DateTime.ParseExact(txtngaydukien.Text.ToString(), "dd-MM-yyyy-HH", CultureInfo.InvariantCulture);
           // DateTime dt2 = DateTime.ParseExact(txtngayTra.Text.ToString(), "dd-MM-yyyy-HH", CultureInfo.InvariantCulture);
            txtmaDG.Text = Madg;
            txtMaSach.Text = masach;
            txtngaydukien.Text = ngaydukien;
            txtngayTra.Text = ngaytra;
              //compareDate(dt,dt2);

        }

        public void compareDate(DateTime dt, DateTime dt2)
        {
            int songayquahan = 0;
            int tien = 0;
            dt = DateTime.ParseExact(
                txtngaydukien.Text.ToString(),
                "dd-MM-yyyy-HH",
                CultureInfo.InvariantCulture
            );
            dt2 = DateTime.ParseExact(
                txtngayTra.Text.ToString(),
                "dd-MM-yyyy-HH",
                CultureInfo.InvariantCulture
            );

            int dateiff = ((TimeSpan)(dt2 - dt)).Days;
            if (dateiff > 0)
            {
                songayquahan=dateiff;
                txtName.Text = "qua han " + songayquahan + "ngay";
                 tien = dateiff * 1000;
                txtTienPhat.Text = "Tổng Tiền:" + tien;

            }
            else
            {
                txtName.Text = "tra Sach Dung han";
                txtTienPhat.Text = "Tổng tiền:" + tien;
            }
            Form2 form2 = new Form2();  

           

            /*int yeardu = dt.Year;
            int monthdu = dt.Month;
            int daydu = dt.Day;
            int yeartra = dt2.Year;
            int monthtra = dt2.Month;
            int daytra = dt2.Day;

            int tien = 0;
            int num = 0;
            TimeSpan  t = dt2- dt;
            int songayhethan = 0;*/
            

            

            /*if (yeardu <= yeartra && monthdu <= monthtra && daydu <daytra)
            {
                txtName.Text = "Qua han tra sach " + num + " ngay";
                tien = num * 1000;
                txtTienPhat.Text = "Tổng Tiền:" + tien;
            }

            else if (yeardu > yeartra && monthdu >= monthtra && daydu>= daytra)
            {
                txtName.Text = "tra Sach Dung han";
                txtTienPhat.Text = "Tổng tiền:" + tien;
               
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPhieuPhat frmPhieuPhat = new FrmPhieuPhat();
            MessageBox.Show("Thanh Toan Thanh Cong!");

            frmPhieuPhat.ShowDialog();
        }
    }
}

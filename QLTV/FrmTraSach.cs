using QLTV;
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

        public string mapbg = "";
        public string madg = "";






        public void loadform()
        {

            txtmadg.Text = madg;

            txtmaphieubg.Text = mapbg;


            var trasach = (from s in db.TbSaches

                           join ctpg in db.TbCtPhieubangiaos on s.Maquyensach equals ctpg.Maquyensach

                           join pbg in db.TbPhieubangiaosaches on ctpg.Maphieubangiao equals pbg.Maphieubangiao
                           join nv in db.TbNhanViens on pbg.Manhanvien equals nv.Manhanvien

                           // join nl in db.TbBbNhanlaisaches on nv.Manhanvien equals nl.Manhanvien 
                           join d in db.TbDocgia on pbg.Mathedocgia equals d.Mathedocgia

                           where pbg.Maphieubangiao.ToString() == txtmaphieubg.Text
                           where pbg.Mathedocgia.ToString() == txtmadg.Text






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


            txtngayquahan.DataBindings.Clear();
            txtmadg.DataBindings.Clear();
           
            lbltienphat.DataBindings.Clear();
            txtmaphieubg.DataBindings.Clear();
            txtmasach.DataBindings.Clear(); ;
            txttendg.DataBindings.Clear();
            textBox1.DataBindings.Clear();


            dtpngaytra.Value = DateTime.Now;

            dtpdu.DataBindings.Add("Text", trasach, "Ngaydukientra");

            txttendg.DataBindings.Add("Text", trasach, "Hoten");


            txtmasach.DataBindings.Add("Text", trasach, "Maquyensach");



            txtmanv.Text = Convert.ToString( Frm_Main.tbc.Manhanvien);




            DateTime dt1 = dtpngaytra.Value;

            DateTime dt2 = dtpdu.Value;
            TimeSpan diff1 = dt1.Subtract(dt2);

            if (diff1.Days > 0)
            {


                txtngayquahan.Text = diff1.Days.ToString();
                txtngayquahan.ForeColor = Color.Red;

                lbltienphat.Text = "Tiền Phạt: " + diff1.Days * 1000 + ".0";

            }
            else
            {
                txtngayquahan.Text = "0";
                lbltienphat.Text = "0.0";
            }






            cbtinhtrangsach.SelectedIndex = 0;
        }
        private void FrmTraSach_Load(object sender, EventArgs e)

        {

            loadform();





        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            try

            {

                DateTime dt1 = dtpngaytra.Value;

                DateTime dt2 = dtpdu.Value;
                TimeSpan diff1 = dt1.Subtract(dt2);


                double tong = 0;
                if (diff1.Days > 0)
                {
                    double day = Convert.ToInt64(txtngayquahan.Text.ToString());
                    double tien = day * 1000;
                    if (cbtinhtrangsach.SelectedIndex == 0)
                    {
                        lbltienphat.Text = "Tiền Phạt: ";
                        textBox1.Text = tien.ToString();

                    }
                    else if (cbtinhtrangsach.SelectedIndex == 1)
                    {
                        tong = tien + 80000;
                        lbltienphat.Text = "Tiền Phạt: " + tien + "+80000 :";
                        textBox1.Text = tong.ToString();
                    }


                    else if (cbtinhtrangsach.SelectedIndex == 2)
                    {
                        tong = tien + 200000;
                        lbltienphat.Text = "Tiền Phạt: " + tien + "+200000 :";
                        textBox1.Text = tong.ToString();
                    }

                }
                else
                {
                    int tien = 0;
                    if (cbtinhtrangsach.SelectedIndex == 0)
                    {
                        lbltienphat.Text = "Tiền Phạt: ";
                        textBox1.Text = tien.ToString();

                    }
                    else if (cbtinhtrangsach.SelectedIndex == 1)
                    {
                        tong = tien + 80000;
                        lbltienphat.Text = "Tiền Phạt: +80000 :";
                        textBox1.Text = tong.ToString();
                    }


                    else if (cbtinhtrangsach.SelectedIndex == 2)
                    {
                        tong = tien + 200000;
                        lbltienphat.Text = "Tiền Phạt: +200000 :";
                        textBox1.Text = tong.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "error");
            }





        }

        private void btntra_Click(object sender, EventArgs e)
        {
            /* try
             {*/
            int a = Convert.ToInt32(textBox1.Text);



            // int tinhtrang = 0;
            string tinhtrangsach = "";

            if (cbtinhtrangsach.SelectedIndex == 0)
            {
                tinhtrangsach += "Nguyên Vẹn";
            }
            else if (cbtinhtrangsach.SelectedIndex == 1)
            {
                tinhtrangsach += "Hỏng";
            }
            else if (cbtinhtrangsach.SelectedIndex == 2)
            {
                tinhtrangsach += "mất";
            }

            if (a == 0)
            {
                // insert to bảng nhận lại không có tiền phạt

                TbBbNhanlaisach tbnl = new TbBbNhanlaisach()
                {

                    Mathedocgia = int.Parse(txtmadg.Text),
                    Manhanvien = int.Parse(txtmanv.Text),

                    Ngaytra = DateTime.Now



                };
                var addmabb = db.TbBbNhanlaisaches.OrderBy(n => n.Mabbnhanlai).Last();
                int manl = addmabb.Mabbnhanlai + 2;
                TbCtNhanlai ctnl = new TbCtNhanlai()
                {
                    Mabbnhanlai = manl,
                    Maquyensach = int.Parse(txtmasach.Text),
                    Tinhtrangnhanlai = tinhtrangsach.ToString(),

                };

                try
                {
                    db.TbBbNhanlaisaches.Add(tbnl);
                    db.SaveChanges();


                    db.TbCtNhanlais.Add(ctnl);
                    db.SaveChanges();
                    MessageBox.Show("Trả thành Công");

                    try
                    {
                        var delete = db.TbCtPhieubangiaos.SingleOrDefault(d => d.Maphieubangiao == int.Parse(txtmaphieubg.Text));

                        var delete1 = db.TbPhieubangiaosaches.SingleOrDefault(e => e.Maphieubangiao == int.Parse(txtmaphieubg.Text));

                        if (delete != null && delete1 != null)
                        {
                            db.TbCtPhieubangiaos.Remove(delete);
                            db.TbPhieubangiaosaches.Remove(delete1);
                            int count = db.SaveChanges();
                            if (count > 0)
                            {
                                MessageBox.Show("Phiếu mượn sách đã được xóa");
                                Close();

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "error");
                }




            }



            else

            {
                // insert to bảng nhận lại kèm bảng phiếu phạt

                TbBbNhanlaisach tbnl = new TbBbNhanlaisach()
                {

                    Mathedocgia = int.Parse(txtmadg.Text),
                    Manhanvien = int.Parse(txtmanv.Text),

                    Ngaytra = DateTime.Now



                };
                var addmabb = db.TbBbNhanlaisaches.OrderBy(n => n.Mabbnhanlai).Last();
                int manl1 = addmabb.Mabbnhanlai + 2;
                TbCtNhanlai ctnl = new TbCtNhanlai()
                {
                    Mabbnhanlai = manl1,
                    Maquyensach = int.Parse(txtmasach.Text),
                    Tinhtrangnhanlai = tinhtrangsach.ToString(),

                };

                TbPhieuphat pp = new TbPhieuphat()
                {
                    Mabbnhanlai = addmabb.Mabbnhanlai,
                    Tongtien = a,
                };
                var addmapp = db.TbPhieuphats.OrderBy(n => n.Maphieuphat).Last();
                int mapp = addmapp.Maphieuphat + 2;
                TbCtPhieuphat ctpp = new TbCtPhieuphat()
                {
                    Maphieuphat = mapp,
                    Maquyensach = int.Parse(txtmasach.Text),
                    Songayquahan = int.Parse(txtngayquahan.Text),
                    Tinhtranghong = tinhtrangsach.ToString()
                };
                try
                {
                    db.TbBbNhanlaisaches.Add(tbnl);
                    db.SaveChanges();


                    db.TbCtNhanlais.Add(ctnl);
                    db.SaveChanges();

                    db.TbPhieuphats.Add(pp);
                    db.SaveChanges();

                    db.TbCtPhieuphats.Add(ctpp);
                    db.SaveChanges();
                    MessageBox.Show("trả và thanh toán thành Công");
                    try
                    {
                        var delete = db.TbCtPhieubangiaos.SingleOrDefault(d => d.Maphieubangiao == int.Parse(txtmaphieubg.Text));

                        var delete1 = db.TbPhieubangiaosaches.SingleOrDefault(e => e.Maphieubangiao == int.Parse(txtmaphieubg.Text));

                        if (delete != null && delete1 != null)
                        {
                            db.TbCtPhieubangiaos.Remove(delete);

                            db.TbPhieubangiaosaches.Remove(delete1);

                            int count = db.SaveChanges();
                            if (count > 0)
                            {
                                MessageBox.Show("Phiếu mượn sách đã được xóa");
                                Close();

                            }
                        }
                    }
                    catch (Exception xx)
                    {
                        MessageBox.Show(xx.Message, "Error");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "error");
                }



            }



            //  }
            /* catch (Exception)
             {

                 throw;
             }*/
        }


    }
}

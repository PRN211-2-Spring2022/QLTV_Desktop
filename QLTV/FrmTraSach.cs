using System;
using QLTV.Models;
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
    public partial class FrmTraSach : Form
    {
        public FrmTraSach()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "phieuphat") { }
        }

        QLTV_DesktopContext QLTV = new QLTV_DesktopContext();

        public void load_traSach()
        {
            var trasach = (
                from d in QLTV.TbDocgia
                join pbg in QLTV.TbPhieubangiaosaches on d.Mathedocgia equals pbg.Mathedocgia
                join nv in QLTV.TbNhanViens on pbg.Manhanvien equals nv.Manhanvien
                join tr in QLTV.TbBbNhanlaisaches on nv.Manhanvien equals tr.Manhanvien
                join nl in QLTV.TbCtNhanlais on tr.Mabbnhanlai equals nl.Mabbnhanlai
                select new
                {
                    tr.Mabbnhanlai,
                    tr.Mathedocgia,
                    d.Hoten,
                    nl.Maquyensach,
                    nl.Tinhtrangnhanlai,
                    pbg.Ngaydukientra,
                    tr.Ngaytra
                }
            ).ToList();

            txtngaytra.DataBindings.Clear();
            textBox1.DataBindings.Clear();
            txtMadg.DataBindings.Clear();
            txtmatrasachs.DataBindings.Clear();

            txtngaytra.DataBindings.Add("Text", trasach, "Ngaytra");
            txtmatrasachs.DataBindings.Add("Text", trasach, "Mabbnhanlai");
            textBox1.DataBindings.Add("Text", trasach, "Ngaydukientra");
            txtMadg.DataBindings.Add("Text", trasach, "Mathedocgia");

            /*  DateTime dt = DateTime.ParseExact(txtngaytra.Text.ToString(), "dd-MM-yyyy-HH", CultureInfo.InvariantCulture);
            DateTime dt1 = DateTime.ParseExact(textBox1.Text.ToString(), "dd-MM-yyyy-HH", CultureInfo.InvariantCulture);
            
            if (dt > dt1)
            {
                textBox1.BackColor = Color.Red;
            }*/

            dataGridView1.DataSource = trasach;
        }

        private void FrmTraSach_Load(object sender, EventArgs e)
        {
            try
            {
                load_traSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public DataGridView datagridview
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }

        private void btnphieuphat_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Madg = txtMadg.Text.ToString();
            form2.masach = txtmatrasachs.Text.ToString();
            form2.ngaydukien = textBox1.Text.ToString();
            form2.ngaytra = txtngaytra.Text.ToString();
            form2.ShowDialog();

            /* 
            {


                var trasach = (from ppb in QLTV.TbCtPhieubangiaos

                               join pb in QLTV.TbPhieubangiaosaches on ppb.Maphieubangiao equals pb.Maphieubangiao
                               join d in QLTV.TbDocgia on pb.Mathedocgia equals d.Mathedocgia
                               join nl in QLTV.TbBbNhanlaisaches on d.Mathedocgia equals nl.Mathedocgia
                               join pp in QLTV.TbPhieuphats on nl.Mabbnhanlai equals pp.Mabbnhanlai

                               where d.Mathedocgia == Int32.Parse(txtMadg.Text)
                               where pb.Ngaydukientra.ToString() == textBox1.Text.ToString()
                               where nl.Ngaytra.ToString() == txtngaytra.Text.ToString()

                               select new
                               {
                                   pp.Maphieuphat,
                                   d.Hoten,
                                   ppb.Maquyensach,
                                   pb.Ngaydukientra,
                                   nl.Ngaytra,
                                   pp.Tongtien

                               }).ToList();

                FrmPhieuPhat frmPhieuPhat   =new FrmPhieuPhat();
               frmPhieuPhat.DataBindings.Clear();
                frmPhieuPhat.dataGriview.DataSource = trasach;
                frmPhieuPhat.ShowDialog();
             
            }
            catch (Exception)
            {

                throw;
            }


*/
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string seach = txtName.Text;
            var trasach = (
                from d in QLTV.TbDocgia
                join pbg in QLTV.TbPhieubangiaosaches on d.Mathedocgia equals pbg.Mathedocgia
                join nv in QLTV.TbNhanViens on pbg.Manhanvien equals nv.Manhanvien
                join tr in QLTV.TbBbNhanlaisaches on nv.Manhanvien equals tr.Manhanvien
                join nl in QLTV.TbCtNhanlais on tr.Mabbnhanlai equals nl.Mabbnhanlai
                where d.Hoten.Contains(seach)
                select new
                {
                    tr.Mabbnhanlai,
                    tr.Mathedocgia,
                    d.Hoten,
                    nl.Maquyensach,
                    nl.Tinhtrangnhanlai,
                    pbg.Ngaydukientra,
                    tr.Ngaytra
                }
            ).ToList();

            txtngaytra.DataBindings.Clear();
            textBox1.DataBindings.Clear();
            txtMadg.DataBindings.Clear();
            txtmatrasachs.DataBindings.Clear();

            txtmatrasachs.DataBindings.Add("Text", trasach, "Mabbnhanlai");
            txtngaytra.DataBindings.Add("Text", trasach, "Ngaytra");
            textBox1.DataBindings.Add("Text", trasach, "Ngaydukientra");
            txtMadg.DataBindings.Add("Text", trasach, "Mathedocgia");

            dataGridView1.DataSource = trasach;
        }

        private void label5_Click(object sender, EventArgs e) { }

        private void dataGridView1_CellMouseClick(
            object sender,
            DataGridViewCellMouseEventArgs e
        ) { }
    }
}

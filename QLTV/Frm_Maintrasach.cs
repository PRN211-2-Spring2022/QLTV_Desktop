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

namespace QLTV

{
    public partial class Frm_Maintrasach : UserControl
    {
        public Frm_Maintrasach()
        {
            InitializeComponent();
        }

        QLTV_DesktopContext QLTV = new QLTV_DesktopContext();

        private static Frm_Maintrasach _instance;
        public static Frm_Maintrasach Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Maintrasach();
                return _instance;
            }
        }

        public void load_Phieu()
        {


            var phieu = (
                from

                 p in QLTV.TbPhieubangiaosaches

                join d in QLTV.TbDocgia on p.Mathedocgia equals d.Mathedocgia
                
                join ctp in QLTV.TbCtPhieubangiaos on p.Maphieubangiao equals ctp.Maphieubangiao


                select new
                {
                    ctp.Maphieubangiao,
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



        

        private void FrmMain_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        

        private void btntraSach_Click(object sender, EventArgs e)
        {
            ViewTraSach frmTraSach = new ViewTraSach();
            frmTraSach.ShowDialog();
        }

       

        private static readonly string[] VietnameseSigns = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public static string RemoveSign4VietnameseString(string str)
        {
            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }

            return str;
        }

        

       

        private void button2_Click(object sender, EventArgs e)
        {
            FrmTraSach frmTraSach = new FrmTraSach();
            
            frmTraSach.madg = txtmadg.Text;
            frmTraSach.mapbg = txtMapbg.Text;

            frmTraSach.ShowDialog();



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


                if (txtsearchbyphieu.Text.Length > 0)
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
                MessageBox.Show(ex.Message, "error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_Phieu();
        }
    }
}

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
    public partial class FrmMain : UserControl
    {
        public FrmMain()

        {
            InitializeComponent();
        }
        QLTV_DesktopContext QLTV = new QLTV_DesktopContext();
        public void LoadDG()
        {
            var docgia = (from d in QLTV.TbDocgia
                          select new { d.Mathedocgia, d.Hoten, d.Ngaysinh, d.Diachi }).ToList();
            dataGridView1.DataSource = docgia;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDG();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

      
        

        private void btnmuonSach_Click(object sender, EventArgs e)
        {
            viewMuonSach viewMuonSach = new viewMuonSach();
            viewMuonSach.ShowDialog();
        }

        private void btntraSach_Click(object sender, EventArgs e)
        {
            FrmTraSach frmTraSach = new FrmTraSach();
            frmTraSach.ShowDialog();
        }
     

        private void searchByCode_Click(object sender, EventArgs e)
        {
            txtSearchByName.DataBindings.Clear();
            string search = textBox1.Text;
            
            try
            {
                var docgia = (from d in QLTV.TbDocgia where  d.Mathedocgia.ToString() == search
                              select new { d.Mathedocgia, d.Hoten, d.Ngaysinh, d.Diachi }).ToList();
                
               
                if (textBox1.Text.Trim().Length > 0)
                {
                    dataGridView1.DataSource = docgia;
                }
                else
                {
                    LoadDG();
                }

            }
            catch (Exception)
            {

                throw;
            }
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
        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            string search = txtSearchByName.Text;

            textBox1.DataBindings.Clear();
            try
            {
                var docgia = (from d in QLTV.TbDocgia where d.Hoten.Contains(search)

                              select new { d.Mathedocgia, d.Hoten, d.Ngaysinh, d.Diachi }).ToList();

                if(txtSearchByName.Text.Trim().Length > 0)
                {
                    dataGridView1.DataSource = docgia;

                }
                else
                {
                    LoadDG();
                }
               

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

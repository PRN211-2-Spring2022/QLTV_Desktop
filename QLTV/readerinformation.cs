using QLTV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class readerinformation : UserControl
    {
        public readerinformation()
        {
            InitializeComponent();
        }
        QLTV_DesktopContext QLTV_qldg = new QLTV_DesktopContext();

        public void Loadinformation()
        {
            var docgia = (from c in QLTV_qldg.TbDocgia
                           select new { c.Mathedocgia, c.Hoten, c.Ngaysinh, c.Ngaylamthe, c.Doituongdocgia, c.Diachi }).ToList();
            dgvthongtindocgia.DataSource = docgia;
            txtmathedocgia.DataBindings.Clear();
            txthoten.DataBindings.Clear();
            txtdiachi.DataBindings.Clear();
            txtmathedocgia.DataBindings.Add("Text", docgia, "Mathedocgia");
            txthoten.DataBindings.Add("Text", docgia, "Hoten");
            txtdiachi.DataBindings.Add("Text", docgia, "Diachi");
            dtxtngaylamthe.Value = new DateTime(2022, 03, 16);
        }
        private void readerinformation_Load(object sender, EventArgs e)
        {
            try
            {
                Loadinformation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Loadinformation();
            dtxtngaylamthe.Value = new DateTime(2022,03,16);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtmathedocgia.Text == "" )
            {
                MessageBox.Show("Mã thẻ độc giả không thể để trống");
                txtmathedocgia.Focus();
            }
            else if(!Regex.IsMatch(txtmathedocgia.Text.Trim(), @"\d$")){
                MessageBox.Show("");
                txtmathedocgia.Focus();
            }
            else if (txthoten.Text == "")
            {
                MessageBox.Show("Họ tên không thể để trống");
                txthoten.Focus();
            }
            else if (txtdiachi.Text == "")
            {
                MessageBox.Show("Địa chỉ không thể để trống");
                txtdiachi.Focus();
            }
            else if (boxdoituong.Text == "")
            {
                MessageBox.Show("Đối tượng không thể để trống");
                boxdoituong.Focus();
            }
            else 
            {
                TbDocgium docgia = new TbDocgium()
                {
                    Hoten = txthoten.Text,
                    Ngaysinh = dtxtngaysinh.Value,
                    Ngaylamthe = dtxtngaylamthe.Value,
                    Doituongdocgia = boxdoituong.Text,
                    Diachi = txtdiachi.Text,
                };
                try
                {
                    QLTV_qldg.TbDocgia.Add(docgia);
                    int count = QLTV_qldg.SaveChanges();
                    if(count > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                        Loadinformation();
                     }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtmathedocgia.Text == "")
            {
                MessageBox.Show("Mã thẻ độc giả không thể để trống");
                txtmathedocgia.Focus();
            }
            else if (!Regex.IsMatch(txtmathedocgia.Text.Trim(), @"\d$"))
            {
                MessageBox.Show("");
                txtmathedocgia.Focus();
            }
            else if (txthoten.Text == "")
            {
                MessageBox.Show("Họ tên không thể để trống");
                txthoten.Focus();
            }
            else if (txtdiachi.Text == "")
            {
                MessageBox.Show("Địa chỉ không thể để trống");
                txtdiachi.Focus();
            }
            else if (boxdoituong.Text == "")
            {
                MessageBox.Show("Đối tượng không thể để trống");
                boxdoituong.Focus();
            }
            else
            {
                TbDocgium docgia = new TbDocgium()
                {
                    Hoten = txthoten.Text,
                    Ngaysinh = dtxtngaysinh.Value,
                    Ngaylamthe = dtxtngaylamthe.Value,
                    Doituongdocgia = boxdoituong.Text,
                    Diachi = txtdiachi.Text,
                };
                try
                {
                    var update = QLTV_qldg.TbDocgia.SingleOrDefault(c => c.Mathedocgia == int.Parse(txtmathedocgia.Text));
                    if(update != null)
                    {
                        update.Hoten = txthoten.Text.Trim();
                        update.Diachi = txtdiachi.Text.Trim();
                        update.Doituongdocgia = boxdoituong.Text.Trim();
                        int count = QLTV_qldg.SaveChanges();
                        if(count > 0)
                        {
                            MessageBox.Show("Chỉnh sửa thành công");
                            Loadinformation();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            if(rbtnmathe.Checked == true && rbtnten.Checked == false)
            {
                var findbyma = (from b in QLTV_qldg.TbDocgia
                           where b.Mathedocgia == int.Parse(txtmathedocgia.Text.Trim())
                           select new { b.Mathedocgia, b.Hoten, b.Ngaysinh, b.Ngaylamthe, b.Doituongdocgia, b.Diachi }).ToList();
                dgvthongtindocgia.DataSource = findbyma;
            }
            else if(rbtnten.Checked == true && rbtnmathe.Checked == false)
            {
                var findbyten = (from b in QLTV_qldg.TbDocgia
                                 where b.Hoten == txthoten.Text.Trim()
                                 select new { b.Mathedocgia, b.Hoten, b.Ngaysinh, b.Ngaylamthe, b.Doituongdocgia, b.Diachi }).ToList();
                dgvthongtindocgia.DataSource = findbyten;
            }
            else if(txtfind.Text == "")
            {
                MessageBox.Show("Thông tin tìm kiếm không thể để trống");
                txtfind.Focus();
            }
            else if(rbtnmathe.Checked == false && rbtnten.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn thông tin tìm kiếm");
                rbtnmathe.Focus();
            }

        }
    }
}

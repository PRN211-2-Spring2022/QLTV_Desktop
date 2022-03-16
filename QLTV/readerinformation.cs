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
        private void readerinformation_Load(object sender, EventArgs e)
        {
            txtmathedocgia.DataBindings.Clear();
            txthoten.DataBindings.Clear();
            txtdiachi.DataBindings.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtmathedocgia.Clear();
            txthoten.Clear();
            txtdiachi.Clear();
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
                        var docgia0 = (from c in QLTV_qldg.TbDocgia
                                              select new { c.Mathedocgia, c.Hoten, c.Ngaysinh, c.Ngaylamthe, c.Doituongdocgia,c.Diachi }).ToList();
                        dgvthongtindocgia.DataSource = docgia0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                MessageBox.Show("");
                
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
                       // update.Ngaylamthe= dtxtngaylamthe.Value.
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                MessageBox.Show("");

            }
        }
    }
}

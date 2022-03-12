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
            txtmatkhau.DataBindings.Clear();
            txttaikhoan.DataBindings.Clear();
            txtdiachi.DataBindings.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtmathedocgia.DataBindings.Clear();
            txthoten.DataBindings.Clear();
            txtmatkhau.DataBindings.Clear();
            txttaikhoan.DataBindings.Clear();
            boxdoituong.DataBindings.Clear();
            txtdiachi.DataBindings.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtmathedocgia.Text != @"\d")
            {
                MessageBox.Show("");
                txtmathedocgia.Focus();
            }
            else if (txthoten.Text == "")
            {
                MessageBox.Show("Họ tên không thể để trống");
                txthoten.Focus();
            }
            else if (txttaikhoan.Text == "")
            {
                MessageBox.Show("Tài khoản không thể để trống");
                txttaikhoan.Focus();
            }
            else if (txtmatkhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không thể để trống");
                txtmatkhau.Focus();
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
                    Ngaysinh = dtxtngaysinh.MinDate,
                    Ngaylamthe = dtxtngaylamthe.MaxDate,
                    Doituongdocgia = boxdoituong.Text,
                    Diachi = txtdiachi.Text,
                };
                //TbAcount tk = new TbAcount() {
                //taikhoan = txttaikhoan,
                //matkhau = txtmatkhau};
                try
                {
                    QLTV_qldg.TbDocgia.Add(docgia);
                    int count = QLTV_qldg.SaveChanges();
                    if(count > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvthongtindocgia.DataSource = docgia;
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

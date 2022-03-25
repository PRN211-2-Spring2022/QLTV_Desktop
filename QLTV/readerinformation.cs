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

        private static readerinformation _instance;
        public static readerinformation Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new readerinformation();
                return _instance;
            }
        }
        public void Loadinformation()
        {
            var docgia = (from c in QLTV_qldg.TbDocgia
                          select new { c.Mathedocgia, c.Hoten, c.Ngaysinh, c.Ngaylamthe, c.Doituongdocgia, c.Diachi }).ToList();
            dgvthongtindocgia.DataSource = docgia;
            txthoten.DataBindings.Clear();
            txtdiachi.DataBindings.Clear();
            boxdoituong.DataBindings.Clear();
            txtfind.DataBindings.Clear();
            rbtnmathe.DataBindings.Clear();
            rbtnten.DataBindings.Clear();
            txtmathedocgia.DataBindings.Clear();
            dtxtngaylamthe.DataBindings.Clear();
            dtxtngaylamthe.DataBindings.Add("Text", docgia, "Ngaylamthe");
            dtxtngaysinh.DataBindings.Clear();
            dtxtngaysinh.DataBindings.Add("Text", docgia, "Ngaysinh");
            txtmathedocgia.DataBindings.Add("Text", docgia, "Mathedocgia");
            boxdoituong.DataBindings.Add("Text", docgia, "Doituongdocgia");
            txthoten.DataBindings.Add("Text", docgia, "Hoten");
            txtdiachi.DataBindings.Add("Text", docgia, "Diachi");
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
            //dgvthongtindocgia.DataSource = docgia;
            txthoten.Text = "";
            txtdiachi.Text = ""; ;
            boxdoituong.Text = "";
            txtfind.Text = "";
            rbtnmathe.DataBindings.Clear();
            rbtnten.DataBindings.Clear();
            txtmathedocgia.Text = "     ";
            dtxtngaylamthe.Value = DateTime.Now;
            rbtnmathe.Checked = false;
            rbtnten.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txthoten.Text == "")
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
            else if(dtxtngaylamthe.Value > DateTime.Now || dtxtngaylamthe.Value < DateTime.Now)
            {
                MessageBox.Show("Ngày làm thẻ là hôm nay");
                dtxtngaylamthe.Value = DateTime.Now;
                TbDocgium docgia = new TbDocgium()
                {
                    Hoten = txthoten.Text,
                    Ngaysinh = dtxtngaysinh.Value,
                    //Ngaylamthe = dtxtngaylamthe.Value,
                    Ngaylamthe = DateTime.Now,
                    Doituongdocgia = boxdoituong.Text,
                    Diachi = txtdiachi.Text,
                };
                try
                {
                    QLTV_qldg.TbDocgia.Add(docgia);
                    int count = QLTV_qldg.SaveChanges();
                    if (count > 0)
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
            else
            {
                TbDocgium docgia = new TbDocgium()
                {
                    Hoten = txthoten.Text,
                    Ngaysinh = dtxtngaysinh.Value,
                    //Ngaylamthe = dtxtngaylamthe.Value,
                    Ngaylamthe = DateTime.Now,
                    Doituongdocgia = boxdoituong.Text,
                    Diachi = txtdiachi.Text,
                };
                try
                {
                    QLTV_qldg.TbDocgia.Add(docgia);
                    int count = QLTV_qldg.SaveChanges();
                    if (count > 0)
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
            if (txthoten.Text == "")
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
                    if (update != null)
                    {
                        update.Hoten = txthoten.Text.Trim();
                        update.Diachi = txtdiachi.Text.Trim();
                        update.Doituongdocgia = boxdoituong.Text.Trim();
                        update.Ngaysinh = DateTime.Parse(dtxtngaysinh.Text);
                        int count = QLTV_qldg.SaveChanges();
                        if (count > 0)
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

        public void Loadbtnsearchma()
        {
            var findbyma = QLTV_qldg.TbDocgia
                .Where(m => m.Mathedocgia == int.Parse(txtfind.Text))
                .ToList();
            dgvthongtindocgia.DataSource = findbyma;
        }

        public void Loadbtsearchname()
        {
            var findbyten = QLTV_qldg.TbDocgia
                .Where(t => t.Hoten.Contains(txtfind.Text))
                .ToList();
            dgvthongtindocgia.DataSource = findbyten;
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            if (txtfind.Text == "")
            {
                MessageBox.Show("Thông tin tìm kiếm không thể để trống");
                txtfind.Focus();
            }
            else if(!Regex.IsMatch(txtfind.Text.Trim(),@"\d{3}$") && rbtnmathe.Checked ==true)
            {
                MessageBox.Show("Mã thẻ độc giả có dạng 3 chữ số");
                txtfind.Focus();
            }
            else if (rbtnmathe.Checked == true)
            {
                Loadbtnsearchma();
            }
            else if (rbtnten.Checked == true)
            {
                Loadbtsearchname();
            }
            else if (rbtnmathe.Checked == false && rbtnten.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn thông tin tìm kiếm");
                rbtnmathe.Focus();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var delete = QLTV_qldg.TbDocgia.SingleOrDefault(c => c.Mathedocgia == int.Parse(txtmathedocgia.Text));
                if (delete != null)
                {
                    DialogResult box = MessageBox.Show("Bạn có chắc chắn muốn xóa độc giả này?", "Thông báo", MessageBoxButtons.YesNo);
                    if (box == DialogResult.Yes)
                    {
                        QLTV_qldg.TbDocgia.Remove(delete);
                        int count = QLTV_qldg.SaveChanges();
                        if (count > 0)
                        {
                            MessageBox.Show("Xóa thành công");
                            Loadinformation();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dgvthongtindocgia_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Loadinformation();
        }
    }
}
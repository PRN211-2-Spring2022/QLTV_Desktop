using System;
using System.Data;
using System.Linq;
using System.Text;
using QLTV.Models;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QLTV
{
    public partial class UserManagerControl : UserControl
    {
        public UserManagerControl()
        {
            InitializeComponent();
        }

        QLTV_DesktopContext context = new QLTV_DesktopContext();

        private static UserManagerControl _instance;
        public static UserManagerControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserManagerControl();
                return _instance;
            }
        }

        void LoadInfo()
        {
            var users = (
                from a in context.TbAccounts
                join e in context.TbNhanViens on a.Manhanvien equals e.Manhanvien
                select new { e.Manhanvien, a.Username, e.Tennhanvien, a.Gmail, a.Password, a.Quyen }
            ).ToList();

            //Clear data binding
            tbID.DataBindings.Clear();
            tbUsername.DataBindings.Clear();
            tbEmployee.DataBindings.Clear();
            tbGmail.DataBindings.Clear();
            tbPassword.DataBindings.Clear();
            cbAdmin.DataBindings.Clear();

            //Add data binding
            tbID.DataBindings.Add("Text", users, "Manhanvien");
            tbUsername.DataBindings.Add("Text", users, "Username");
            tbEmployee.DataBindings.Add("Text", users, "Tennhanvien");
            tbGmail.DataBindings.Add("Text", users, "Gmail");
            tbPassword.DataBindings.Add("Text", users, "Password");
            cbAdmin.DataBindings.Add("Text", users, "Quyen");
            viewEmployee.DataSource = users;
            cbAdmin.DataSource = (from u in users select new { u.Quyen }).Distinct().ToList();
            cbAdmin.DisplayMember = "Quyen";
            cbAdmin.ValueMember = "Quyen";
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = cbShowPassword.Checked ? '\0' : '*';
        }

        private void UserManagerControl_Load(object sender, EventArgs e)
        {
            try
            {
                LoadInfo();
                btnRefresh_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải form");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbID.Text = "";
            tbUsername.Text = "";
            tbEmployee.Text = "";
            tbGmail.Text = "";
            tbPassword.Text = "";
            cbAdmin.Text = "";
            tbUsername.ReadOnly = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbEmployee.Text == "")
            {
                MessageBox.Show("Họ tên không thể để trống");
                tbEmployee.Focus();
            }
            else if (tbGmail.Text == "")
            {
                MessageBox.Show("Gmail không thể để trống");
                tbGmail.Focus();
            }
            else if (tbPassword.Text == "")
            {
                MessageBox.Show("Mật khẩu không thể để trống");
                tbPassword.Focus();
            }
            else if (cbAdmin.Text == "")
            {
                MessageBox.Show("Phân quyền không thể để trống");
                cbAdmin.Focus();
            }
            else
            {
                TbNhanVien nv = new TbNhanVien() { Tennhanvien = tbEmployee.Text.Trim(), };
                context.TbNhanViens.Add(nv);
                context.SaveChanges();
                nv = (from emp in context.TbNhanViens select emp).ToList().Last();
                TbAccount account = new TbAccount()
                {
                    Username = tbUsername.Text.Trim(),
                    Manhanvien = nv.Manhanvien,
                    Gmail = tbGmail.Text.Trim(),
                    Password = tbPassword.Text.Trim(),
                    Quyen = (int)Convert.ToUInt32(cbAdmin.Text.ToString()),
                };
                var accountItem = context.TbAccounts.FirstOrDefault(
                    x => x.Username == tbUsername.Text.Trim()
                );
                if (accountItem == null)
                {
                    context.TbAccounts.Add(account);
                    context.SaveChanges();
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại.");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tbEmployee.Text == "")
            {
                MessageBox.Show("Họ tên không thể để trống");
                tbEmployee.Focus();
            }
            else if (tbGmail.Text == "")
            {
                MessageBox.Show("Gmail không thể để trống");
                tbGmail.Focus();
            }
            else if (tbPassword.Text == "")
            {
                MessageBox.Show("Mật khẩu không thể để trống");
                tbPassword.Focus();
            }
            else if (cbAdmin.Text == "")
            {
                MessageBox.Show("Phân quyền không thể để trống");
                cbAdmin.Focus();
            }
            else
            {
                TbNhanVien nv = context.TbNhanViens.SingleOrDefault(
                    emp => emp.Manhanvien.ToString().Equals(tbID.Text.Trim())
                );
                TbAccount account = context.TbAccounts.SingleOrDefault(
                    acc => acc.Manhanvien.ToString().Equals(tbID.Text.Trim())
                );
                if (nv != null && account != null)
                {
                    nv.Tennhanvien = tbEmployee.Text.Trim();
                    account.Username = tbUsername.Text.Trim();
                    account.Gmail = tbGmail.Text.Trim();
                    account.Password = tbPassword.Text.Trim();
                    account.Quyen = (int)Convert.ToInt32(cbAdmin.Text.Trim());
                    int confirm = context.SaveChanges();
                    if (confirm > 0)
                    {
                        MessageBox.Show("Sửa thành công");
                    }
                }
                LoadInfo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TbNhanVien nv = context.TbNhanViens.SingleOrDefault(
                emp => emp.Manhanvien.ToString().Equals(tbID.Text.Trim())
            );
            TbAccount account = context.TbAccounts.SingleOrDefault(
                acc => acc.Manhanvien.ToString().Equals(tbID.Text.Trim())
            );
            if (nv != null || account != null)
            {
                DialogResult box = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa người dùng này?",
                    "Thông báo",
                    MessageBoxButtons.YesNo
                );
                if (box == DialogResult.Yes)
                {
                    context.TbNhanViens.Remove(nv);
                    context.TbAccounts.Remove(account);
                    int count = context.SaveChanges();
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadInfo();
                    }
                }
            }
        }
    }
}

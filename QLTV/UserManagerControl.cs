using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLTV.Models;

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
            cbAdmin.DataSource = (from u in users select new {u.Quyen}).Distinct().ToList();
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
                TbNhanVien nv = new TbNhanVien()
                {
                    Tennhanvien = tbEmployee.Text,
                };
                context.TbNhanViens.Add(nv);
                context.SaveChanges();
                nv = (from emp in context.TbNhanViens select emp).ToList().Last();
                TbAccount account = new TbAccount()
                {
                    Username = tbUsername.Text,
                    Manhanvien = nv.Manhanvien,
                    Gmail = tbGmail.Text,
                    Password = tbPassword.Text,
                    Quyen = (int)Convert.ToUInt32(cbAdmin.Text.ToString()),
                };
                context.TbAccounts.Add(account);
                int confirm = context.SaveChanges();
                if (confirm > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    LoadInfo();
                }
            }
        }
    }
}

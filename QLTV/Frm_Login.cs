using System;
using System.Data;
using System.Linq;
using System.Text;
using QLTV.Models;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QLTV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DateTime tn = DateTime.Now;
            lblTime.Text = tn.ToString("dd/MM/yyyy");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string account = txtAccount.Text;
                string password = txtAccount.Text;
                QLTV_DesktopContext Des = new QLTV_DesktopContext();
                if (account == null || account.Equals(""))
                {
                    MessageBox.Show("Chưa nhập tên tài khoản!");
                    return;
                }
                if (password == null || password.Equals(""))
                {
                    MessageBox.Show("Chưa nhập mật khẩu!");
                    return;
                }
                TbAccount acc = Des.TbAccounts.SingleOrDefault(
                    a =>
                        a.Username.Equals(txtAccount.Text.Trim())
                        && a.Password.Equals(txtPassword.Text.Trim())
                );
                TbNhanVien nv = Des.TbNhanViens.SingleOrDefault(
                    e => e.Manhanvien.Equals(acc.Manhanvien)
                );

                if (acc != null)
                {
                    MessageBox.Show(
                        "Đăng nhập thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    Frm_Main frM = new Frm_Main(acc, nv);
                    frM.Show();
                    this.Hide();
                }
                else
                {
                    lblIncorrect.Text = "Account or Password is incorrect!";
                    txtAccount.Text = "";
                    txtPassword.Text = "";
                    txtAccount.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác !");
            }
        }

        private void ckbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show(
                "Do you really want to exit?",
                "Notification",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );
            if (tb == DialogResult.OK)
                Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}

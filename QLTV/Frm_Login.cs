using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLTV.Models;
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
                    MessageBox.Show("Please enter your gmail and password first!");
                    return;
                }
                if (password == null || password.Equals(""))
                {
                    MessageBox.Show("Please enter your gmail and password first!");
                    return;
                }
                TbAccount acc = Des.TbAccounts.SingleOrDefault(a => a.Username.Equals(txtAccount.Text.Trim()) && a.Password.Equals(txtPassword.Text.Trim()));
                TbNhanVien nv = Des.TbNhanViens.SingleOrDefault(e => e.Manhanvien.Equals(acc.Manhanvien));

                if (account != null)
                {
                    MessageBox.Show("Login Succeed!", "Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Frm_Main frM = new Frm_Main(acc,nv);
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
                MessageBox.Show(ex.Message);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Do you really want to exit?","Notification",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
        }
        
    }
}

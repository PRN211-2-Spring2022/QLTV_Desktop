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
namespace FormLogin
{
    public partial class Form1 : Form
    {
        string strConnection = @"Data Source=DESKTOP-DI5QIMA\SQLEXPRESS;Initial Catalog=QLTV_Desktop;Integrated Security=True";
        SqlConnection conn;
        SqlCommand command;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Select Count(*) From [QLTV_Desktop].[dbo].[tb_Acount] Where Gmail=@acc and Password=@pass";
                conn = new SqlConnection(strConnection);
                conn.Open();
                command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@acc", txtAccount.Text));
                command.Parameters.Add(new SqlParameter("@pass", txtPassword.Text));
                int x = (int)command.ExecuteScalar();
                if (x == 1)
                {
                    MessageBox.Show("Login succeed!", "Notification",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Login Failed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTaikhoan_TextChanged(object sender, EventArgs e)
        {

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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Do you really want to exit?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblAccount_Click(object sender, EventArgs e)
        {

        }
    }
}

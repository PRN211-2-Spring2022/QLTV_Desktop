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
namespace QLTV
{
    public partial class Form1 : Form
    {
        
        
        string strConnection = @"Data Source=DESKTOP-DI5QIMA\SQLEXPRESS;Initial Catalog=QLTV_Desktop;Integrated Security=True";
        SqlConnection conn;
        SqlCommand command;
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
                string sql = "Select Count (*) From [QLTV_Desktop].[dbo].[tb_Acount] Where Gmail=@acc And Password=@pass";
                conn = new SqlConnection(strConnection);
                conn.Open();
                command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@acc", txtAccount.Text));
                command.Parameters.Add(new SqlParameter("@pass", txtPassword.Text));
                int x = (int)command.ExecuteScalar();
                if (x == 1)
                {
                    MessageBox.Show("Login Succeed!", "Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Frm_Main frM = new Frm_Main();
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

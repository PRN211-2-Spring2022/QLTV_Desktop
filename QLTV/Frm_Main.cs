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
    public partial class Frm_Main : Form
    {
        public Frm_Main(String account, string mnv)
        {
            InitializeComponent();
            lbUsername.Text = account;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_BookManagement_Click(object sender, EventArgs e)
        {
                //Add module to panel control
                if (!Pn_Main.Controls.Contains(BookManagement.Instance))
                {
                    Pn_Main.Controls.Add(BookManagement.Instance);
                    BookManagement.Instance.Dock = DockStyle.Fill;
                    BookManagement.Instance.BringToFront();
                }
                else
                    BookManagement.Instance.BringToFront();
            //btn_BookManagement.BackColor = Color.White;
        }

        private void btn_UserManagement_Click(object sender, EventArgs e)
        {
            //Add module to panel control
            if (!Pn_Main.Controls.Contains(UserManagerControl.Instance))
            {
                Pn_Main.Controls.Add(UserManagerControl.Instance);
                UserManagerControl.Instance.Dock = DockStyle.Fill;
                UserManagerControl.Instance.BringToFront();
            }
            else
                UserManagerControl.Instance.BringToFront();
        }

        private void btn_ReaderManagement_Click(object sender, EventArgs e)
        {
                //Add module to panel control
                if (!Pn_Main.Controls.Contains(readerinformation.Instance))
                {
                    Pn_Main.Controls.Add(readerinformation.Instance);
                    readerinformation.Instance.Dock = DockStyle.Fill;
                    readerinformation.Instance.BringToFront();
                }
                else
                    readerinformation.Instance.BringToFront();
            //btn_ReaderManagement.BackColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

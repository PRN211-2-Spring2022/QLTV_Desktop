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
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public Frm_Main(TbAccount account, TbNhanVien nv)
        {
            InitializeComponent();
            lbUsername.Text = nv.Tennhanvien;
            tbc = account;
        }
        public TbAccount tbc { get; set; }

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
       
        private void btn_ReturnManagement_Click(object sender, EventArgs e)
        {
            //Add module to panel control
            if (!Pn_Main.Controls.Contains(Frm_Maintrasach.Instance))
            {
                Pn_Main.Controls.Add(Frm_Maintrasach.Instance);
                Frm_Maintrasach.Instance.Dock = DockStyle.Fill;
                Frm_Maintrasach.Instance.BringToFront();
            }
            else
                Frm_Maintrasach.Instance.BringToFront();
        }

        private void btn_LoanManagement_Click(object sender, EventArgs e)
        {
            //Add module to panel control
            if (!Pn_Main.Controls.Contains(Frmmuonsach.Instance))
            {
                Pn_Main.Controls.Add(Frmmuonsach.Instance);
                Frmmuonsach.Instance.Dock = DockStyle.Fill;
                Frmmuonsach.Instance.BringToFront();
            }
            else
                Frmmuonsach.Instance.BringToFront();
        }
    }
}

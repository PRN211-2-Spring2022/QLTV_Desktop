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
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_BookManagement_Click(object sender, EventArgs e)
        {
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
            }
        }

        private void btn_UserManagement_Click(object sender, EventArgs e)
        {

        }
    }
}

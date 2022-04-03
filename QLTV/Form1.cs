using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookLoanManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Frm_Maintrasach frmMain = new Frm_Maintrasach();

        private void Form1_Load(object sender, EventArgs e)
        {
            frmMain.Dock = DockStyle.Fill;
            Controls.Add(frmMain);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        /* private void frmMain1_Load(object sender, EventArgs e) { }

         private void frmMain1_Load_1(object sender, EventArgs e)
         {

         }*/
    }
}

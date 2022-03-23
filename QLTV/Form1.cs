using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLoanManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       FrmMain frmMain = new FrmMain();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            frmMain.Dock = DockStyle.Fill;
            Controls.Add(frmMain);
        }

        private void frmMain1_Load(object sender, EventArgs e)
        {

        }
    }
}

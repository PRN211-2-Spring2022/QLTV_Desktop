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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        readerinformation readmanagement = new readerinformation();
        private void Form1_Load(object sender, EventArgs e)
        {
            readmanagement.Dock = DockStyle.Fill;
            Controls.Add(readmanagement);
        }
    }
}

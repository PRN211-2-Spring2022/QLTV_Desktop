using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QLTV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BookManagement bookManagement = new BookManagement();

        private void Form1_Load(object sender, EventArgs e)
        {
            bookManagement.Dock = DockStyle.Fill;
            Controls.Add(bookManagement);
        }
    }
}

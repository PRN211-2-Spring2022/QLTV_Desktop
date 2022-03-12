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
    public partial class readermanagement : UserControl
    {
        public readermanagement()
        {
            InitializeComponent();
        }

        private void btnTimkiemdocgia_Click(object sender, EventArgs e)
        {
            UserControl findreader = new findreader();
            findreader.Dock = DockStyle.Fill;
            Controls.Add(findreader);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserControl reader = new readerinformation();
            reader.Dock = DockStyle.Fill;
            Controls.Add((reader));
        }
    }
}

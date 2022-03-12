using System;
using QLTV.Models;
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
    public partial class BookManagement : UserControl
    {
        public BookManagement()
        {
            InitializeComponent();
        }

        QLTV_DesktopContext QLTV_Desktop = new QLTV_DesktopContext();

        public void LoadBooks()
        {
            var books = (
                from b in QLTV_Desktop.TbDausaches
                select new { b.Madausach, b.Tendausach, b.Soluong, b.Sotrang }
            ).ToList();
            txtSearch.DataBindings.Clear();

            dgvBook.DataSource = books;
        }

        private void BookManagement_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Data");
            }
        }
    }
}

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

            // Clear dataBinding
            txtID.DataBindings.Clear();
            txtSearch.DataBindings.Clear();

            // Add dataBinding
            txtID.DataBindings.Add("Text", books, "Madausach");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addBook = new AddBook();
            addBook.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var bookItem = QLTV_Desktop.TbDausaches.SingleOrDefault(
                    b => b.Madausach == Int32.Parse(txtID.Text)
                );
                if (bookItem != null)
                {
                    QLTV_Desktop.TbDausaches.Remove(bookItem);
                    int count = QLTV_Desktop.SaveChanges();
                    if (count > 0)
                    {
                        MessageBox.Show("Delete successful.");
                        LoadBooks();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete failed.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var editBook = new EditBook();
            editBook.Show();
        }
    }
}

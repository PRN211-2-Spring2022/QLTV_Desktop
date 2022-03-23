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

        public static string BookId = "";

        QLTV_DesktopContext QLTV_Desktop = new QLTV_DesktopContext();

        public void LoadBooks()
        {
            var books = (
                from b in QLTV_Desktop.TbDausaches
                select new { b.Madausach, b.Tendausach, b.Soluong, b.Sotrang }
            ).ToList();

            var authors = (
                from a in QLTV_Desktop.TbTacgia
                select new { a.Matacgia, a.Tentacgia }
            ).ToList();

            // Clear dataBinding
            txtBookID.DataBindings.Clear();
            txtAuthorID.DataBindings.Clear();
            txtSearch.DataBindings.Clear();

            // Add dataBinding
            txtBookID.DataBindings.Add("Text", books, "Madausach");
            txtAuthorID.DataBindings.Add("Text", authors, "Matacgia");
            dgvBook.DataSource = books;
            dgvAuthor.DataSource = authors;
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

        //private void btnDeleteBook_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var bookItem = QLTV_Desktop.TbDausaches.FirstOrDefault(
        //            b => b.Madausach == Int32.Parse(txtBookID.Text)
        //        );
        //        var bookAuthor = QLTV_Desktop.TbCtTacgia.FirstOrDefault(
        //            ab => ab.Madausach == Int32.Parse(txtBookID.Text)
        //        );

        //        if (bookAuthor != null)
        //        {
        //            QLTV_Desktop.TbCtTacgia.Remove(bookAuthor);
        //            QLTV_Desktop.SaveChanges();
        //        }
        //        if (bookItem != null)
        //        {
        //            QLTV_Desktop.TbDausaches.Remove(bookItem);
        //            QLTV_Desktop.SaveChanges();
        //            MessageBox.Show("Delete successful.");
        //            LoadBooks();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Delete failed.");
        //    }
        //}

        private void btnDeleteAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                var authorItem = QLTV_Desktop.TbTacgia.FirstOrDefault(
                    a => a.Matacgia == Int32.Parse(txtAuthorID.Text)
                );
                var bookAuthor = QLTV_Desktop.TbCtTacgia.FirstOrDefault(
                    ab => ab.Matacgia == Int32.Parse(txtAuthorID.Text)
                );

                if (bookAuthor != null)
                {
                    QLTV_Desktop.TbCtTacgia.Remove(bookAuthor);
                    QLTV_Desktop.SaveChanges();
                }
                if (authorItem != null)
                {
                    QLTV_Desktop.TbTacgia.Remove(authorItem);
                    QLTV_Desktop.SaveChanges();
                    MessageBox.Show("Delete successful.");
                    LoadBooks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete failed.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BookId = txtBookID.Text;
            var editBook = new EditBook();
            editBook.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadBooks();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Data");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdBook.Checked)
            {
                var books = QLTV_Desktop.TbDausaches
                    .Where(b => b.Tendausach.Contains(txtSearch.Text))
                    .ToList();
                dgvBook.DataSource = books;
                Refresh();
            }
            else if (rdAuthor.Checked)
            {
                var authors = QLTV_Desktop.TbTacgia
                    .Where(a => a.Tentacgia.Contains(txtSearch.Text))
                    .ToList();
                dgvAuthor.DataSource = authors;
                Refresh();
            }
        }
    }
}

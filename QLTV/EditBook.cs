using System;
using System.Data;
using System.Linq;
using System.Text;
using QLTV.Models;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLTV
{
    public partial class EditBook : Form
    {
        public EditBook()
        {
            InitializeComponent();
        }

        QLTV_DesktopContext QLTV_Desktop = new QLTV_DesktopContext();

        public void LoadEditBook()
        {
            txtBookID.Text = BookManagement.BookId;

            var books = QLTV_Desktop.TbDausaches.FirstOrDefault(
                b => b.Madausach == Int32.Parse(txtBookID.Text)
            );
            if (books != null)
            {
                var authorBook = QLTV_Desktop.TbCtTacgia.FirstOrDefault(
                    ab => ab.Madausach == books.Madausach
                );
                if (authorBook != null)
                {
                    var authors = QLTV_Desktop.TbTacgia.FirstOrDefault(
                        a => a.Matacgia == authorBook.Matacgia
                    );
                    txtAuthor.Text = authors.Tentacgia;
                }
            }

            // Clear dataBinding
            txtBookID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPage.DataBindings.Clear();
            txtAuthor.DataBindings.Clear();

            // Add dataBinding
            txtName.DataBindings.Add("Text", books, "Tendausach");
            txtPage.DataBindings.Add("Text", books, "Sotrang");
        }

        private void EditBook_Load(object sender, EventArgs e)
        {
            try
            {
                LoadEditBook();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading edit book form.");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "" && txtAuthor.Text != "")
                {
                    var bookItem = QLTV_Desktop.TbDausaches.FirstOrDefault(
                        b => b.Madausach == Int32.Parse(txtBookID.Text)
                    );

                    if (bookItem != null)
                    {
                        bookItem.Tendausach = txtName.Text.Trim();
                        bookItem.Sotrang = Int32.Parse(txtPage.Text.Trim());
                        QLTV_Desktop.SaveChanges();

                        var authorBook = QLTV_Desktop.TbCtTacgia.FirstOrDefault(
                            ab => ab.Madausach == bookItem.Madausach
                        );
                        var authorItem = QLTV_Desktop.TbTacgia.FirstOrDefault(
                            a => a.Tentacgia == txtAuthor.Text
                        );

                        if (authorItem != null)
                        {
                            QLTV_Desktop.Remove(authorBook);
                            QLTV_Desktop.SaveChanges();
                            var authorBookQuery = QLTV_Desktop.TbCtTacgia.Add(
                                new TbCtTacgium
                                {
                                    Madausach = bookItem.Madausach,
                                    Matacgia = authorItem.Matacgia,
                                    Vaitrotacgia = "Chủ biên"
                                }
                            );
                            QLTV_Desktop.SaveChanges();

                            MessageBox.Show("Edit successfull.");
                            LoadEditBook();
                            Close();
                        }
                        else
                        {
                            var authorQuery = QLTV_Desktop.TbTacgia.Add(
                                new TbTacgium { Tentacgia = txtAuthor.Text }
                            );
                            QLTV_Desktop.SaveChanges();
                            var addedAuthor = QLTV_Desktop.TbTacgia.OrderBy(a => a.Matacgia).Last();

                            QLTV_Desktop.Remove(authorBook);
                            QLTV_Desktop.SaveChanges();
                            var authorBookQuery = QLTV_Desktop.TbCtTacgia.Add(
                                new TbCtTacgium
                                {
                                    Madausach = bookItem.Madausach,
                                    Matacgia = addedAuthor.Matacgia,
                                    Vaitrotacgia = "Chủ biên"
                                }
                            );
                            QLTV_Desktop.SaveChanges();

                            MessageBox.Show("Edit successfull.");
                            LoadEditBook();
                            Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Fields cannot be empty.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit failed.");
            }
        }
    }
}

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
            var books = QLTV_Desktop.TbDausaches.FirstOrDefault(
                b => b.Madausach == Int32.Parse(BookManagement.BookId)
            );
            var authors = (
                from a in QLTV_Desktop.TbTacgia
                select new { a.Matacgia, a.Tentacgia }
            ).ToList();
            var publishers = (
                from p in QLTV_Desktop.TbNhaXuatBans
                select new { p.Manhaxuatban, p.Tennhaxuatban }
            ).ToList();

            // Clear dataBinding
            txtName.DataBindings.Clear();
            txtPage.DataBindings.Clear();
            cbAuthor.DataBindings.Clear();
            cbPublisher.DataBindings.Clear();

            // Add dataBinding
            txtName.DataBindings.Add("Text", books, "Tendausach");
            txtPage.DataBindings.Add("Text", books, "Sotrang");
            cbAuthor.DataSource = authors;
            cbAuthor.DisplayMember = "Tentacgia";
            cbAuthor.ValueMember = "Matacgia";
            cbPublisher.DataSource = publishers;
            cbPublisher.DisplayMember = "Tennhaxuatban";
            cbPublisher.ValueMember = "Manhaxuatban";

            if (books != null)
            {
                var authorBook = QLTV_Desktop.TbCtTacgia.FirstOrDefault(
                    ab => ab.Madausach == books.Madausach
                );
                if (authorBook != null)
                {
                    var author = QLTV_Desktop.TbTacgia.FirstOrDefault(
                        a => a.Matacgia == authorBook.Matacgia
                    );
                    cbAuthor.SelectedValue = author.Matacgia;
                }
            }
        }

        private void EditBook_Load(object sender, EventArgs e)
        {
            try
            {
                LoadEditBook();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải form.");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
                    var bookItem = QLTV_Desktop.TbDausaches.FirstOrDefault(
                        b => b.Madausach == Int32.Parse(BookManagement.BookId)
                    );

                    if (bookItem != null)
                    {
                        var publisherItem = QLTV_Desktop.TbNhaXuatBans.FirstOrDefault(
                            p => p.Tennhaxuatban == cbPublisher.Text
                        );

                        if (publisherItem != null)
                        {
                            bookItem.Tendausach = txtName.Text.Trim();
                            bookItem.Sotrang = Int32.Parse(txtPage.Text.Trim());
                            bookItem.Manhaxuatban = publisherItem.Manhaxuatban;
                            QLTV_Desktop.SaveChanges();
                        }
                        else
                        {
                            var publisherQuery = QLTV_Desktop.TbNhaXuatBans.Add(
                                new TbNhaXuatBan { Tennhaxuatban = cbPublisher.Text }
                            );
                            var addedPublisher = QLTV_Desktop.TbNhaXuatBans
                                .OrderBy(p => p.Manhaxuatban)
                                .Last();
                            bookItem.Tendausach = txtName.Text.Trim();
                            bookItem.Sotrang = Int32.Parse(txtPage.Text.Trim());
                            bookItem.Manhaxuatban = addedPublisher.Manhaxuatban;
                            QLTV_Desktop.SaveChanges();
                        }

                        var authorBook = QLTV_Desktop.TbCtTacgia.FirstOrDefault(
                            ab => ab.Madausach == bookItem.Madausach
                        );
                        var authorItem = QLTV_Desktop.TbTacgia.FirstOrDefault(
                            a => a.Tentacgia == cbAuthor.Text
                        );

                        if (authorItem != null)
                        {
                            if (authorBook != null)
                            {
                                QLTV_Desktop.Remove(authorBook);
                                QLTV_Desktop.SaveChanges();
                            }

                            var authorBookQuery = QLTV_Desktop.TbCtTacgia.Add(
                                new TbCtTacgium
                                {
                                    Madausach = bookItem.Madausach,
                                    Matacgia = authorItem.Matacgia,
                                    Vaitrotacgia = "Chủ biên"
                                }
                            );
                            QLTV_Desktop.SaveChanges();

                            MessageBox.Show("Sửa thành công.");
                            Close();
                        }
                        else
                        {
                            var authorQuery = QLTV_Desktop.TbTacgia.Add(
                                new TbTacgium { Tentacgia = cbAuthor.Text }
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

                            MessageBox.Show("Sửa thành công.");
                            Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không được để trống thông tin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sửa thất bại.");
            }
        }
    }
}

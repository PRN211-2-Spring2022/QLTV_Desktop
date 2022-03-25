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

namespace QLTV
{
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        QLTV_DesktopContext QLTV_Desktop = new QLTV_DesktopContext();

        public void LoadAddBook()
        {
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
            cbAuthor.DataSource = authors;
            cbAuthor.DisplayMember = "Tentacgia";
            cbAuthor.ValueMember = "Matacgia";
            cbPublisher.DataSource = publishers;
            cbPublisher.DisplayMember = "Tennhaxuatban";
            cbPublisher.ValueMember = "Manhaxuatban";
        }

        private void AddBook_Load(object sender, EventArgs e)
        {
            try
            {
                LoadAddBook();
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
                    var bookItem = (
                        from b in QLTV_Desktop.TbDausaches
                        join p in QLTV_Desktop.TbNhaXuatBans on b.Manhaxuatban equals p.Manhaxuatban
                        where b.Tendausach == txtName.Text && p.Tennhaxuatban == cbPublisher.Text
                        select b
                    );

                    if (bookItem == null)
                    {
                        var publisherItem = QLTV_Desktop.TbNhaXuatBans.FirstOrDefault(
                            p => p.Tennhaxuatban == cbPublisher.Text
                        );

                        if (publisherItem != null)
                        {
                            var bookQuery = QLTV_Desktop.TbDausaches.Add(
                                new TbDausach
                                {
                                    Tendausach = txtName.Text,
                                    Soluong = 0,
                                    Sotrang = Int32.Parse(txtPage.Text),
                                    Manhaxuatban = publisherItem.Manhaxuatban,
                                }
                            );
                            QLTV_Desktop.SaveChanges();
                        }
                        else
                        {
                            var publisherQuery = QLTV_Desktop.TbNhaXuatBans.Add(
                                new TbNhaXuatBan { Tennhaxuatban = cbPublisher.Text }
                            );
                            QLTV_Desktop.SaveChanges();

                            var addedPublisher = QLTV_Desktop.TbNhaXuatBans
                                .OrderBy(p => p.Manhaxuatban)
                                .Last();
                            var bookQuery = QLTV_Desktop.TbDausaches.Add(
                                new TbDausach
                                {
                                    Tendausach = txtName.Text,
                                    Soluong = 0,
                                    Sotrang = Int32.Parse(txtPage.Text),
                                    Manhaxuatban = addedPublisher.Manhaxuatban
                                }
                            );
                            QLTV_Desktop.SaveChanges();
                        }

                        var addedBook = QLTV_Desktop.TbDausaches.OrderBy(b => b.Madausach).Last();
                        var authorItem = QLTV_Desktop.TbTacgia.FirstOrDefault(
                            a => a.Tentacgia == cbAuthor.Text
                        );

                        if (authorItem != null)
                        {
                            var authorBookQuery = QLTV_Desktop.TbCtTacgia.Add(
                                new TbCtTacgium
                                {
                                    Madausach = addedBook.Madausach,
                                    Matacgia = authorItem.Matacgia,
                                    Vaitrotacgia = "Chủ biên"
                                }
                            );
                            QLTV_Desktop.SaveChanges();

                            MessageBox.Show("Thêm thành công.");
                            Close();
                        }
                        else
                        {
                            var authorQuery = QLTV_Desktop.TbTacgia.Add(
                                new TbTacgium { Tentacgia = cbAuthor.Text }
                            );
                            QLTV_Desktop.SaveChanges();

                            var addedAuthor = QLTV_Desktop.TbTacgia.OrderBy(a => a.Matacgia).Last();
                            var authorBookQuery = QLTV_Desktop.TbCtTacgia.Add(
                                new TbCtTacgium
                                {
                                    Madausach = addedBook.Madausach,
                                    Matacgia = addedAuthor.Matacgia,
                                    Vaitrotacgia = "Chủ biên"
                                }
                            );
                            QLTV_Desktop.SaveChanges();

                            MessageBox.Show("Thêm thành công.");
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đầu sách đã tồn tại.");
                    }
                }
                else
                {
                    MessageBox.Show("Không được để trống thông tin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm thất bại.");
            }
        }
    }
}

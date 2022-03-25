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
            // Clear dataBinding
            txtName.DataBindings.Clear();
            txtPage.DataBindings.Clear();
            txtAuthor.DataBindings.Clear();
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
                if (txtName.Text != "" && txtAuthor.Text != "")
                {
                    var bookQuery = QLTV_Desktop.TbDausaches.Add(
                        new TbDausach
                        {
                            Tendausach = txtName.Text,
                            Soluong = 0,
                            Sotrang = Int32.Parse(txtPage.Text)
                        }
                    );
                    QLTV_Desktop.SaveChanges();

                    var addedBook = QLTV_Desktop.TbDausaches.OrderBy(b => b.Madausach).Last();
                    var authorItem = QLTV_Desktop.TbTacgia.FirstOrDefault(
                        a => a.Tentacgia == txtAuthor.Text
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
                            new TbTacgium { Tentacgia = txtAuthor.Text }
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

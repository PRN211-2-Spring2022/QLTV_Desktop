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
    public partial class AddQuantity : Form
    {
        public AddQuantity()
        {
            InitializeComponent();
        }

        QLTV_DesktopContext QLTV_Desktop = new QLTV_DesktopContext();

        private void AddQuantity_Load(object sender, EventArgs e) { }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQuantity.Text != "")
                {
                    var books = QLTV_Desktop.TbDausaches.FirstOrDefault(
                        b => b.Madausach == Int32.Parse(BookManagement.BookId)
                    );
                    books.Soluong += Int32.Parse(txtQuantity.Text);
                    QLTV_Desktop.SaveChanges();

                    for (int i = 0; i < Int32.Parse(txtQuantity.Text); i++)
                    {
                        var bookQuery = QLTV_Desktop.TbSaches.Add(
                            new TbSach
                            {
                                Madausach = Int32.Parse(BookManagement.BookId),
                                Tinhtrangsach = 1
                            }
                        );
                        QLTV_Desktop.SaveChanges();
                    }

                    MessageBox.Show("Thêm sách thành công.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm sách thất bại.");
            }
        }
    }
}

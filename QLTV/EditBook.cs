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
    public partial class EditBook : Form
    {
        public EditBook()
        {
            InitializeComponent();
        }

        QLTV_DesktopContext QLTV_Desktop = new QLTV_DesktopContext();

        public void LoadEditBook()
        {
            var books = (
                from b in QLTV_Desktop.TbDausaches
                select new { b.Madausach, b.Tendausach, b.Soluong, b.Sotrang }
            ).ToList();

            // Clear dataBinding
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();
            txtPage.DataBindings.Clear();

            // Add dataBinding
            txtID.DataBindings.Add("Text", books, "Madausach");
            txtName.DataBindings.Add("Text", books, "Tendausach");
            txtPage.DataBindings.Add("Text", books, "Sotrang");
            txtQuantity.DataBindings.Add("Text", books, "Soluong");
        }

        private void EditBook_Load(object sender, EventArgs e)
        {
            try
            {
                LoadEditBook();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading edit book form.");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            TbDausach dausach = new TbDausach
            {
                Madausach = Int32.Parse(txtID.Text),
                Tendausach = txtName.Text,
                Soluong = Int32.Parse(txtQuantity.Text),
                Sotrang = Int32.Parse(txtPage.Text)
            };
            try
            {
                var bookItem = QLTV_Desktop.TbDausaches.SingleOrDefault(
                    b => b.Madausach == Int32.Parse(txtID.Text)
                );
                if (bookItem != null)
                {
                    bookItem.Tendausach = txtName.Text.Trim();
                    bookItem.Soluong = Int32.Parse(txtQuantity.Text.Trim());
                    bookItem.Sotrang = Int32.Parse(txtPage.Text.Trim());
                    int count = QLTV_Desktop.SaveChanges();
                    if(count > 0)
                    {
                        MessageBox.Show("Edit successfull.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit failed.");
            }
        }
    }
}

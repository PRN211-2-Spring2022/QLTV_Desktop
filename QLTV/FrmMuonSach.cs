using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLTV.Models;

namespace BookLoanManager
{
    public partial class FrmMuonSach : Form
    {

        public FrmMuonSach()
        {
            InitializeComponent();
        }
        TbSach objSach = new TbSach();

        DataTable dtMuonTra, dtSach;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void btnCreatePhieu_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "")
            {
                MessageBox.Show("Chưa nhập mã sách!");
                txtMaSach.Focus();
            }
            else
            {
                try
                {
                    //lvwDanhSach.Items.Clear();
                    DataRow dr = dtMuonTra.NewRow();
                    dr["MaDG"] = txtmatheDG.Text;
                    dr["MaSach"] = txtMaSach.Text;
                    dr["NgayMuon"] = dateNgayMuon.Value;
                    dr["NgayHenTra"] = dateNgayTra.Value;
                    dtMuonTra.Rows.Add(dr);
                    
                    //setButton();
                    NapListviewMuonSach();
                    MessageBox.Show("Đã cho mượn thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã sách "+txtMaSach.Text+" không có trong kho sách!\nHãy nhập mã sách khác!");
                    NapListviewMuonSach();
                    txtMaSach.Focus();
                }
            }
        }
        private void NapListviewMuonSach()
        {
            
            foreach (DataRow dr in dtMuonTra.Rows)
            {
                ListViewItem li = new ListViewItem();
                li.Text = dr["MaDG"].ToString();
                li.SubItems.Add(dr["MaSach"].ToString());
                li.SubItems.Add(dr["SoLuong"].ToString());
                string ngaymuon = Convert.ToDateTime(dr["NgayMuon"].ToString()).ToShortDateString();
                li.SubItems.Add(ngaymuon);
                string ngayhentra = Convert.ToDateTime(dr["NgayHenTra"].ToString()).ToShortDateString();
                li.SubItems.Add(ngayhentra);


            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strmasach = comboBox1.SelectedValue.ToString();
            

        }

        private void btnCreatePhieu_Click_1(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "")
            {
                MessageBox.Show("Chưa nhập mã sách!");
                txtMaSach.Focus();
            }
            else if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập số lượng sách cho mượn!");
                txtSoLuong.Focus();
            }
            else
            {
                try
                {
                    //lvwDanhSach.Items.Clear();
                    DataRow dr = dtMuonTra.NewRow();
                    dr["MaDG"] = cbMaDG.Text;
                    dr["MaSach"] = txtMaSach.Text;
                    dr["SoLuong"] = txtSoLuong.Text;
                    dr["NgayMuon"] = dateNgayMuon.Value;
                    dr["NgayHenTra"] = dateNgayTra.Text;
                    dtMuonTra.Rows.Add(dr);
                   
                    //setButton();
                    NapListviewMuonSach();
                    MessageBox.Show("Đã cho mượn thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã sách "+txtMaSach.Text+" không có trong kho sách!\nHãy nhập mã sách khác!");
                    NapListviewMuonSach();
                    txtMaSach.Focus();
                }
            }
        }

       

        private void MuonTraSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.No)
                e.Cancel = true;
        }

    }
}

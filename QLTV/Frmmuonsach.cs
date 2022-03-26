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
using QLTV;

namespace QLTV
{
    public partial class Frmmuonsach : UserControl
    {
        public Frmmuonsach()
        {
            InitializeComponent();
        }

        QLTV_DesktopContext QLTV = new QLTV_DesktopContext();

        private static Frmmuonsach _instance;
        public static Frmmuonsach Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frmmuonsach();
                return _instance;
            }
        }

        public void Loadform()
        {
            dateNgayMuon.Value = DateTime.Now;
            dateNgayTra.Value = DateTime.Now.AddMonths(1);
        }

        public void LoadDG()
        {
            var docgia = (
                from d in QLTV.TbDocgia
                select new { d.Mathedocgia, d.Hoten, d.Diachi }
            ).ToList();
            dgvthongtindocgia.DataSource = docgia;
            txtMaDocGia.DataBindings.Clear();
            txtMaDocGia.DataBindings.Add("Text", docgia, "Mathedocgia");
        }

        public void Loadsach()
        {
            var sach = (
                from d in QLTV.TbDausaches
                join b in QLTV.TbSaches on d.Madausach equals b.Madausach
                join c in QLTV.TbCtTacgia on b.Madausach equals c.Madausach
                join e in QLTV.TbTacgia on c.Matacgia equals e.Matacgia
                select new
                {
                    b.Maquyensach,
                    b.Madausach,
                    d.Tendausach,
                    e.Tentacgia,
                    b.Tinhtrangsach
                }
            ).ToList();
            foreach (var s in sach)
            {
                if (s.Tinhtrangsach == 1)
                {
                    
                }
            }
            dgvthongtinsach.DataSource = sach;
            txtmasach.DataBindings.Clear();
            txtmasach.DataBindings.Add("Text", sach, "Maquyensach");
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDG();
                Loadsach();
                Loadform();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        public void Loadbtnsearchma()
        {
            var findbyma = QLTV.TbDocgia
                .Where(m => m.Mathedocgia == int.Parse(txtfind.Text))
                .ToList();
            dgvthongtindocgia.DataSource = findbyma;
        }

        public void Loadbtsearchname()
        {
            var findbyten = QLTV.TbDocgia.Where(t => t.Hoten.Contains(txtfind.Text)).ToList();
            dgvthongtindocgia.DataSource = findbyten;
        }

        private void btnfind_Click_1(object sender, EventArgs e)
        {
            if (txtfind.Text == "")
            {
                MessageBox.Show("Thông tin tìm kiếm không thể để trống");
                txtfind.Focus();
            }
            else if (rbtnmathe.Checked == true)
            {
                Loadbtnsearchma();
            }
            else if (rbtnten.Checked == true)
            {
                Loadbtsearchname();
            }
            else if (rbtnmathe.Checked == false && rbtnten.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn thông tin tìm kiếm");
                rbtnmathe.Focus();
            }
        }

        private void btnsearchsach_Click(object sender, EventArgs e)
        {
            if (txtfindsach.Text == "")
            {
                MessageBox.Show("Thông tin tìm kiếm không thể để trống");
                txtfind.Focus();
            }
            else if (rbtmasach.Checked == true)
            {
                Loadbtnsearchma();
            }
            else if (rbttensach.Checked == true)
            {
                Loadbtsearchname();
            }
            else if (rbtmasach.Checked == false && rbttensach.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn thông tin tìm kiếm");
                rbtnmathe.Focus();
            }
        }

        private void btntaophieu_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                txtName.Focus();
            }
            else
            {
                try
                {
                    TbPhieubangiaosach muonsach = new TbPhieubangiaosach()
                    {
                        Mathedocgia = int.Parse(txtMaDocGia.Text),
                        Manhanvien = int.Parse(txtName.Text),
                        Ngaymuon = dateNgayMuon.Value,
                        Ngaydukientra = dateNgayTra.Value,
                        Tinhtrangkhigiao = cmbtinhtrangsach.Text
                    };
                    
                    var addma = QLTV.TbPhieubangiaosaches.OrderBy(b => b.Maphieubangiao).Last();
                    int mbg = addma.Maphieubangiao + 2;
                    TbCtPhieubangiao taophieu = new TbCtPhieubangiao()
                    {
                        
                        Maquyensach = int.Parse(txtmasach.Text),
                        Maphieubangiao = mbg

                    };
                    try
                    {
                        QLTV.TbPhieubangiaosaches.Add(muonsach);
                        QLTV.SaveChanges();

                        QLTV.TbCtPhieubangiaos.Add(taophieu);
                        QLTV.SaveChanges();
                        MessageBox.Show("Tạo phiếu mượn thành công");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Tạo phiếu thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Tạo phiếu thất bại.");
                }
            }
        }

        private void dgvthongtindocgia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtName.DataBindings.Clear();
            //txtName.DataBindings.Add("text", dgvthongtindocgia.DataSource, "Manhanvien");
            //txtMaDocGia.DataBindings.Clear();
            //txtMaDocGia.DataBindings.Add("text", dgvthongtindocgia.DataSource, "Mathedocgia");
            //txtmasach.DataBindings.Clear();
            //txtmasach.DataBindings.Add("text", dgvthongtindocgia.DataSource, "TbCtPhieubangiaos");
            //txtTTSach.DataBindings.Clear();
            //txtTTSach.DataBindings.Add("text", dgvthongtindocgia.DataSource, "Tinhtrangkhigiao");

        }

        private void button1_Click(object sender, EventArgs e) {
            var lichsu = new frmlichsu();
            lichsu.Show();
        }
    }
}
/*if (bookItem == null)
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
                    else*/

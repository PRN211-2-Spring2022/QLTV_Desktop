namespace BookLoanManager
{
    partial class FrmMuonSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtmatheDG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTTSach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCreatePhieu = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.dateNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.dateNgayTra = new System.Windows.Forms.DateTimePicker();
            this.cbChonMaSach = new System.Windows.Forms.ComboBox();
            this.lblMaSach = new System.Windows.Forms.Label();
            this.lblMaLoai = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbMaDG = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMaTG = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ Tên:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(133, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(192, 27);
            this.txtName.TabIndex = 1;
            // 
            // txtmatheDG
            // 
            this.txtmatheDG.Location = new System.Drawing.Point(133, 88);
            this.txtmatheDG.Name = "txtmatheDG";
            this.txtmatheDG.Size = new System.Drawing.Size(192, 27);
            this.txtmatheDG.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Thẻ Độc Giả:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã Sách Mượn:";
            // 
            // txtTTSach
            // 
            this.txtTTSach.Location = new System.Drawing.Point(123, 290);
            this.txtTTSach.Multiline = true;
            this.txtTTSach.Name = "txtTTSach";
            this.txtTTSach.Size = new System.Drawing.Size(250, 63);
            this.txtTTSach.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tình trạng Sách:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ngày Mượn:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ngày Trả ";
            // 
            // btnCreatePhieu
            // 
            this.btnCreatePhieu.Location = new System.Drawing.Point(231, 400);
            this.btnCreatePhieu.Name = "btnCreatePhieu";
            this.btnCreatePhieu.Size = new System.Drawing.Size(94, 29);
            this.btnCreatePhieu.TabIndex = 12;
            this.btnCreatePhieu.Text = "Tạo Phiếu";
            this.btnCreatePhieu.UseVisualStyleBackColor = true;
            this.btnCreatePhieu.Click += new System.EventHandler(this.btnCreatePhieu_Click_1);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Location = new System.Drawing.Point(470, 400);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(94, 29);
            this.btnKetThuc.TabIndex = 13;
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.UseVisualStyleBackColor = true;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // dateNgayMuon
            // 
            this.dateNgayMuon.Location = new System.Drawing.Point(123, 41);
            this.dateNgayMuon.Name = "dateNgayMuon";
            this.dateNgayMuon.Size = new System.Drawing.Size(250, 27);
            this.dateNgayMuon.TabIndex = 14;
            // 
            // dateNgayTra
            // 
            this.dateNgayTra.Location = new System.Drawing.Point(123, 88);
            this.dateNgayTra.Name = "dateNgayTra";
            this.dateNgayTra.Size = new System.Drawing.Size(250, 27);
            this.dateNgayTra.TabIndex = 15;
            // 
            // cbChonMaSach
            // 
            this.cbChonMaSach.FormattingEnabled = true;
            this.cbChonMaSach.Location = new System.Drawing.Point(133, 132);
            this.cbChonMaSach.Name = "cbChonMaSach";
            this.cbChonMaSach.Size = new System.Drawing.Size(151, 28);
            this.cbChonMaSach.TabIndex = 16;
            this.cbChonMaSach.SelectedIndexChanged += new System.EventHandler(this.cbChonMaSach_SelectedIndexChanged);
            // 
            // lblMaSach
            // 
            this.lblMaSach.AutoSize = true;
            this.lblMaSach.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblMaSach.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaSach.Location = new System.Drawing.Point(133, 191);
            this.lblMaSach.Name = "lblMaSach";
            this.lblMaSach.Size = new System.Drawing.Size(75, 22);
            this.lblMaSach.TabIndex = 17;
            this.lblMaSach.Text = "                ";
            // 
            // lblMaLoai
            // 
            this.lblMaLoai.AutoSize = true;
            this.lblMaLoai.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblMaLoai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaLoai.Location = new System.Drawing.Point(133, 232);
            this.lblMaLoai.Name = "lblMaLoai";
            this.lblMaLoai.Size = new System.Drawing.Size(163, 22);
            this.lblMaLoai.TabIndex = 18;
            this.lblMaLoai.Text = "                                      ";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSoLuong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSoLuong.Location = new System.Drawing.Point(133, 270);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(163, 22);
            this.lblSoLuong.TabIndex = 19;
            this.lblSoLuong.Text = "                                      ";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(123, 198);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(250, 27);
            this.txtMaSach.TabIndex = 20;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(123, 246);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(250, 27);
            this.txtSoLuong.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cbMaDG);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Controls.Add(this.txtMaSach);
            this.groupBox1.Controls.Add(this.dateNgayTra);
            this.groupBox1.Controls.Add(this.dateNgayMuon);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTTSach);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(377, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 367);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thực hiện cho mượn";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 146);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 20);
            this.label14.TabIndex = 25;
            this.label14.Text = "Mã Độc Giả";
            // 
            // cbMaDG
            // 
            this.cbMaDG.FormattingEnabled = true;
            this.cbMaDG.Location = new System.Drawing.Point(123, 143);
            this.cbMaDG.Name = "cbMaDG";
            this.cbMaDG.Size = new System.Drawing.Size(250, 28);
            this.cbMaDG.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Số Lượng Mượn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Mã Sách";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMaTG);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblSoLuong);
            this.groupBox2.Controls.Add(this.lblMaLoai);
            this.groupBox2.Controls.Add(this.lblMaSach);
            this.groupBox2.Controls.Add(this.cbChonMaSach);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtmatheDG);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(0, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 366);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin Sách";
            // 
            // lblMaTG
            // 
            this.lblMaTG.AutoSize = true;
            this.lblMaTG.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblMaTG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaTG.Location = new System.Drawing.Point(133, 311);
            this.lblMaTG.Name = "lblMaTG";
            this.lblMaTG.Size = new System.Drawing.Size(163, 22);
            this.lblMaTG.TabIndex = 26;
            this.lblMaTG.Text = "                                      ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "Mã Tác Giả";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 270);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Số Lượng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "Mã Loại";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(353, 293);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Mã Sách";
            // 
            // FrmMuonSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnKetThuc);
            this.Controls.Add(this.btnCreatePhieu);
            this.Name = "FrmMuonSach";
            this.Text = "FrmMuonSach";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtmatheDG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTTSach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreatePhieu;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.DateTimePicker dateNgayMuon;
        private System.Windows.Forms.DateTimePicker dateNgayTra;
        private System.Windows.Forms.ComboBox cbChonMaSach;
        private System.Windows.Forms.Label lblMaSach;
        private System.Windows.Forms.Label lblMaLoai;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMaTG;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbMaDG;
    }
}
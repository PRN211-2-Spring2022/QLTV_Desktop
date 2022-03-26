namespace QLTV
{
    partial class Frmmuonsach
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvthongtindocgia = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbtinhtrangsach = new System.Windows.Forms.ComboBox();
            this.txtMaDocGia = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtmasach = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dateNgayTra = new System.Windows.Forms.DateTimePicker();
            this.dateNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvthongtinsach = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtfind = new System.Windows.Forms.TextBox();
            this.btnfind = new System.Windows.Forms.Button();
            this.rbtnmathe = new System.Windows.Forms.RadioButton();
            this.rbtnten = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtfindsach = new System.Windows.Forms.TextBox();
            this.btnsearchsach = new System.Windows.Forms.Button();
            this.rbtmasach = new System.Windows.Forms.RadioButton();
            this.rbttensach = new System.Windows.Forms.RadioButton();
            this.btntaophieu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvthongtindocgia)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvthongtinsach)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvthongtindocgia
            // 
            this.dgvthongtindocgia.AllowUserToDeleteRows = false;
            this.dgvthongtindocgia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvthongtindocgia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvthongtindocgia.Location = new System.Drawing.Point(10, 150);
            this.dgvthongtindocgia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvthongtindocgia.Name = "dgvthongtindocgia";
            this.dgvthongtindocgia.ReadOnly = true;
            this.dgvthongtindocgia.RowHeadersWidth = 51;
            this.dgvthongtindocgia.RowTemplate.Height = 29;
            this.dgvthongtindocgia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvthongtindocgia.Size = new System.Drawing.Size(302, 292);
            this.dgvthongtindocgia.TabIndex = 9;
            this.dgvthongtindocgia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvthongtindocgia_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1038, 376);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 22);
            this.button1.TabIndex = 19;
            this.button1.Text = "Lịch sử";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbtinhtrangsach);
            this.groupBox1.Controls.Add(this.txtMaDocGia);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtmasach);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.dateNgayTra);
            this.groupBox1.Controls.Add(this.dateNgayMuon);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(809, 82);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(355, 290);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu";
            // 
            // cmbtinhtrangsach
            // 
            this.cmbtinhtrangsach.FormattingEnabled = true;
            this.cmbtinhtrangsach.Items.AddRange(new object[] {
            "Nguyên Vẹn",
            "Hỏng"});
            this.cmbtinhtrangsach.Location = new System.Drawing.Point(131, 232);
            this.cmbtinhtrangsach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbtinhtrangsach.Name = "cmbtinhtrangsach";
            this.cmbtinhtrangsach.Size = new System.Drawing.Size(219, 23);
            this.cmbtinhtrangsach.TabIndex = 32;
            // 
            // txtMaDocGia
            // 
            this.txtMaDocGia.BackColor = System.Drawing.Color.White;
            this.txtMaDocGia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMaDocGia.Location = new System.Drawing.Point(131, 113);
            this.txtMaDocGia.Name = "txtMaDocGia";
            this.txtMaDocGia.Size = new System.Drawing.Size(143, 19);
            this.txtMaDocGia.TabIndex = 31;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(131, 73);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(143, 23);
            this.txtName.TabIndex = 27;
            // 
            // txtmasach
            // 
            this.txtmasach.BackColor = System.Drawing.Color.White;
            this.txtmasach.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtmasach.Location = new System.Drawing.Point(131, 40);
            this.txtmasach.Name = "txtmasach";
            this.txtmasach.Size = new System.Drawing.Size(143, 20);
            this.txtmasach.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 15);
            this.label15.TabIndex = 29;
            this.label15.Text = "Mã sách";
            // 
            // dateNgayTra
            // 
            this.dateNgayTra.Location = new System.Drawing.Point(131, 190);
            this.dateNgayTra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateNgayTra.Name = "dateNgayTra";
            this.dateNgayTra.Size = new System.Drawing.Size(219, 23);
            this.dateNgayTra.TabIndex = 16;
            // 
            // dateNgayMuon
            // 
            this.dateNgayMuon.Location = new System.Drawing.Point(131, 151);
            this.dateNgayMuon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateNgayMuon.Name = "dateNgayMuon";
            this.dateNgayMuon.Size = new System.Drawing.Size(219, 23);
            this.dateNgayMuon.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tình Trạng Sách";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 15);
            this.label14.TabIndex = 7;
            this.label14.Text = "Mã nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã độc giả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày dự kiến trả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày mượn";
            // 
            // dgvthongtinsach
            // 
            this.dgvthongtinsach.AllowUserToDeleteRows = false;
            this.dgvthongtinsach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvthongtinsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvthongtinsach.Location = new System.Drawing.Point(338, 150);
            this.dgvthongtinsach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvthongtinsach.Name = "dgvthongtinsach";
            this.dgvthongtinsach.ReadOnly = true;
            this.dgvthongtinsach.RowHeadersWidth = 51;
            this.dgvthongtinsach.RowTemplate.Height = 29;
            this.dgvthongtinsach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvthongtinsach.Size = new System.Drawing.Size(466, 292);
            this.dgvthongtinsach.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtfind);
            this.groupBox2.Controls.Add(this.btnfind);
            this.groupBox2.Controls.Add(this.rbtnmathe);
            this.groupBox2.Controls.Add(this.rbtnten);
            this.groupBox2.Location = new System.Drawing.Point(10, 82);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(302, 64);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin tìm kiếm độc giả";
            // 
            // txtfind
            // 
            this.txtfind.Location = new System.Drawing.Point(5, 37);
            this.txtfind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfind.Name = "txtfind";
            this.txtfind.Size = new System.Drawing.Size(207, 23);
            this.txtfind.TabIndex = 0;
            // 
            // btnfind
            // 
            this.btnfind.Location = new System.Drawing.Point(223, 33);
            this.btnfind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(86, 28);
            this.btnfind.TabIndex = 1;
            this.btnfind.Text = "Tìm kiếm";
            this.btnfind.UseVisualStyleBackColor = true;
            this.btnfind.Click += new System.EventHandler(this.btnfind_Click_1);
            // 
            // rbtnmathe
            // 
            this.rbtnmathe.AutoSize = true;
            this.rbtnmathe.Location = new System.Drawing.Point(5, 14);
            this.rbtnmathe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnmathe.Name = "rbtnmathe";
            this.rbtnmathe.Size = new System.Drawing.Size(104, 19);
            this.rbtnmathe.TabIndex = 29;
            this.rbtnmathe.TabStop = true;
            this.rbtnmathe.Text = "Mã thẻ độc giả";
            this.rbtnmathe.UseVisualStyleBackColor = true;
            // 
            // rbtnten
            // 
            this.rbtnten.AutoSize = true;
            this.rbtnten.Location = new System.Drawing.Point(124, 14);
            this.rbtnten.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnten.Name = "rbtnten";
            this.rbtnten.Size = new System.Drawing.Size(85, 19);
            this.rbtnten.TabIndex = 30;
            this.rbtnten.TabStop = true;
            this.rbtnten.Text = "Tên độc giả";
            this.rbtnten.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtfindsach);
            this.groupBox3.Controls.Add(this.btnsearchsach);
            this.groupBox3.Controls.Add(this.rbtmasach);
            this.groupBox3.Controls.Add(this.rbttensach);
            this.groupBox3.Location = new System.Drawing.Point(338, 82);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(318, 64);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin sách";
            // 
            // txtfindsach
            // 
            this.txtfindsach.Location = new System.Drawing.Point(5, 37);
            this.txtfindsach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfindsach.Name = "txtfindsach";
            this.txtfindsach.Size = new System.Drawing.Size(207, 23);
            this.txtfindsach.TabIndex = 0;
            // 
            // btnsearchsach
            // 
            this.btnsearchsach.Location = new System.Drawing.Point(223, 33);
            this.btnsearchsach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsearchsach.Name = "btnsearchsach";
            this.btnsearchsach.Size = new System.Drawing.Size(86, 28);
            this.btnsearchsach.TabIndex = 1;
            this.btnsearchsach.Text = "Tìm kiếm";
            this.btnsearchsach.UseVisualStyleBackColor = true;
            this.btnsearchsach.Click += new System.EventHandler(this.btnsearchsach_Click);
            // 
            // rbtmasach
            // 
            this.rbtmasach.AutoSize = true;
            this.rbtmasach.Location = new System.Drawing.Point(5, 14);
            this.rbtmasach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtmasach.Name = "rbtmasach";
            this.rbtmasach.Size = new System.Drawing.Size(105, 19);
            this.rbtmasach.TabIndex = 29;
            this.rbtmasach.TabStop = true;
            this.rbtmasach.Text = "Mã quyển sách";
            this.rbtmasach.UseVisualStyleBackColor = true;
            // 
            // rbttensach
            // 
            this.rbttensach.AutoSize = true;
            this.rbttensach.Location = new System.Drawing.Point(124, 14);
            this.rbttensach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbttensach.Name = "rbttensach";
            this.rbttensach.Size = new System.Drawing.Size(70, 19);
            this.rbttensach.TabIndex = 30;
            this.rbttensach.TabStop = true;
            this.rbttensach.Text = "Tên sách";
            this.rbttensach.UseVisualStyleBackColor = true;
            // 
            // btntaophieu
            // 
            this.btntaophieu.Location = new System.Drawing.Point(831, 376);
            this.btntaophieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntaophieu.Name = "btntaophieu";
            this.btntaophieu.Size = new System.Drawing.Size(127, 22);
            this.btntaophieu.TabIndex = 36;
            this.btntaophieu.Text = "Tạo phiếu mượn";
            this.btntaophieu.UseVisualStyleBackColor = true;
            this.btntaophieu.Click += new System.EventHandler(this.btntaophieu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(421, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 25);
            this.label3.TabIndex = 37;
            this.label3.Text = "Quản lý mượn sách";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(940, 438);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 35);
            this.btnRefresh.TabIndex = 38;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Frmmuonsach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btntaophieu);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvthongtinsach);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvthongtindocgia);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frmmuonsach";
            this.Size = new System.Drawing.Size(1167, 542);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvthongtindocgia)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvthongtinsach)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvthongtindocgia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label txtmasach;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateNgayTra;
        private System.Windows.Forms.DateTimePicker dateNgayMuon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvthongtinsach;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtfind;
        private System.Windows.Forms.Button btnfind;
        private System.Windows.Forms.RadioButton rbtnmathe;
        private System.Windows.Forms.RadioButton rbtnten;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtfindsach;
        private System.Windows.Forms.Button btnsearchsach;
        private System.Windows.Forms.RadioButton rbtmasach;
        private System.Windows.Forms.RadioButton rbttensach;
        private System.Windows.Forms.Button btntaophieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtMaDocGia;
        private System.Windows.Forms.ComboBox cmbtinhtrangsach;
        private System.Windows.Forms.Button btnRefresh;
    }
}

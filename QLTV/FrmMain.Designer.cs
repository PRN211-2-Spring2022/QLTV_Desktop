namespace BookLoanManager
{
    partial class FrmMain
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
            this.dgvthongtindocgia.Location = new System.Drawing.Point(12, 200);
            this.dgvthongtindocgia.Name = "dgvthongtindocgia";
            this.dgvthongtindocgia.ReadOnly = true;
            this.dgvthongtindocgia.RowHeadersWidth = 51;
            this.dgvthongtindocgia.RowTemplate.Height = 29;
            this.dgvthongtindocgia.Size = new System.Drawing.Size(345, 390);
            this.dgvthongtindocgia.TabIndex = 9;
            this.dgvthongtindocgia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvthongtindocgia_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1186, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 29);
            this.button1.TabIndex = 19;
            this.button1.Text = "Lịch sử";
            this.button1.UseVisualStyleBackColor = true;
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
            this.groupBox1.Location = new System.Drawing.Point(925, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 387);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu";
            // 
            // cmbtinhtrangsach
            // 
            this.cmbtinhtrangsach.FormattingEnabled = true;
            this.cmbtinhtrangsach.Items.AddRange(new object[] {
            "Nguyên Vẹn",
            "Hỏng",
            "Mất"});
            this.cmbtinhtrangsach.Location = new System.Drawing.Point(150, 309);
            this.cmbtinhtrangsach.Name = "cmbtinhtrangsach";
            this.cmbtinhtrangsach.Size = new System.Drawing.Size(250, 28);
            this.cmbtinhtrangsach.TabIndex = 32;
            // 
            // txtMaDocGia
            // 
            this.txtMaDocGia.BackColor = System.Drawing.Color.White;
            this.txtMaDocGia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMaDocGia.Location = new System.Drawing.Point(150, 151);
            this.txtMaDocGia.Name = "txtMaDocGia";
            this.txtMaDocGia.Size = new System.Drawing.Size(163, 25);
            this.txtMaDocGia.TabIndex = 31;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(150, 97);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(163, 27);
            this.txtName.TabIndex = 27;
            // 
            // txtmasach
            // 
            this.txtmasach.BackColor = System.Drawing.Color.White;
            this.txtmasach.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtmasach.Location = new System.Drawing.Point(150, 54);
            this.txtmasach.Name = "txtmasach";
            this.txtmasach.Size = new System.Drawing.Size(163, 27);
            this.txtmasach.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 20);
            this.label15.TabIndex = 29;
            this.label15.Text = "Mã sách";
            // 
            // dateNgayTra
            // 
            this.dateNgayTra.Location = new System.Drawing.Point(150, 254);
            this.dateNgayTra.Name = "dateNgayTra";
            this.dateNgayTra.Size = new System.Drawing.Size(250, 27);
            this.dateNgayTra.TabIndex = 16;
            // 
            // dateNgayMuon
            // 
            this.dateNgayMuon.Location = new System.Drawing.Point(150, 201);
            this.dateNgayMuon.Name = "dateNgayMuon";
            this.dateNgayMuon.Size = new System.Drawing.Size(250, 27);
            this.dateNgayMuon.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tình Trạng Sách";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 20);
            this.label14.TabIndex = 7;
            this.label14.Text = "Mã nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã độc giả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày dự kiến trả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày mượn";
            // 
            // dgvthongtinsach
            // 
            this.dgvthongtinsach.AllowUserToDeleteRows = false;
            this.dgvthongtinsach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvthongtinsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvthongtinsach.Location = new System.Drawing.Point(386, 200);
            this.dgvthongtinsach.Name = "dgvthongtinsach";
            this.dgvthongtinsach.ReadOnly = true;
            this.dgvthongtinsach.RowHeadersWidth = 51;
            this.dgvthongtinsach.RowTemplate.Height = 29;
            this.dgvthongtinsach.Size = new System.Drawing.Size(533, 390);
            this.dgvthongtinsach.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtfind);
            this.groupBox2.Controls.Add(this.btnfind);
            this.groupBox2.Controls.Add(this.rbtnmathe);
            this.groupBox2.Controls.Add(this.rbtnten);
            this.groupBox2.Location = new System.Drawing.Point(12, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 85);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin tìm kiếm độc giả";
            // 
            // txtfind
            // 
            this.txtfind.Location = new System.Drawing.Point(6, 49);
            this.txtfind.Name = "txtfind";
            this.txtfind.Size = new System.Drawing.Size(236, 27);
            this.txtfind.TabIndex = 0;
            // 
            // btnfind
            // 
            this.btnfind.Location = new System.Drawing.Point(255, 44);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(98, 38);
            this.btnfind.TabIndex = 1;
            this.btnfind.Text = "Tìm kiếm";
            this.btnfind.UseVisualStyleBackColor = true;
            this.btnfind.Click += new System.EventHandler(this.btnfind_Click_1);
            // 
            // rbtnmathe
            // 
            this.rbtnmathe.AutoSize = true;
            this.rbtnmathe.Location = new System.Drawing.Point(6, 19);
            this.rbtnmathe.Name = "rbtnmathe";
            this.rbtnmathe.Size = new System.Drawing.Size(130, 24);
            this.rbtnmathe.TabIndex = 29;
            this.rbtnmathe.TabStop = true;
            this.rbtnmathe.Text = "Mã thẻ độc giả";
            this.rbtnmathe.UseVisualStyleBackColor = true;
            // 
            // rbtnten
            // 
            this.rbtnten.AutoSize = true;
            this.rbtnten.Location = new System.Drawing.Point(142, 19);
            this.rbtnten.Name = "rbtnten";
            this.rbtnten.Size = new System.Drawing.Size(107, 24);
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
            this.groupBox3.Location = new System.Drawing.Point(386, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 85);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin sách";
            // 
            // txtfindsach
            // 
            this.txtfindsach.Location = new System.Drawing.Point(6, 49);
            this.txtfindsach.Name = "txtfindsach";
            this.txtfindsach.Size = new System.Drawing.Size(236, 27);
            this.txtfindsach.TabIndex = 0;
            // 
            // btnsearchsach
            // 
            this.btnsearchsach.Location = new System.Drawing.Point(255, 44);
            this.btnsearchsach.Name = "btnsearchsach";
            this.btnsearchsach.Size = new System.Drawing.Size(98, 38);
            this.btnsearchsach.TabIndex = 1;
            this.btnsearchsach.Text = "Tìm kiếm";
            this.btnsearchsach.UseVisualStyleBackColor = true;
            this.btnsearchsach.Click += new System.EventHandler(this.btnsearchsach_Click);
            // 
            // rbtmasach
            // 
            this.rbtmasach.AutoSize = true;
            this.rbtmasach.Location = new System.Drawing.Point(6, 19);
            this.rbtmasach.Name = "rbtmasach";
            this.rbtmasach.Size = new System.Drawing.Size(128, 24);
            this.rbtmasach.TabIndex = 29;
            this.rbtmasach.TabStop = true;
            this.rbtmasach.Text = "Mã quyển sách";
            this.rbtmasach.UseVisualStyleBackColor = true;
            // 
            // rbttensach
            // 
            this.rbttensach.AutoSize = true;
            this.rbttensach.Location = new System.Drawing.Point(142, 19);
            this.rbttensach.Name = "rbttensach";
            this.rbttensach.Size = new System.Drawing.Size(86, 24);
            this.rbttensach.TabIndex = 30;
            this.rbttensach.TabStop = true;
            this.rbttensach.Text = "Tên sách";
            this.rbttensach.UseVisualStyleBackColor = true;
            // 
            // btntaophieu
            // 
            this.btntaophieu.Location = new System.Drawing.Point(950, 502);
            this.btntaophieu.Name = "btntaophieu";
            this.btntaophieu.Size = new System.Drawing.Size(145, 29);
            this.btntaophieu.TabIndex = 36;
            this.btntaophieu.Text = "Tạo phiếu mượn";
            this.btntaophieu.UseVisualStyleBackColor = true;
            this.btntaophieu.Click += new System.EventHandler(this.btntaophieu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(481, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 31);
            this.label3.TabIndex = 37;
            this.label3.Text = "Quản lý mượn sách";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btntaophieu);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvthongtinsach);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvthongtindocgia);
            this.Name = "FrmMain";
            this.Size = new System.Drawing.Size(1334, 722);
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
    }
}

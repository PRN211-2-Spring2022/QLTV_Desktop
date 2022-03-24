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
            this.txtName = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTTSach = new System.Windows.Forms.TextBox();
            this.dateNgayTra = new System.Windows.Forms.DateTimePicker();
            this.dateNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtfind = new System.Windows.Forms.TextBox();
            this.btnfind = new System.Windows.Forms.Button();
            this.rbtnmathe = new System.Windows.Forms.RadioButton();
            this.rbtnten = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvthongtindocgia)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvthongtindocgia
            // 
            this.dgvthongtindocgia.AllowUserToDeleteRows = false;
            this.dgvthongtindocgia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvthongtindocgia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvthongtindocgia.Location = new System.Drawing.Point(3, 226);
            this.dgvthongtindocgia.Name = "dgvthongtindocgia";
            this.dgvthongtindocgia.ReadOnly = true;
            this.dgvthongtindocgia.RowHeadersWidth = 51;
            this.dgvthongtindocgia.RowTemplate.Height = 29;
            this.dgvthongtindocgia.Size = new System.Drawing.Size(353, 345);
            this.dgvthongtindocgia.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1027, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 29);
            this.button1.TabIndex = 19;
            this.button1.Text = "Lịch sử";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtTTSach);
            this.groupBox1.Controls.Add(this.dateNgayTra);
            this.groupBox1.Controls.Add(this.dateNgayMuon);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(757, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 408);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(165, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(163, 27);
            this.txtName.TabIndex = 27;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(165, 93);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(163, 27);
            this.textBox2.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(165, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(163, 27);
            this.label13.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 149);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(134, 20);
            this.label15.TabIndex = 29;
            this.label15.Text = "Mã phiếu bàn giao";
            // 
            // txtTTSach
            // 
            this.txtTTSach.Location = new System.Drawing.Point(165, 307);
            this.txtTTSach.Multiline = true;
            this.txtTTSach.Name = "txtTTSach";
            this.txtTTSach.Size = new System.Drawing.Size(228, 63);
            this.txtTTSach.TabIndex = 28;
            // 
            // dateNgayTra
            // 
            this.dateNgayTra.Location = new System.Drawing.Point(165, 255);
            this.dateNgayTra.Name = "dateNgayTra";
            this.dateNgayTra.Size = new System.Drawing.Size(250, 27);
            this.dateNgayTra.TabIndex = 16;
            // 
            // dateNgayMuon
            // 
            this.dateNgayMuon.Location = new System.Drawing.Point(165, 202);
            this.dateNgayMuon.Name = "dateNgayMuon";
            this.dateNgayMuon.Size = new System.Drawing.Size(250, 27);
            this.dateNgayMuon.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tình Trạng Sách";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 20);
            this.label14.TabIndex = 7;
            this.label14.Text = "Mã nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã độc giả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày dự kiến trả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày mượn";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(377, 226);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(363, 345);
            this.dataGridView2.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtfind);
            this.groupBox2.Controls.Add(this.btnfind);
            this.groupBox2.Controls.Add(this.rbtnmathe);
            this.groupBox2.Controls.Add(this.rbtnten);
            this.groupBox2.Location = new System.Drawing.Point(3, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 85);
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
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvthongtindocgia);
            this.Name = "FrmMain";
            this.Size = new System.Drawing.Size(1198, 661);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvthongtindocgia)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvthongtindocgia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTTSach;
        private System.Windows.Forms.DateTimePicker dateNgayTra;
        private System.Windows.Forms.DateTimePicker dateNgayMuon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtfind;
        private System.Windows.Forms.Button btnfind;
        private System.Windows.Forms.RadioButton rbtnmathe;
        private System.Windows.Forms.RadioButton rbtnten;
    }
}

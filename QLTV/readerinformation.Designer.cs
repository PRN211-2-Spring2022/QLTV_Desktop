namespace QLTV
{
    partial class readerinformation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtmathedocgia = new System.Windows.Forms.TextBox();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.dtxtngaysinh = new System.Windows.Forms.DateTimePicker();
            this.dtxtngaylamthe = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.boxdoituong = new System.Windows.Forms.ComboBox();
            this.dgvthongtindocgia = new System.Windows.Forms.DataGridView();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvthongtindocgia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(642, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cập nhật thông tin độc giả";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã thẻ độc giả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(354, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày sinh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(354, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày làm thẻ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(353, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Đối tượng độc giả";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(662, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "Họ tên đầy đủ";
            // 
            // txtmathedocgia
            // 
            this.txtmathedocgia.Location = new System.Drawing.Point(469, 145);
            this.txtmathedocgia.Name = "txtmathedocgia";
            this.txtmathedocgia.Size = new System.Drawing.Size(125, 27);
            this.txtmathedocgia.TabIndex = 10;
            // 
            // txthoten
            // 
            this.txthoten.Location = new System.Drawing.Point(783, 145);
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(295, 27);
            this.txthoten.TabIndex = 11;
            // 
            // dtxtngaysinh
            // 
            this.dtxtngaysinh.Location = new System.Drawing.Point(469, 195);
            this.dtxtngaysinh.Name = "dtxtngaysinh";
            this.dtxtngaysinh.Size = new System.Drawing.Size(250, 27);
            this.dtxtngaysinh.TabIndex = 15;
            this.dtxtngaysinh.Value = new System.DateTime(2021, 8, 17, 0, 0, 0, 0);
            // 
            // dtxtngaylamthe
            // 
            this.dtxtngaylamthe.Location = new System.Drawing.Point(469, 251);
            this.dtxtngaylamthe.Name = "dtxtngaylamthe";
            this.dtxtngaylamthe.Size = new System.Drawing.Size(250, 27);
            this.dtxtngaylamthe.TabIndex = 16;
            this.dtxtngaylamthe.Value = new System.DateTime(2022, 3, 16, 17, 54, 59, 0);
            this.dtxtngaylamthe.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 89);
            this.button1.TabIndex = 19;
            this.button1.Text = "Thêm độc giả";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(703, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 89);
            this.button2.TabIndex = 20;
            this.button2.Text = "Cập nhật thông tin";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1040, 403);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 89);
            this.button3.TabIndex = 21;
            this.button3.Text = "Xóa độc giả";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button4.FlatAppearance.BorderSize = 3;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Navy;
            this.button4.Location = new System.Drawing.Point(948, 213);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 63);
            this.button4.TabIndex = 22;
            this.button4.Text = "Làm mới";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // boxdoituong
            // 
            this.boxdoituong.FormattingEnabled = true;
            this.boxdoituong.Items.AddRange(new object[] {
            "Học viên ",
            "Sinh viên",
            "Giáo viên"});
            this.boxdoituong.Location = new System.Drawing.Point(508, 312);
            this.boxdoituong.Name = "boxdoituong";
            this.boxdoituong.Size = new System.Drawing.Size(210, 28);
            this.boxdoituong.TabIndex = 23;
            // 
            // dgvthongtindocgia
            // 
            this.dgvthongtindocgia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvthongtindocgia.Location = new System.Drawing.Point(354, 509);
            this.dgvthongtindocgia.Name = "dgvthongtindocgia";
            this.dgvthongtindocgia.RowHeadersWidth = 51;
            this.dgvthongtindocgia.RowTemplate.Height = 29;
            this.dgvthongtindocgia.Size = new System.Drawing.Size(836, 101);
            this.dgvthongtindocgia.TabIndex = 24;
            // 
            // txtdiachi
            // 
            this.txtdiachi.Location = new System.Drawing.Point(807, 312);
            this.txtdiachi.Multiline = true;
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(253, 72);
            this.txtdiachi.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(745, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Địa chỉ";
            // 
            // readerinformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtdiachi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvthongtindocgia);
            this.Controls.Add(this.boxdoituong);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtxtngaylamthe);
            this.Controls.Add(this.dtxtngaysinh);
            this.Controls.Add(this.txthoten);
            this.Controls.Add(this.txtmathedocgia);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "readerinformation";
            this.Size = new System.Drawing.Size(1335, 637);
            this.Load += new System.EventHandler(this.readerinformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvthongtindocgia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtmathedocgia;
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.DateTimePicker dtxtngaysinh;
        private System.Windows.Forms.DateTimePicker dtxtngaylamthe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox boxdoituong;
        private System.Windows.Forms.DataGridView dgvthongtindocgia;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.Label label2;
    }
}

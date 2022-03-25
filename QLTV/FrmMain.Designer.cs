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
            this.searchByCode = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSearchByName = new System.Windows.Forms.Button();
            this.txtSearchByName = new System.Windows.Forms.TextBox();
            this.ListBorrower = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnphieubangiao = new System.Windows.Forms.Button();
            this.btntraSach = new System.Windows.Forms.Button();
            this.btntaophieu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchByCode
            // 
            this.searchByCode.Location = new System.Drawing.Point(554, 18);
            this.searchByCode.Name = "searchByCode";
            this.searchByCode.Size = new System.Drawing.Size(126, 29);
            this.searchByCode.TabIndex = 14;
            this.searchByCode.Text = "serach by Code";
            this.searchByCode.UseVisualStyleBackColor = true;
            this.searchByCode.Click += new System.EventHandler(this.searchByCode_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(344, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 27);
            this.textBox1.TabIndex = 13;
            // 
            // btnSearchByName
            // 
            this.btnSearchByName.Location = new System.Drawing.Point(554, 80);
            this.btnSearchByName.Name = "btnSearchByName";
            this.btnSearchByName.Size = new System.Drawing.Size(126, 29);
            this.btnSearchByName.TabIndex = 12;
            this.btnSearchByName.Text = "serach by name";
            this.btnSearchByName.UseVisualStyleBackColor = true;
            this.btnSearchByName.Click += new System.EventHandler(this.btnSearchByName_Click);
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Location = new System.Drawing.Point(344, 82);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.Size = new System.Drawing.Size(187, 27);
            this.txtSearchByName.TabIndex = 11;
            // 
            // ListBorrower
            // 
            this.ListBorrower.AutoSize = true;
            this.ListBorrower.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ListBorrower.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ListBorrower.Location = new System.Drawing.Point(22, 65);
            this.ListBorrower.Name = "ListBorrower";
            this.ListBorrower.Size = new System.Drawing.Size(207, 30);
            this.ListBorrower.TabIndex = 10;
            this.ListBorrower.Text = "Danh Sách Độc Giả";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 233);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(805, 381);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnphieubangiao
            // 
            this.btnphieubangiao.Location = new System.Drawing.Point(105, 163);
            this.btnphieubangiao.Name = "btnphieubangiao";
            this.btnphieubangiao.Size = new System.Drawing.Size(145, 29);
            this.btnphieubangiao.TabIndex = 16;
            this.btnphieubangiao.Text = "Phiếu Bàn Giao";
            this.btnphieubangiao.UseVisualStyleBackColor = true;
            this.btnphieubangiao.Click += new System.EventHandler(this.btnmuonSach_Click);
            // 
            // btntraSach
            // 
            this.btntraSach.Location = new System.Drawing.Point(595, 163);
            this.btntraSach.Name = "btntraSach";
            this.btntraSach.Size = new System.Drawing.Size(145, 29);
            this.btntraSach.TabIndex = 17;
            this.btntraSach.Text = "Lịch Sử Trả Sách";
            this.btntraSach.UseVisualStyleBackColor = true;
            this.btntraSach.Click += new System.EventHandler(this.btntraSach_Click);
            // 
            // btntaophieu
            // 
            this.btntaophieu.Location = new System.Drawing.Point(332, 163);
            this.btntaophieu.Name = "btntaophieu";
            this.btntaophieu.Size = new System.Drawing.Size(145, 29);
            this.btntaophieu.TabIndex = 18;
            this.btntaophieu.Text = "Tạo phiếu mượn";
            this.btntaophieu.UseVisualStyleBackColor = true;
            this.btntaophieu.Click += new System.EventHandler(this.btntaophieu_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btntaophieu);
            this.Controls.Add(this.btntraSach);
            this.Controls.Add(this.btnphieubangiao);
            this.Controls.Add(this.searchByCode);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSearchByName);
            this.Controls.Add(this.txtSearchByName);
            this.Controls.Add(this.ListBorrower);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmMain";
            this.Size = new System.Drawing.Size(881, 631);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button searchByCode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSearchByName;
        private System.Windows.Forms.TextBox txtSearchByName;
        private System.Windows.Forms.Label ListBorrower;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnphieubangiao;
        private System.Windows.Forms.Button btntraSach;
        private System.Windows.Forms.Button btntaophieu;
    }
}

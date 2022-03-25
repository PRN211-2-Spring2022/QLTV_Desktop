namespace BookLoanManager
{
    partial class viewMuonSach
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtmadg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMapbg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btntraSach = new System.Windows.Forms.Button();
            this.btntimpbg = new System.Windows.Forms.Button();
            this.btntimen = new System.Windows.Forms.Button();
            this.txtsearchbyphieu = new System.Windows.Forms.TextBox();
            this.txtsearchbyname = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(276, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(803, 313);
            this.dataGridView1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(572, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "Phiếu Bàn Giao";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 33);
            this.button1.TabIndex = 10;
            this.button1.Text = "Trả Sách";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtmadg
            // 
            this.txtmadg.Enabled = false;
            this.txtmadg.Location = new System.Drawing.Point(122, 170);
            this.txtmadg.Name = "txtmadg";
            this.txtmadg.Size = new System.Drawing.Size(148, 27);
            this.txtmadg.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "MaDG";
            // 
            // txtMapbg
            // 
            this.txtMapbg.Location = new System.Drawing.Point(122, 218);
            this.txtMapbg.Name = "txtMapbg";
            this.txtMapbg.Size = new System.Drawing.Size(148, 27);
            this.txtMapbg.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ma Phieu BG";
            // 
            // btntraSach
            // 
            this.btntraSach.Location = new System.Drawing.Point(315, 113);
            this.btntraSach.Name = "btntraSach";
            this.btntraSach.Size = new System.Drawing.Size(153, 30);
            this.btntraSach.TabIndex = 18;
            this.btntraSach.Text = "Thông tin trả Sách";
            this.btntraSach.UseVisualStyleBackColor = true;
            this.btntraSach.Click += new System.EventHandler(this.btntraSach_Click);
            // 
            // btntimpbg
            // 
            this.btntimpbg.Location = new System.Drawing.Point(692, 116);
            this.btntimpbg.Name = "btntimpbg";
            this.btntimpbg.Size = new System.Drawing.Size(149, 29);
            this.btntimpbg.TabIndex = 19;
            this.btntimpbg.Text = "TÌm theo mã Phiếu";
            this.btntimpbg.UseVisualStyleBackColor = true;
            this.btntimpbg.Click += new System.EventHandler(this.btntimpbg_Click);
            // 
            // btntimen
            // 
            this.btntimen.Location = new System.Drawing.Point(692, 62);
            this.btntimen.Name = "btntimen";
            this.btntimen.Size = new System.Drawing.Size(176, 29);
            this.btntimen.TabIndex = 21;
            this.btntimen.Text = "TÌm phiếu theo Tên DG";
            this.btntimen.UseVisualStyleBackColor = true;
            this.btntimen.Click += new System.EventHandler(this.btntimen_Click);
            // 
            // txtsearchbyphieu
            // 
            this.txtsearchbyphieu.Location = new System.Drawing.Point(888, 118);
            this.txtsearchbyphieu.Name = "txtsearchbyphieu";
            this.txtsearchbyphieu.Size = new System.Drawing.Size(195, 27);
            this.txtsearchbyphieu.TabIndex = 22;
            // 
            // txtsearchbyname
            // 
            this.txtsearchbyname.Location = new System.Drawing.Point(888, 67);
            this.txtsearchbyname.Name = "txtsearchbyname";
            this.txtsearchbyname.Size = new System.Drawing.Size(190, 27);
            this.txtsearchbyname.TabIndex = 23;
            // 
            // viewMuonSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 487);
            this.Controls.Add(this.txtsearchbyname);
            this.Controls.Add(this.txtsearchbyphieu);
            this.Controls.Add(this.btntimen);
            this.Controls.Add(this.btntimpbg);
            this.Controls.Add(this.btntraSach);
            this.Controls.Add(this.txtMapbg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtmadg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Name = "viewMuonSach";
            this.Text = "viewMuonSach";
            this.Load += new System.EventHandler(this.viewMuonSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtmadg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMapbg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btntraSach;
        private System.Windows.Forms.Button btntimpbg;
        private System.Windows.Forms.Button btntimen;
        private System.Windows.Forms.TextBox txtsearchbyphieu;
        private System.Windows.Forms.TextBox txtsearchbyname;
    }
}
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
            this.btntraSach = new System.Windows.Forms.Button();
            this.txtsearchbyname = new System.Windows.Forms.TextBox();
            this.txtsearchbyphieu = new System.Windows.Forms.TextBox();
            this.btntimen = new System.Windows.Forms.Button();
            this.btntimpbg = new System.Windows.Forms.Button();
            this.txtMapbg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmadg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btntraSach
            // 
            this.btntraSach.Location = new System.Drawing.Point(324, 144);
            this.btntraSach.Name = "btntraSach";
            this.btntraSach.Size = new System.Drawing.Size(145, 29);
            this.btntraSach.TabIndex = 17;
            this.btntraSach.Text = "Lịch Sử Trả Sách";
            this.btntraSach.UseVisualStyleBackColor = true;
            this.btntraSach.Click += new System.EventHandler(this.btntraSach_Click);
            // 
            // txtsearchbyname
            // 
            this.txtsearchbyname.Location = new System.Drawing.Point(698, 184);
            this.txtsearchbyname.Name = "txtsearchbyname";
            this.txtsearchbyname.Size = new System.Drawing.Size(190, 27);
            this.txtsearchbyname.TabIndex = 35;
            // 
            // txtsearchbyphieu
            // 
            this.txtsearchbyphieu.Location = new System.Drawing.Point(1120, 182);
            this.txtsearchbyphieu.Name = "txtsearchbyphieu";
            this.txtsearchbyphieu.Size = new System.Drawing.Size(195, 27);
            this.txtsearchbyphieu.TabIndex = 34;
            // 
            // btntimen
            // 
            this.btntimen.Location = new System.Drawing.Point(500, 184);
            this.btntimen.Name = "btntimen";
            this.btntimen.Size = new System.Drawing.Size(176, 29);
            this.btntimen.TabIndex = 33;
            this.btntimen.Text = "TÌm phiếu theo Tên DG";
            this.btntimen.UseVisualStyleBackColor = true;
            this.btntimen.Click += new System.EventHandler(this.btntimen_Click);
            // 
            // btntimpbg
            // 
            this.btntimpbg.Location = new System.Drawing.Point(924, 182);
            this.btntimpbg.Name = "btntimpbg";
            this.btntimpbg.Size = new System.Drawing.Size(149, 29);
            this.btntimpbg.TabIndex = 32;
            this.btntimpbg.Text = "TÌm theo mã Phiếu";
            this.btntimpbg.UseVisualStyleBackColor = true;
            this.btntimpbg.Click += new System.EventHandler(this.btntimpbg_Click);
            // 
            // txtMapbg
            // 
            this.txtMapbg.Location = new System.Drawing.Point(164, 290);
            this.txtMapbg.Name = "txtMapbg";
            this.txtMapbg.Size = new System.Drawing.Size(148, 27);
            this.txtMapbg.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Ma Phieu BG";
            // 
            // txtmadg
            // 
            this.txtmadg.Enabled = false;
            this.txtmadg.Location = new System.Drawing.Point(164, 242);
            this.txtmadg.Name = "txtmadg";
            this.txtmadg.Size = new System.Drawing.Size(148, 27);
            this.txtmadg.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "MaDG";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(114, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 33);
            this.button2.TabIndex = 26;
            this.button2.Text = "Trả Sách";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(281, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 30);
            this.label5.TabIndex = 25;
            this.label5.Text = "Quản Lý Trả Sách";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(321, 231);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(994, 477);
            this.dataGridView1.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1120, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 57);
            this.button1.TabIndex = 36;
            this.button1.Text = "Reload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtsearchbyname);
            this.Controls.Add(this.txtsearchbyphieu);
            this.Controls.Add(this.btntimen);
            this.Controls.Add(this.btntimpbg);
            this.Controls.Add(this.txtMapbg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtmadg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btntraSach);
            this.Name = "FrmMain";
            this.Size = new System.Drawing.Size(1334, 722);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btntraSach;
        private System.Windows.Forms.TextBox txtsearchbyname;
        private System.Windows.Forms.TextBox txtsearchbyphieu;
        private System.Windows.Forms.Button btntimen;
        private System.Windows.Forms.Button btntimpbg;
        private System.Windows.Forms.TextBox txtMapbg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtmadg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}

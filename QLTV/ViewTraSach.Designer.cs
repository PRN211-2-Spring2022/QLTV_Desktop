namespace BookLoanManager
{
    partial class ViewTraSach
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
            this.txtngaytra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnphieuphat = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMadg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtmatrasachs = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 228);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1132, 304);
            this.dataGridView1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(517, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 30);
            this.label5.TabIndex = 18;
            this.label5.Text = "Phiếu Trả Sách";
            // 
            // txtngaytra
            // 
            this.txtngaytra.Location = new System.Drawing.Point(731, 169);
            this.txtngaytra.Name = "txtngaytra";
            this.txtngaytra.Size = new System.Drawing.Size(213, 27);
            this.txtngaytra.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(600, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Ngày Trả ";
            // 
            // btnphieuphat
            // 
            this.btnphieuphat.Location = new System.Drawing.Point(731, 57);
            this.btnphieuphat.Name = "btnphieuphat";
            this.btnphieuphat.Size = new System.Drawing.Size(185, 29);
            this.btnphieuphat.TabIndex = 19;
            this.btnphieuphat.Text = "Xem Phiếu Phạt";
            this.btnphieuphat.UseVisualStyleBackColor = true;
            this.btnphieuphat.Click += new System.EventHandler(this.btnphieuphat_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(175, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(213, 27);
            this.txtName.TabIndex = 21;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(731, 122);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 27);
            this.textBox1.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(600, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ngày Dự KiếnTrả ";
            // 
            // txtMadg
            // 
            this.txtMadg.Location = new System.Drawing.Point(266, 159);
            this.txtMadg.Name = "txtMadg";
            this.txtMadg.Size = new System.Drawing.Size(213, 27);
            this.txtMadg.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(161, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "MDG";
            // 
            // txtmatrasachs
            // 
            this.txtmatrasachs.Location = new System.Drawing.Point(266, 102);
            this.txtmatrasachs.Name = "txtmatrasachs";
            this.txtmatrasachs.Size = new System.Drawing.Size(213, 27);
            this.txtmatrasachs.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(161, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "Mã trả Sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "TÌm Theo Tên";
            // 
            // ViewTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 541);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmatrasachs);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMadg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnphieuphat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtngaytra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ViewTraSach";
            this.Text = "FrmTraSach";
            this.Load += new System.EventHandler(this.FrmTraSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtngaytra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtmaDG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtmatraSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnphieuphat;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMadg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtmatrasachs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
    }
}
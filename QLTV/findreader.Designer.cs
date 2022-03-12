namespace QLTV
{
    partial class findreader
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
            this.txtfind = new System.Windows.Forms.TextBox();
            this.rbtnmathe = new System.Windows.Forms.RadioButton();
            this.rbtnten = new System.Windows.Forms.RadioButton();
            this.btnfind = new System.Windows.Forms.Button();
            this.dgvthongtindocgia = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvthongtindocgia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(714, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm độc giả";
            // 
            // txtfind
            // 
            this.txtfind.Location = new System.Drawing.Point(653, 190);
            this.txtfind.Name = "txtfind";
            this.txtfind.Size = new System.Drawing.Size(371, 27);
            this.txtfind.TabIndex = 1;
            // 
            // rbtnmathe
            // 
            this.rbtnmathe.AutoSize = true;
            this.rbtnmathe.Location = new System.Drawing.Point(496, 184);
            this.rbtnmathe.Name = "rbtnmathe";
            this.rbtnmathe.Size = new System.Drawing.Size(130, 24);
            this.rbtnmathe.TabIndex = 4;
            this.rbtnmathe.TabStop = true;
            this.rbtnmathe.Text = "Mã thẻ độc giả";
            this.rbtnmathe.UseVisualStyleBackColor = true;
            // 
            // rbtnten
            // 
            this.rbtnten.AutoSize = true;
            this.rbtnten.Location = new System.Drawing.Point(496, 214);
            this.rbtnten.Name = "rbtnten";
            this.rbtnten.Size = new System.Drawing.Size(107, 24);
            this.rbtnten.TabIndex = 5;
            this.rbtnten.TabStop = true;
            this.rbtnten.Text = "Tên độc giả";
            this.rbtnten.UseVisualStyleBackColor = true;
            // 
            // btnfind
            // 
            this.btnfind.Location = new System.Drawing.Point(1051, 184);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(130, 38);
            this.btnfind.TabIndex = 6;
            this.btnfind.Text = "Tìm kiếm";
            this.btnfind.UseVisualStyleBackColor = true;
            this.btnfind.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvthongtindocgia
            // 
            this.dgvthongtindocgia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvthongtindocgia.Location = new System.Drawing.Point(450, 292);
            this.dgvthongtindocgia.Name = "dgvthongtindocgia";
            this.dgvthongtindocgia.RowHeadersWidth = 51;
            this.dgvthongtindocgia.RowTemplate.Height = 29;
            this.dgvthongtindocgia.Size = new System.Drawing.Size(794, 297);
            this.dgvthongtindocgia.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(468, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Thông tin tìm kiếm";
            // 
            // findreader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvthongtindocgia);
            this.Controls.Add(this.btnfind);
            this.Controls.Add(this.rbtnten);
            this.Controls.Add(this.rbtnmathe);
            this.Controls.Add(this.txtfind);
            this.Controls.Add(this.label1);
            this.Name = "findreader";
            this.Size = new System.Drawing.Size(1313, 631);
            this.Load += new System.EventHandler(this.findreader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvthongtindocgia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtfind;
        private System.Windows.Forms.RadioButton rbtnmathe;
        private System.Windows.Forms.RadioButton rbtnten;
        private System.Windows.Forms.Button btnfind;
        private System.Windows.Forms.DataGridView dgvthongtindocgia;
        private System.Windows.Forms.Label label2;
    }
}

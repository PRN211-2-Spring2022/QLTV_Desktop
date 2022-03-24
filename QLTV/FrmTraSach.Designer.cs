namespace QLTV
{
    partial class FrmTraSach
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
            this.txtmaphieubg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dtpngaytra = new System.Windows.Forms.DateTimePicker();
            this.btntra = new System.Windows.Forms.Button();
            this.txtmadg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttinhtrangsach = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Phiếu BG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseMnemonic = false;
            // 
            // txtmaphieubg
            // 
            this.txtmaphieubg.Enabled = false;
            this.txtmaphieubg.Location = new System.Drawing.Point(182, 64);
            this.txtmaphieubg.Name = "txtmaphieubg";
            this.txtmaphieubg.Size = new System.Drawing.Size(243, 27);
            this.txtmaphieubg.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày Trả";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseMnemonic = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã nhân viên";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(175, 200);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(250, 28);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dtpngaytra
            // 
            this.dtpngaytra.CustomFormat = "MM-dd-yyyy";
            this.dtpngaytra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaytra.Location = new System.Drawing.Point(175, 277);
            this.dtpngaytra.Name = "dtpngaytra";
            this.dtpngaytra.Size = new System.Drawing.Size(250, 27);
            this.dtpngaytra.TabIndex = 6;
            // 
            // btntra
            // 
            this.btntra.Location = new System.Drawing.Point(475, 397);
            this.btntra.Name = "btntra";
            this.btntra.Size = new System.Drawing.Size(154, 29);
            this.btntra.TabIndex = 7;
            this.btntra.Text = "Trả Sách";
            this.btntra.UseVisualStyleBackColor = true;
            this.btntra.Click += new System.EventHandler(this.btntra_Click);
            // 
            // txtmadg
            // 
            this.txtmadg.Enabled = false;
            this.txtmadg.Location = new System.Drawing.Point(175, 127);
            this.txtmadg.Name = "txtmadg";
            this.txtmadg.Size = new System.Drawing.Size(250, 27);
            this.txtmadg.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mã thẻ DG";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.UseMnemonic = false;
            // 
            // txttinhtrangsach
            // 
            this.txttinhtrangsach.Location = new System.Drawing.Point(182, 351);
            this.txttinhtrangsach.Multiline = true;
            this.txttinhtrangsach.Name = "txttinhtrangsach";
            this.txttinhtrangsach.Size = new System.Drawing.Size(250, 75);
            this.txttinhtrangsach.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tình Trạng Sách";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.UseMnemonic = false;
            // 
            // FrmTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 450);
            this.Controls.Add(this.txttinhtrangsach);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtmadg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btntra);
            this.Controls.Add(this.dtpngaytra);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmaphieubg);
            this.Controls.Add(this.label1);
            this.Name = "FrmTraSach";
            this.Text = "FrmTraSach";
            this.Load += new System.EventHandler(this.FrmTraSach_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmaphieubg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dtpngaytra;
        private System.Windows.Forms.Button btntra;
        private System.Windows.Forms.TextBox txtmadg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttinhtrangsach;
        private System.Windows.Forms.Label label5;
    }
}
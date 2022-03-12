namespace QLTV
{
    partial class readermanagement
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
            this.btnTimkiemdocgia = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTimkiemdocgia
            // 
            this.btnTimkiemdocgia.Location = new System.Drawing.Point(272, 69);
            this.btnTimkiemdocgia.Name = "btnTimkiemdocgia";
            this.btnTimkiemdocgia.Size = new System.Drawing.Size(146, 70);
            this.btnTimkiemdocgia.TabIndex = 0;
            this.btnTimkiemdocgia.Text = "Tìm kiếm độc giả";
            this.btnTimkiemdocgia.UseVisualStyleBackColor = true;
            this.btnTimkiemdocgia.Click += new System.EventHandler(this.btnTimkiemdocgia_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(433, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 70);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cập nhật thông tin đọc giả";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(272, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quản lý độc giả";
            // 
            // readermanagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnTimkiemdocgia);
            this.Name = "readermanagement";
            this.Size = new System.Drawing.Size(1334, 637);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTimkiemdocgia;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}

namespace QLTV
{
    partial class AddBook
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelPage = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(131, 96);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 1;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(131, 178);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 23);
            this.txtQuantity.TabIndex = 2;
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(131, 260);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(200, 23);
            this.txtPage.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(87, 99);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(39, 15);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Name";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(73, 181);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(53, 15);
            this.labelQuantity.TabIndex = 7;
            this.labelQuantity.Text = "Quantity";
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(88, 263);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(38, 15);
            this.labelPage.TabIndex = 6;
            this.labelPage.Text = "Pages";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(489, 212);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(120, 40);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "Confirm add";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(81, 344);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(44, 15);
            this.labelAuthor.TabIndex = 10;
            this.labelAuthor.Text = "Author";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(131, 341);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(200, 23);
            this.txtAuthor.TabIndex = 9;
            // 
            // AddBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 490);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddBook";
            this.Text = "New book information";
            this.Load += new System.EventHandler(this.AddBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
    }
}
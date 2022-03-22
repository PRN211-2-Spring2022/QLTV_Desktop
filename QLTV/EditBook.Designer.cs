namespace QLTV
{
    partial class EditBook
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtAuthorID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(545, 207);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(120, 40);
            this.btnConfirm.TabIndex = 17;
            this.btnConfirm.Text = "Confirm edit";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(147, 251);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(38, 15);
            this.labelPage.TabIndex = 15;
            this.labelPage.Text = "Pages";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(132, 169);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(53, 15);
            this.labelQuantity.TabIndex = 16;
            this.labelQuantity.Text = "Quantity";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(146, 87);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(39, 15);
            this.labelName.TabIndex = 14;
            this.labelName.Text = "Name";
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(190, 248);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(200, 23);
            this.txtPage.TabIndex = 12;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(190, 166);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 23);
            this.txtQuantity.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(190, 87);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 10;
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(190, 87);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(200, 23);
            this.txtBookID.TabIndex = 9;
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(140, 327);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(44, 15);
            this.labelAuthor.TabIndex = 19;
            this.labelAuthor.Text = "Author";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(190, 324);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(200, 23);
            this.txtAuthor.TabIndex = 18;
            // 
            // txtAuthorID
            // 
            this.txtAuthorID.Location = new System.Drawing.Point(190, 87);
            this.txtAuthorID.Name = "txtAuthorID";
            this.txtAuthorID.Size = new System.Drawing.Size(200, 23);
            this.txtAuthorID.TabIndex = 20;
            // 
            // EditBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtBookID);
            this.Controls.Add(this.txtAuthorID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditBook";
            this.Text = "EditBook";
            this.Load += new System.EventHandler(this.EditBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtAuthorID;
    }
}
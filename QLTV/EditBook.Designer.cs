﻿namespace QLTV
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
            this.labelName = new System.Windows.Forms.Label();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(225, 320);
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
            this.labelPage.Location = new System.Drawing.Point(147, 167);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(38, 15);
            this.labelPage.TabIndex = 15;
            this.labelPage.Text = "Pages";
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
            this.txtPage.Location = new System.Drawing.Point(190, 164);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(200, 23);
            this.txtPage.TabIndex = 12;
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
            this.labelAuthor.Location = new System.Drawing.Point(140, 243);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(44, 15);
            this.labelAuthor.TabIndex = 19;
            this.labelAuthor.Text = "Author";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(190, 240);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(200, 23);
            this.txtAuthor.TabIndex = 18;
            // 
            // EditBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 461);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtBookID);
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
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
    }
}
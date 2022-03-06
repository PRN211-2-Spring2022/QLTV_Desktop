namespace QLTV
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.ArchiveDgv = new System.Windows.Forms.DataGridView();
            this.AddBookBtn = new System.Windows.Forms.Button();
            this.DeleteBookBtn = new System.Windows.Forms.Button();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchButton1 = new System.Windows.Forms.Button();
            this.SearchButton2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // ArchiveDgv
            // 
            this.ArchiveDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArchiveDgv.Dock = System.Windows.Forms.DockStyle.Right;
            this.ArchiveDgv.Location = new System.Drawing.Point(168, 0);
            this.ArchiveDgv.Name = "ArchiveDgv";
            this.ArchiveDgv.RowTemplate.Height = 25;
            this.ArchiveDgv.Size = new System.Drawing.Size(888, 666);
            this.ArchiveDgv.TabIndex = 0;
            // 
            // AddBookBtn
            // 
            this.AddBookBtn.Location = new System.Drawing.Point(12, 12);
            this.AddBookBtn.Name = "AddBookBtn";
            this.AddBookBtn.Size = new System.Drawing.Size(150, 75);
            this.AddBookBtn.TabIndex = 1;
            this.AddBookBtn.Text = "Add book";
            this.AddBookBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteBookBtn
            // 
            this.DeleteBookBtn.Location = new System.Drawing.Point(12, 93);
            this.DeleteBookBtn.Name = "DeleteBookBtn";
            this.DeleteBookBtn.Size = new System.Drawing.Size(150, 75);
            this.DeleteBookBtn.TabIndex = 2;
            this.DeleteBookBtn.Text = "Delete selected";
            this.DeleteBookBtn.UseVisualStyleBackColor = true;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(12, 197);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(42, 15);
            this.SearchLabel.TabIndex = 3;
            this.SearchLabel.Text = "Search";
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(12, 215);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(150, 23);
            this.SearchBox.TabIndex = 4;
            // 
            // SearchButton1
            // 
            this.SearchButton1.Location = new System.Drawing.Point(12, 244);
            this.SearchButton1.Name = "SearchButton1";
            this.SearchButton1.Size = new System.Drawing.Size(67, 38);
            this.SearchButton1.TabIndex = 5;
            this.SearchButton1.Text = "Search by title";
            this.SearchButton1.UseVisualStyleBackColor = true;
            // 
            // SearchButton2
            // 
            this.SearchButton2.Location = new System.Drawing.Point(95, 244);
            this.SearchButton2.Name = "SearchButton2";
            this.SearchButton2.Size = new System.Drawing.Size(69, 38);
            this.SearchButton2.TabIndex = 6;
            this.SearchButton2.Text = "Search by author";
            this.SearchButton2.UseVisualStyleBackColor = true;
            this.SearchButton2.Click += new System.EventHandler(this.SearchButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 666);
            this.Controls.Add(this.SearchButton2);
            this.Controls.Add(this.SearchButton1);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.DeleteBookBtn);
            this.Controls.Add(this.AddBookBtn);
            this.Controls.Add(this.ArchiveDgv);
            this.Name = "Form1";
            this.Text = "Archive control";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.DataGridView ArchiveDgv;
        private System.Windows.Forms.Button AddBookBtn;
        private System.Windows.Forms.Button DeleteBookBtn;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SearchButton1;
        private System.Windows.Forms.Button SearchButton2;
    }
}

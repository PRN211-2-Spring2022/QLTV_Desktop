namespace BookLoanManager
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
            this.frmMain1 = new BookLoanManager.FrmMain();
            this.SuspendLayout();
            // 
            // frmMain1
            // 
            this.frmMain1.Location = new System.Drawing.Point(25, 12);
            this.frmMain1.Name = "frmMain1";
            this.frmMain1.Size = new System.Drawing.Size(854, 556);
            this.frmMain1.TabIndex = 0;
            this.frmMain1.Load += new System.EventHandler(this.frmMain1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 575);
            this.Controls.Add(this.frmMain1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private FrmMain frmMain1;
    }
}

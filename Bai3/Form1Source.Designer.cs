namespace Bai3
{
    partial class FormSource
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox richTextBoxSource;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richTextBoxSource = new System.Windows.Forms.RichTextBox();

            this.SuspendLayout();
            // 
            // FormSource
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "View Source";
            this.MinimumSize = new System.Drawing.Size(600, 400);
            // 
            // richTextBoxSource
            // 
            this.richTextBoxSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSource.Font = new System.Drawing.Font("Consolas", 10F);
            this.richTextBoxSource.ReadOnly = true;
            this.richTextBoxSource.WordWrap = false;
            this.richTextBoxSource.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.richTextBoxSource);

            this.ResumeLayout(false);
        }
        #endregion
    }
}

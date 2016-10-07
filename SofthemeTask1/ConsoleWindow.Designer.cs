namespace SofthemeTask1
{
    partial class MainForm
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
            this.Sysout = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Sysout
            // 
            this.Sysout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sysout.Location = new System.Drawing.Point(0, 0);
            this.Sysout.Name = "Sysout";
            this.Sysout.ReadOnly = true;
            this.Sysout.Size = new System.Drawing.Size(934, 382);
            this.Sysout.TabIndex = 0;
            this.Sysout.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 382);
            this.Controls.Add(this.Sysout);
            this.Name = "MainForm";
            this.Text = "Softheme Task 1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Sysout;
    }
}


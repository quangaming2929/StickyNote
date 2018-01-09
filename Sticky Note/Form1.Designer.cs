namespace Sticky_Note
{
    partial class Form1
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
            this.fakeControl = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txbInput = new System.Windows.Forms.TextBox();
            this.fakeControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // fakeControl
            // 
            this.fakeControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fakeControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.fakeControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.xToolStripMenuItem});
            this.fakeControl.Location = new System.Drawing.Point(0, 0);
            this.fakeControl.Name = "fakeControl";
            this.fakeControl.ShowItemToolTips = true;
            this.fakeControl.Size = new System.Drawing.Size(292, 24);
            this.fakeControl.TabIndex = 2;
            this.fakeControl.Text = "menuStrip1";
            this.fakeControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fakeControl_MouseDown);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Oswald", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(28, 20);
            this.toolStripMenuItem1.Text = "+";
            this.toolStripMenuItem1.ToolTipText = "New Note (Ctrl+N)";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Font = new System.Drawing.Font("Oswald", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.xToolStripMenuItem.Size = new System.Drawing.Size(27, 20);
            this.xToolStripMenuItem.Text = "x";
            this.xToolStripMenuItem.ToolTipText = "Delete Note (Ctrl+D)";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // txbInput
            // 
            this.txbInput.BackColor = System.Drawing.Color.Bisque;
            this.txbInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbInput.Location = new System.Drawing.Point(12, 27);
            this.txbInput.Multiline = true;
            this.txbInput.Name = "txbInput";
            this.txbInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbInput.Size = new System.Drawing.Size(268, 234);
            this.txbInput.TabIndex = 3;
            this.txbInput.TextChanged += new System.EventHandler(this.txbInput_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.txbInput);
            this.Controls.Add(this.fakeControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.fakeControl.ResumeLayout(false);
            this.fakeControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip fakeControl;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox txbInput;
    }
}


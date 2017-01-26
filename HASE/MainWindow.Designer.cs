namespace HASE
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.newPMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.newFMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encounterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeFMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closePMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.statusMainLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuMain.SuspendLayout();
            this.statusMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.AutoSize = false;
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainFile});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(784, 22);
            this.menuMain.TabIndex = 0;
            // 
            // menuMainFile
            // 
            this.menuMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPMenuItem,
            this.openPMenuItem,
            this.menuFileSep1,
            this.newFMenuItem,
            this.openFMenuItem,
            this.menuFileSep2,
            this.closeFMenuItem,
            this.closeAMenuItem,
            this.closePMenuItem});
            this.menuMainFile.Name = "menuMainFile";
            this.menuMainFile.Size = new System.Drawing.Size(37, 18);
            this.menuMainFile.Text = "&File";
            // 
            // newPMenuItem
            // 
            this.newPMenuItem.Name = "newPMenuItem";
            this.newPMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newPMenuItem.Text = "&New Project ...";
            // 
            // openPMenuItem
            // 
            this.openPMenuItem.Name = "openPMenuItem";
            this.openPMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openPMenuItem.Text = "&Open Project ...";
            // 
            // menuFileSep1
            // 
            this.menuFileSep1.Name = "menuFileSep1";
            this.menuFileSep1.Size = new System.Drawing.Size(152, 6);
            // 
            // newFMenuItem
            // 
            this.newFMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encounterToolStripMenuItem});
            this.newFMenuItem.Name = "newFMenuItem";
            this.newFMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newFMenuItem.Text = "N&ew File";
            // 
            // encounterToolStripMenuItem
            // 
            this.encounterToolStripMenuItem.Name = "encounterToolStripMenuItem";
            this.encounterToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.encounterToolStripMenuItem.Text = "Encounter";
            // 
            // openFMenuItem
            // 
            this.openFMenuItem.Name = "openFMenuItem";
            this.openFMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openFMenuItem.Text = "O&pen File ...";
            // 
            // menuFileSep2
            // 
            this.menuFileSep2.Name = "menuFileSep2";
            this.menuFileSep2.Size = new System.Drawing.Size(152, 6);
            // 
            // closeFMenuItem
            // 
            this.closeFMenuItem.Name = "closeFMenuItem";
            this.closeFMenuItem.Size = new System.Drawing.Size(155, 22);
            this.closeFMenuItem.Text = "&Close File";
            // 
            // closeAMenuItem
            // 
            this.closeAMenuItem.Name = "closeAMenuItem";
            this.closeAMenuItem.Size = new System.Drawing.Size(155, 22);
            this.closeAMenuItem.Text = "Close &All";
            // 
            // closePMenuItem
            // 
            this.closePMenuItem.Name = "closePMenuItem";
            this.closePMenuItem.Size = new System.Drawing.Size(155, 22);
            this.closePMenuItem.Text = "Close &Project";
            // 
            // statusMain
            // 
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMainLabel});
            this.statusMain.Location = new System.Drawing.Point(0, 539);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(784, 22);
            this.statusMain.TabIndex = 1;
            this.statusMain.Text = "statusStrip1";
            // 
            // statusMainLabel
            // 
            this.statusMainLabel.Name = "statusMainLabel";
            this.statusMainLabel.Size = new System.Drawing.Size(39, 17);
            this.statusMainLabel.Text = "Ready";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainWindow";
            this.Text = "(HASE) HeartGold And SoulSilver Editor";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuMainFile;
        private System.Windows.Forms.ToolStripMenuItem newPMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPMenuItem;
        private System.Windows.Forms.ToolStripSeparator menuFileSep1;
        private System.Windows.Forms.ToolStripMenuItem newFMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encounterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFMenuItem;
        private System.Windows.Forms.ToolStripSeparator menuFileSep2;
        private System.Windows.Forms.ToolStripMenuItem closeFMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closePMenuItem;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ToolStripStatusLabel statusMainLabel;
    }
}


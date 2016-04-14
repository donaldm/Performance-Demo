namespace PerformanceDemo
{
    partial class PerformanceMain
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
            this.components = new System.ComponentModel.Container();
            this.gameStatusStrip = new System.Windows.Forms.StatusStrip();
            this.gameStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadScenarioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveScenarioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowThrowingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numberOfBallsLabel = new System.Windows.Forms.Label();
            this.rightClickContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameStatusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.rightClickContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameStatusStrip
            // 
            this.gameStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameStatus});
            this.gameStatusStrip.Location = new System.Drawing.Point(0, 483);
            this.gameStatusStrip.Name = "gameStatusStrip";
            this.gameStatusStrip.Size = new System.Drawing.Size(661, 22);
            this.gameStatusStrip.TabIndex = 0;
            this.gameStatusStrip.Text = "statusStrip1";
            // 
            // gameStatus
            // 
            this.gameStatus.Name = "gameStatus";
            this.gameStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadScenarioMenuItem,
            this.saveScenarioMenuItem,
            this.toolStripSeparator1,
            this.exitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadScenarioMenuItem
            // 
            this.loadScenarioMenuItem.Name = "loadScenarioMenuItem";
            this.loadScenarioMenuItem.Size = new System.Drawing.Size(148, 22);
            this.loadScenarioMenuItem.Text = "&Load Scenario";
            this.loadScenarioMenuItem.Click += new System.EventHandler(this.loadScenarioMenuItem_Click);
            // 
            // saveScenarioMenuItem
            // 
            this.saveScenarioMenuItem.Name = "saveScenarioMenuItem";
            this.saveScenarioMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveScenarioMenuItem.Text = "&Save Scenario";
            this.saveScenarioMenuItem.Click += new System.EventHandler(this.saveScenarioMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allowThrowingMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // allowThrowingMenuItem
            // 
            this.allowThrowingMenuItem.Checked = true;
            this.allowThrowingMenuItem.CheckOnClick = true;
            this.allowThrowingMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowThrowingMenuItem.Name = "allowThrowingMenuItem";
            this.allowThrowingMenuItem.Size = new System.Drawing.Size(158, 22);
            this.allowThrowingMenuItem.Text = "Allow Throwing";
            this.allowThrowingMenuItem.CheckedChanged += new System.EventHandler(this.allowThrowingMenuItem_CheckedChanged);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // controlMenuItem
            // 
            this.controlMenuItem.CheckOnClick = true;
            this.controlMenuItem.Name = "controlMenuItem";
            this.controlMenuItem.Size = new System.Drawing.Size(119, 22);
            this.controlMenuItem.Text = "Controls";
            this.controlMenuItem.Click += new System.EventHandler(this.controlMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(213, 22);
            this.aboutMenuItem.Text = "&About Performance Demo";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // numberOfBallsLabel
            // 
            this.numberOfBallsLabel.AutoSize = true;
            this.numberOfBallsLabel.BackColor = System.Drawing.Color.Black;
            this.numberOfBallsLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.numberOfBallsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfBallsLabel.ForeColor = System.Drawing.Color.White;
            this.numberOfBallsLabel.Location = new System.Drawing.Point(449, 24);
            this.numberOfBallsLabel.Name = "numberOfBallsLabel";
            this.numberOfBallsLabel.Size = new System.Drawing.Size(212, 31);
            this.numberOfBallsLabel.TabIndex = 2;
            this.numberOfBallsLabel.Text = "Number Of Balls";
            this.numberOfBallsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rightClickContextMenu
            // 
            this.rightClickContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteMenuItem});
            this.rightClickContextMenu.Name = "rightClickContextMenu";
            this.rightClickContextMenu.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Enabled = false;
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteMenuItem.Text = "&Delete";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // PerformanceMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 505);
            this.Controls.Add(this.numberOfBallsLabel);
            this.Controls.Add(this.gameStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PerformanceMain";
            this.Text = "Performance Demo";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PerformanceMain_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PerformanceMain_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PerformanceMain_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PerformanceMain_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PerformanceMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PerformanceMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PerformanceMain_MouseUp);
            this.Resize += new System.EventHandler(this.PerformanceMain_Resize);
            this.gameStatusStrip.ResumeLayout(false);
            this.gameStatusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.rightClickContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip gameStatusStrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.Label numberOfBallsLabel;
        private System.Windows.Forms.ContextMenuStrip rightClickContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel gameStatus;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowThrowingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadScenarioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveScenarioMenuItem;
    }
}


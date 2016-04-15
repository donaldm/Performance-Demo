namespace PerformanceDemo
{
    partial class PerformanceControls
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.schoolLogoModeRadioBtn = new System.Windows.Forms.RadioButton();
            this.normalModeRadioBtn = new System.Windows.Forms.RadioButton();
            this.optimizedGraphicsCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.immortalParticlesCheckBox = new System.Windows.Forms.CheckBox();
            this.crazyAlgorithmGroupBox = new System.Windows.Forms.GroupBox();
            this.crazyAlgorithmCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.crazyAlgorithmGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.schoolLogoModeRadioBtn);
            this.groupBox1.Controls.Add(this.normalModeRadioBtn);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Mode";
            // 
            // schoolLogoModeRadioBtn
            // 
            this.schoolLogoModeRadioBtn.AutoSize = true;
            this.schoolLogoModeRadioBtn.Location = new System.Drawing.Point(71, 20);
            this.schoolLogoModeRadioBtn.Name = "schoolLogoModeRadioBtn";
            this.schoolLogoModeRadioBtn.Size = new System.Drawing.Size(85, 17);
            this.schoolLogoModeRadioBtn.TabIndex = 1;
            this.schoolLogoModeRadioBtn.TabStop = true;
            this.schoolLogoModeRadioBtn.Text = "School Logo";
            this.schoolLogoModeRadioBtn.UseVisualStyleBackColor = true;
            this.schoolLogoModeRadioBtn.CheckedChanged += new System.EventHandler(this.schoolLogoModeRadioBtn_CheckedChanged);
            // 
            // normalModeRadioBtn
            // 
            this.normalModeRadioBtn.AutoSize = true;
            this.normalModeRadioBtn.Location = new System.Drawing.Point(7, 20);
            this.normalModeRadioBtn.Name = "normalModeRadioBtn";
            this.normalModeRadioBtn.Size = new System.Drawing.Size(58, 17);
            this.normalModeRadioBtn.TabIndex = 0;
            this.normalModeRadioBtn.TabStop = true;
            this.normalModeRadioBtn.Text = "Normal";
            this.normalModeRadioBtn.UseVisualStyleBackColor = true;
            this.normalModeRadioBtn.Click += new System.EventHandler(this.normalModeRadioBtn_Click);
            // 
            // optimizedGraphicsCheckBox
            // 
            this.optimizedGraphicsCheckBox.AutoSize = true;
            this.optimizedGraphicsCheckBox.Location = new System.Drawing.Point(6, 19);
            this.optimizedGraphicsCheckBox.Name = "optimizedGraphicsCheckBox";
            this.optimizedGraphicsCheckBox.Size = new System.Drawing.Size(117, 17);
            this.optimizedGraphicsCheckBox.TabIndex = 1;
            this.optimizedGraphicsCheckBox.Text = "Optimized Graphics";
            this.optimizedGraphicsCheckBox.UseVisualStyleBackColor = true;
            this.optimizedGraphicsCheckBox.CheckedChanged += new System.EventHandler(this.optimizedGraphicsCheckBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optimizedGraphicsCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 46);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Graphics Settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.immortalParticlesCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(13, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(355, 45);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Particle Settings";
            // 
            // immortalParticlesCheckBox
            // 
            this.immortalParticlesCheckBox.AutoSize = true;
            this.immortalParticlesCheckBox.Location = new System.Drawing.Point(7, 19);
            this.immortalParticlesCheckBox.Name = "immortalParticlesCheckBox";
            this.immortalParticlesCheckBox.Size = new System.Drawing.Size(108, 17);
            this.immortalParticlesCheckBox.TabIndex = 0;
            this.immortalParticlesCheckBox.Text = "Immortal Particles";
            this.immortalParticlesCheckBox.UseVisualStyleBackColor = true;
            this.immortalParticlesCheckBox.CheckedChanged += new System.EventHandler(this.immortalParticlesCheckBox_CheckedChanged);
            // 
            // crazyAlgorithmGroupBox
            // 
            this.crazyAlgorithmGroupBox.Controls.Add(this.crazyAlgorithmCheckBox);
            this.crazyAlgorithmGroupBox.Location = new System.Drawing.Point(13, 179);
            this.crazyAlgorithmGroupBox.Name = "crazyAlgorithmGroupBox";
            this.crazyAlgorithmGroupBox.Size = new System.Drawing.Size(355, 44);
            this.crazyAlgorithmGroupBox.TabIndex = 4;
            this.crazyAlgorithmGroupBox.TabStop = false;
            this.crazyAlgorithmGroupBox.Text = "Crazy Algorithm";
            // 
            // crazyAlgorithmCheckBox
            // 
            this.crazyAlgorithmCheckBox.AutoSize = true;
            this.crazyAlgorithmCheckBox.Location = new System.Drawing.Point(7, 19);
            this.crazyAlgorithmCheckBox.Name = "crazyAlgorithmCheckBox";
            this.crazyAlgorithmCheckBox.Size = new System.Drawing.Size(98, 17);
            this.crazyAlgorithmCheckBox.TabIndex = 0;
            this.crazyAlgorithmCheckBox.Text = "Crazy Algorithm";
            this.crazyAlgorithmCheckBox.UseVisualStyleBackColor = true;
            this.crazyAlgorithmCheckBox.CheckedChanged += new System.EventHandler(this.crazyAlgorithmCheckBox_CheckedChanged);
            // 
            // PerformanceControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 237);
            this.Controls.Add(this.crazyAlgorithmGroupBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PerformanceControls";
            this.Text = "Performance Demo Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PerformanceControls_FormClosing);
            this.Load += new System.EventHandler(this.PerformanceControls_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.crazyAlgorithmGroupBox.ResumeLayout(false);
            this.crazyAlgorithmGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton schoolLogoModeRadioBtn;
        private System.Windows.Forms.RadioButton normalModeRadioBtn;
        private System.Windows.Forms.CheckBox optimizedGraphicsCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox immortalParticlesCheckBox;
        private System.Windows.Forms.GroupBox crazyAlgorithmGroupBox;
        private System.Windows.Forms.CheckBox crazyAlgorithmCheckBox;
    }
}
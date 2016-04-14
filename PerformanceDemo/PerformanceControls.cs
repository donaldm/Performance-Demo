using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PerformanceDemo.Game;

namespace PerformanceDemo
{
    public partial class PerformanceControls : Form
    {
        private GameSettings gameSettings;

        public PerformanceControls(GameSettings pGameSettings)
        {
            InitializeComponent();

            gameSettings = pGameSettings;
        }

        private void PerformanceControls_Load(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            if (gameSettings.Mode == GameMode.Normal)
            {
                normalModeRadioBtn.Select();
            }
            if (gameSettings.Mode == GameMode.Lion)
            {
                schoolLogoModeRadioBtn.Select();
            }

            optimizedGraphicsCheckBox.Checked = gameSettings.OptimizeGraphics;
            immortalParticlesCheckBox.Checked = gameSettings.ImmortalParticles;
        }

        private void normalModeRadioBtn_Click(object sender, EventArgs e)
        {
            gameSettings.Mode = GameMode.Normal;
        }

        private void schoolLogoModeRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            gameSettings.Mode = GameMode.Lion;
        }

        private void optimizedGraphicsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            gameSettings.OptimizeGraphics = optimizedGraphicsCheckBox.Checked;
        }

        private void immortalParticlesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            gameSettings.ImmortalParticles = immortalParticlesCheckBox.Checked;
        }

        private void PerformanceControls_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}

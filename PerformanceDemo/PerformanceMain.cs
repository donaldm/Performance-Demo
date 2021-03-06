﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PerformanceDemo.Game;

namespace PerformanceDemo
{
    public partial class PerformanceMain : Form
    {
        private const int UPDATE_INTERVAL = 10;

        private GameController gameController;
        private Timer updateTimer;
        private GameSettings gameSettings;
        private PerformanceControls performanceControls;

        public PerformanceMain()
        {
            InitializeComponent();
            DoubleBuffered = true;

            gameSettings = new GameSettings();
            gameController = new GameController(CalculateVisibleRectangle(), gameSettings);
            updateTimer = new Timer {Interval = UPDATE_INTERVAL};
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();

            performanceControls = new PerformanceControls(gameSettings);
            performanceControls.VisibleChanged += PerformanceControlsOnVisibleChanged;
        }

        private void PerformanceControlsOnVisibleChanged(object sender, EventArgs eventArgs)
        {
            controlMenuItem.Checked = performanceControls.Visible;
        }

        public Rectangle CalculateVisibleRectangle()
        {
            return new Rectangle(0, menuStrip1.Height, 
                ClientRectangle.Width, ClientRectangle.Height - gameStatusStrip.Height);
        }



        private void UpdateStatsGUI()
        {
            numberOfBallsLabel.Text = 
                String.Format("Number of Balls: {0:D2}\nNumber of Stick Figures: {1:D2}", 
                               gameController.BallCount, 
                               gameController.StickFigureCount);
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            gameController.Update();
            UpdateStatsGUI();
            Invalidate();
        }

        private void PerformanceMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.Black);
            gameController.Draw(graphics);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            PerformanceAboutBox aboutBox = new PerformanceAboutBox();
            aboutBox.ShowDialog();
            aboutBox.Dispose();
        }

        private void PerformanceMain_Resize(object sender, EventArgs e)
        {
            gameController.Boundary = CalculateVisibleRectangle();
        }

        private void PerformanceMain_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void PerformanceMain_MouseMove(object sender, MouseEventArgs e)
        {
            gameController.MouseMove(e.X, e.Y);
        }

        private void PerformanceMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                gameController.LeftMouseDown(e.X, e.Y);
                gameStatus.Text = "";
            }
            else if (e.Button == MouseButtons.Right)
            {
                rightClickContextMenu.Show(Cursor.Position.X, Cursor.Position.Y);
                gameController.Paused = true;
                bool ballFoundAtMouse = gameController.RightMouseDown(e.X, e.Y);
                deleteMenuItem.Enabled = ballFoundAtMouse;
                gameStatus.Text = "Paused";
            }
        }

        private void PerformanceMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                gameController.LeftMouseUp(e.X, e.Y);
            }
        }

        private void PerformanceMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                gameController.RightArrowPressed = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                gameController.LeftArrowPressed = true;
            }
            else if (e.KeyCode == Keys.C)
            {
                gameController.ClearAllBalls();
            }
            else if (e.KeyCode == Keys.R)
            {
                gameController.ClearAllStickFigures();
            }
            else if (e.KeyCode == Keys.A)
            {
                Point mousePos = PointToClient(MousePosition);
                gameController.AddStickFigure(mousePos.X, mousePos.Y);
            }
            else if (e.KeyCode == Keys.Up)
            {
                gameController.CycleMode();
            }
        }

        private void PerformanceMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                gameController.RightArrowPressed = false;
            }
            else if (e.KeyCode == Keys.Left)
            {
                gameController.LeftArrowPressed = false;
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            gameController.DeleteRightClickBall();
        }

        private void allowThrowingMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            gameController.AllowThrow = allowThrowingMenuItem.Checked;
        }

        private void controlMenuItem_Click(object sender, EventArgs e)
        {
            if (controlMenuItem.Checked)
            {
                performanceControls.Show();
            }
            else
            {
                performanceControls.Hide();
            }
        }

        private void loadScenarioMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Scenario";
            openFileDialog.Filter = "JSON Files|*.json";
            openFileDialog.FilterIndex = 0;
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                gameController.Clear();
                gameSettings.Load(openFileDialog.FileName);
                performanceControls.Reset();
                string filePath = openFileDialog.FileName;
                string selectedScenario = Path.GetFileName(filePath);
                Text = "Performance Demo [" + selectedScenario + "]";
            }
            openFileDialog.Dispose();
        }

        private void saveScenarioMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Scenario";
            saveFileDialog.Filter = "JSON Files|*.json";
            saveFileDialog.FilterIndex = 0;
            DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string savedFilePath = saveFileDialog.FileName;
                gameSettings.Save(savedFilePath);
            }
            saveFileDialog.Dispose();
        }

        private void muteSoundsMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            gameController.PlaySounds = !muteSoundsMenuItem.Checked;
        }
    }
}

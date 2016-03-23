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
    public partial class PerformanceMain : Form
    {
        private const int UPDATE_INTERVAL = 10;

        private GameController gameController;
        private Timer updateTimer;

        public PerformanceMain()
        {
            InitializeComponent();
            DoubleBuffered = true;

            gameController = new GameController(CalculateVisibleRectangle());
            updateTimer = new Timer();
            updateTimer.Interval = UPDATE_INTERVAL;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        public Rectangle CalculateVisibleRectangle()
        {
            return new Rectangle(0, menuStrip1.Height, 
                ClientRectangle.Width, ClientRectangle.Height - gameStatusStrip.Height);
        }



        private void UpdateStatsGUI()
        {
            numberOfBallsLabel.Text = String.Format("Number of Balls: {0:D2}", gameController.BallCount);
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
            if ( e.KeyCode == Keys.Right )
            {
                gameController.RightArrowPressed = true;
            }
            else if ( e.KeyCode == Keys.Left )
            {
                gameController.LeftArrowPressed = true;
            }
            else if ( e.KeyCode == Keys.C )
            {
                gameController.ClearAllBalls();
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

        }
    }
}

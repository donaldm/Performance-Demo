using PerformanceDemo.Game_Core;
using PerformanceDemo.Renderers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Game
{
    class GraphicalBallManager : BallManager
    {
        private Rectangle boundary;

        public GraphicalBallManager(Rectangle windowBoundary) : base()
        {
            boundary = windowBoundary;
        }

        public Rectangle Boundary
        {
            set
            {
                boundary = value;
            }
            get
            {
                return boundary;
            }
        }

        public override void UpdateBall(WorldParameters parameters, Ball ball)
        {
            base.UpdateBall(parameters, ball);

            BallRenderer ballRenderer = new BallRenderer(ball);
            Rectangle ballRectangle = ballRenderer.CalculateBoundingBox();

            if (ballRectangle.X < boundary.X)
            {
                ball.Velocity.X = Math.Abs(ball.Velocity.X) * parameters.Damping;
                ball.Position.X = boundary.X + ball.Radius;
            }
            if (ballRectangle.X + ballRectangle.Width > boundary.Width)
            {
                ball.Velocity.X = -Math.Abs(ball.Velocity.X) * parameters.Damping;
                ball.Position.X = boundary.Width - ball.Radius;
            }
            if (ballRectangle.Y < boundary.Y)
            {
                ball.Velocity.Y = Math.Abs(ball.Velocity.Y) * parameters.Damping;
                ball.Position.Y = boundary.Y + ball.Radius;
            }
            if (ballRectangle.Y + ballRectangle.Height > boundary.Height)
            {
                ball.Velocity.Y = -Math.Abs(ball.Velocity.Y) * parameters.Damping;
                ball.Position.Y = boundary.Height - ball.Radius;
            }
        }

        public void Draw(Graphics graphics)
        {
            foreach (Ball curBall in balls)
            {
                BallRenderer ballRenderer = new BallRenderer(curBall);
                ballRenderer.Draw(graphics);
            }
        }
    }
}

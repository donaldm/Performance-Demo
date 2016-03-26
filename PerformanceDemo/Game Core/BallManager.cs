using PerformanceDemo.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Game_Core
{
    class BallManager
    {
        protected List<Ball> balls;
        private Rectangle boundary;
        private Random random;

        public BallManager(Rectangle windowBoundary)
        {
            balls = new List<Ball>();
            boundary = windowBoundary;
            random = new Random();
        }

        public List<Ball> Balls
        {
            get
            {
                return balls;
            }
        }

        public int Count
        {
            get
            {
                return balls.Count;
            }
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

        public void AddBall(Ball ball)
        {
            balls.Add(ball);
        }

        public void RemoveBall(Ball ball)
        {
            balls.Remove(ball);
        }

        public void Clear()
        {
            balls.Clear();
        }

        public Ball FindBall(Vector2 location)
        {
            Ball foundBall = null;

            foreach (Ball curBall in balls)
            {
                if (curBall.Contains(location))
                {
                    foundBall = curBall;
                    break;
                }
            }

            return foundBall;
        }

        public void Update(WorldParameters parameters)
        {
            foreach (Ball curBall in balls)
            {
                UpdateBall(parameters, curBall);
            }
        }

        public virtual void UpdateBall(WorldParameters parameters, Ball ball)
        {
            ball.Update(parameters);

            Rectangle ballRectangle = ball.CalculateBoundingBox();

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
                double jitterVel = ball.Velocity.Y / 2;
                if (jitterVel < -1)
                {
                    ball.Velocity.X += random.NextDouble() * jitterVel - random.NextDouble() * jitterVel;
                }
                ball.Position.Y = boundary.Height - ball.Radius;
            }
        }

        public void Draw(Graphics graphics)
        {
            foreach (Ball curBall in balls)
            {
                curBall.Draw(graphics);
            }
        }
    }
}

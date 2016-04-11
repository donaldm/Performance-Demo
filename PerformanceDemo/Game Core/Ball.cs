using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceDemo.Utilities;
using System.Drawing;

namespace PerformanceDemo.Game_Core
{
    public class Ball : IGraphicalItem
    {
        public Ball(double startRadius, Vector2 startPosition, Vector2 startVelocity)
        {
            Radius = startRadius;
            Position = startPosition;
            Velocity = startVelocity;
            EnableGravity = true;
        }

        public Double Radius { set; get; }

        public Vector2 Position { set; get; }

        public Vector2 Velocity { set; get; }

        public bool EnableGravity { set; get; }

        public Rectangle CalculateBoundingBox()
        {
            double ballRadius = Radius;
            int ballX = (int)(Position.X - ballRadius);
            int ballY = (int)(Position.Y - ballRadius);
            int ballX2 = (int)(Position.X + ballRadius);
            int ballY2 = (int)(Position.Y + ballRadius);
            int ballWidth = ballX2 - ballX;
            int ballHeight = ballY2 - ballY;

            Rectangle rect = new Rectangle(ballX, ballY, ballWidth, ballHeight);
            return rect;
        }

        public bool Contains(Vector2 testLocation)
        {
            bool inside = false;

            Vector2 delta = testLocation - Position;
            if (delta.Length < Radius)
            {
                inside = true;
            }

            return inside;
        }

        public void Update(WorldParameters parameters)
        {
            if (EnableGravity)
            {
                Velocity.Y += parameters.Gravity;
            }
            Position += Velocity;

            Rectangle ballRectangle = CalculateBoundingBox();
            Rectangle boundary = parameters.Boundary;
            Random random = parameters.WorldRandom;

            if (ballRectangle.X < boundary.X)
            {
                Velocity.X = Math.Abs(Velocity.X) * parameters.Damping;
                Position.X = boundary.X + Radius;
            }
            if (ballRectangle.X + ballRectangle.Width > boundary.Width)
            {
                Velocity.X = -Math.Abs(Velocity.X) * parameters.Damping;
                Position.X = boundary.Width - Radius;
            }
            if (ballRectangle.Y < boundary.Y)
            {
                Velocity.Y = Math.Abs(Velocity.Y) * parameters.Damping;
                Position.Y = boundary.Y + Radius;
            }
            if (ballRectangle.Y + ballRectangle.Height > boundary.Height)
            {
                Velocity.Y = -Math.Abs(Velocity.Y) * parameters.Damping;
                double jitterVel = Velocity.Y / 2;
                if (jitterVel < -1)
                {
                    Velocity.X += random.NextDouble() * jitterVel - random.NextDouble() * jitterVel;
                }
                Position.Y = boundary.Height - Radius;
            }
        }

        public virtual void Draw(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Red, CalculateBoundingBox());
        }

        public void Destroy()
        {
            Console.WriteLine("Destroy Ball!!!");
        }
    }
}

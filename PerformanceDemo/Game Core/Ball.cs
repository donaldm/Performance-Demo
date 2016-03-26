using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceDemo.Utilities;
using System.Drawing;

namespace PerformanceDemo.Game_Core
{
    class Ball
    {
        private double radius;
        private Vector2 position;
        private Vector2 velocity;
        private bool enableGravity;

        public Ball(double startRadius, Vector2 startPosition, Vector2 startVelocity)
        {
            radius = startRadius;
            position = startPosition;
            velocity = startVelocity;
            enableGravity = true;
        }

        public Double Radius
        {
            set
            {
                radius = value;
            }
            get
            {
                return radius;
            }
        }

        public Vector2 Position
        {
            set
            {
                position = value;
            }
            get
            {
                return position;
            }
        }

        public Vector2 Velocity
        {
            set
            {
                velocity = value;
            }
            get
            {
                return velocity;
            }
        }

        public bool EnableGravity
        {
            set
            {
                enableGravity = value;
            }

            get
            {
                return enableGravity;
            }
        }

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

            Vector2 delta = testLocation - position;
            if (delta.Length < radius)
            {
                inside = true;
            }

            return inside;
        }

        public void Update(WorldParameters parameters)
        {
            if (enableGravity)
            {
                velocity.Y += parameters.Gravity;
            }
            position += velocity;
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Red, CalculateBoundingBox());
        }
    }
}

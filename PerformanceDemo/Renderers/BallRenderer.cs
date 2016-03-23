using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceDemo.Game_Core;

namespace PerformanceDemo.Renderers
{
    class BallRenderer
    {
        Ball ball;

        public BallRenderer(Ball ballToRender)
        {
            ball = ballToRender;
        }

        public Ball CurrentBall
        {
            set
            {
                ball = value;
            }
            get
            {
                return ball;
            }
        }

        public Rectangle CalculateBoundingBox()
        {
            double ballRadius = ball.Radius;
            int ballX = (int)(ball.Position.X - ballRadius);
            int ballY = (int)(ball.Position.Y - ballRadius);
            int ballX2 = (int)(ball.Position.X + ballRadius);
            int ballY2 = (int)(ball.Position.Y + ballRadius);
            int ballWidth = ballX2 - ballX;
            int ballHeight = ballY2 - ballY;

            Rectangle rect = new Rectangle(ballX, ballY, ballWidth, ballHeight);
            return rect;
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Red, CalculateBoundingBox());
        }
    }
}

using PerformanceDemo.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Game_Core
{
    class StickFigure
    {
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 previousVelocity;
        private int width;
        private int height;
        private double headMultiplier;

        public StickFigure(Vector2 startPosition, Vector2 startVelocity, int startWidth, int startHeight, int startHeadMultiplier)
        {
            position = startPosition;
            velocity = startVelocity;
            previousVelocity = new Vector2(velocity);
            width = startWidth;
            height = startHeight;
            headMultiplier = startHeadMultiplier;
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

        public int Width
        {
            set
            {
                width = value;
            }

            get
            {
                return width;
            }
        }

        public int Height
        {
            set
            {
                height = value;
            }

            get
            {
                return height;
            }
        }

        public double HeadMultiplier
        {
            set
            {
                headMultiplier = value;
            }

            get
            {
                return headMultiplier;
            }
        }

        public Rectangle CalculateBoundingBox()
        {
            int stickWidth = Width;
            int stickHeight = Height;
            int halfStickWidth = stickWidth / 2;
            int halfStickHeight = stickHeight / 2;
            int stickX = (int)(Position.X - halfStickWidth);
            int stickY = (int)(Position.Y - halfStickHeight);

            Rectangle rect = new Rectangle(stickX, stickY, stickWidth, stickHeight);
            return rect;
        }

        public void Update(WorldParameters parameters)
        {
            if (velocity != previousVelocity && velocity.Y == 0)
            {
                velocity.X = -1;
            }
            velocity.Y += parameters.Gravity;
            position += velocity;
            previousVelocity = new Vector2(velocity);

            Rectangle stickRectangle = CalculateBoundingBox();
            Rectangle boundary = parameters.Boundary;

            if (stickRectangle.X < boundary.X)
            {
                Velocity.X = Math.Abs(Velocity.X) * parameters.Damping;
                Position.X = boundary.X + Height / 2;
            }
            if (stickRectangle.X + stickRectangle.Width > boundary.Width)
            {
                Velocity.X = -Math.Abs(Velocity.X) * parameters.Damping;
                Position.X = boundary.Width - Width / 2;
            }
            if (stickRectangle.Y < boundary.Y)
            {
                Velocity.Y = Math.Abs(Velocity.Y) * parameters.Damping;
                Position.Y = boundary.Y + Height / 2;
            }
            if (stickRectangle.Y + stickRectangle.Height > boundary.Height)
            {
                Velocity.Y = 0;
                Position.Y = boundary.Height - Height / 2;
            }
        }


        public void Draw(Graphics graphics)
        {
            Rectangle stickRect = CalculateBoundingBox();
            Pen stickPen = Pens.Green;

            int midX = stickRect.X + stickRect.Width / 2;
            Point leftFoot = new Point(stickRect.Left, stickRect.Bottom);
            Point rightFoot = new Point(stickRect.Right, stickRect.Bottom);
            Point midSection = new Point(midX, stickRect.Y + (int)(stickRect.Height * 0.6));
            Point shoulderSection = new Point(midX, stickRect.Y + (int)(stickRect.Height * 0.4));
            Point leftArm = new Point(stickRect.Left, stickRect.Y + (int)(stickRect.Height * 0.5));
            Point rightArm = new Point(stickRect.Right, stickRect.Y + (int)(stickRect.Height * 0.5));
            Point neckSection = new Point(midX, stickRect.Y + (int)(stickRect.Height * 0.3));
            Point headSection = new Point(midX, stickRect.Y + (int)(stickRect.Height * 0.1));

            //draw legs
            graphics.DrawLine(stickPen, leftFoot, midSection);
            graphics.DrawLine(stickPen, rightFoot, midSection);

            //draw body
            graphics.DrawLine(stickPen, midSection, shoulderSection);
            graphics.DrawLine(stickPen, shoulderSection, neckSection);

            //draw arms
            graphics.DrawLine(stickPen, shoulderSection, leftArm);
            graphics.DrawLine(stickPen, shoulderSection, rightArm);

            //draw head
            float headWidth = stickRect.Height * 0.4f;
            float headHeight = stickRect.Height * 0.4f;

            graphics.DrawEllipse(stickPen, headSection.X - headWidth / 2, headSection.Y - headHeight / 2,
                stickRect.Height * 0.4f, stickRect.Height * 0.4f);
        }
    }
}

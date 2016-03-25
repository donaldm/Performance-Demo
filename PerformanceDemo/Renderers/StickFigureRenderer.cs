using PerformanceDemo.Game_Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Renderers
{
    class StickFigureRenderer
    {
        private StickFigure stickFigure;

        public StickFigureRenderer(StickFigure stickFigureToRender)
        {
            stickFigure = stickFigureToRender;
        }

        public StickFigure CurrentStickFigure
        {
            set
            {
                stickFigure = value;
            }
            get
            {
                return stickFigure;
            }
        }

        public Rectangle CalculateBoundingBox()
        {
            int stickWidth = stickFigure.Width;
            int stickHeight = stickFigure.Height;
            int halfStickWidth = stickWidth / 2;
            int halfStickHeight = stickHeight / 2;
            int stickX = (int)(stickFigure.Position.X - halfStickWidth);
            int stickY = (int)(stickFigure.Position.Y - halfStickHeight);

            Rectangle rect = new Rectangle(stickX, stickY, stickWidth, stickHeight);
            return rect;
        }

        public void Draw(Graphics graphics)
        {
            Rectangle stickRect = CalculateBoundingBox();
            Pen stickPen = Pens.Green;

            int midX = stickRect.X + stickRect.Width / 2;
            Point leftFoot = new Point(stickRect.Left, stickRect.Bottom);
            Point rightFoot = new Point(stickRect.Right, stickRect.Bottom);
            Point midSection = new Point(midX, stickRect.Y + (int)(stickRect.Height * 0.6) );
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

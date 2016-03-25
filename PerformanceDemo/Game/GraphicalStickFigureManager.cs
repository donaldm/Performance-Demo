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
    class GraphicalStickFigureManager : StickFigureManager
    {
        private Rectangle boundary;
        private Random random;

        public GraphicalStickFigureManager(Rectangle windowBoundary) : base()
        {
            boundary = windowBoundary;
            random = new Random();
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

        public override void UpdateStickFigure(WorldParameters parameters, StickFigure stickFigure)
        {
            base.UpdateStickFigure(parameters, stickFigure);

            StickFigureRenderer stickRenderer = new StickFigureRenderer(stickFigure);
            Rectangle stickRectangle = stickRenderer.CalculateBoundingBox();

            if (stickRectangle.X < boundary.X)
            {
                stickFigure.Velocity.X = Math.Abs(stickFigure.Velocity.X) * parameters.Damping;
                stickFigure.Position.X = boundary.X + stickFigure.Height / 2;
            }
            if (stickRectangle.X + stickRectangle.Width > boundary.Width)
            {
                stickFigure.Velocity.X = -Math.Abs(stickFigure.Velocity.X) * parameters.Damping;
                stickFigure.Position.X = boundary.Width - stickFigure.Width / 2;
            }
            if (stickRectangle.Y < boundary.Y)
            {
                stickFigure.Velocity.Y = Math.Abs(stickFigure.Velocity.Y) * parameters.Damping;
                stickFigure.Position.Y = boundary.Y + stickFigure.Height / 2;
            }
            if (stickRectangle.Y + stickRectangle.Height > boundary.Height)
            {
                stickFigure.Velocity.Y = 0;
                stickFigure.Position.Y = boundary.Height - stickFigure.Height / 2;
            }
        }

        public void Draw(Graphics graphics)
        {
            foreach (StickFigure curStickFigure in stickFigures)
            {
                StickFigureRenderer stickFigureRenderer = new StickFigureRenderer(curStickFigure);
                stickFigureRenderer.Draw(graphics);
            }
        }
    }
}

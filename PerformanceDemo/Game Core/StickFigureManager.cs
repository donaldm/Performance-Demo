using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Game_Core
{
    class StickFigureManager
    {
        protected List<StickFigure> stickFigures;
        private Rectangle boundary;
        private Random random;

        public StickFigureManager(Rectangle windowBoundary)
        {
            stickFigures = new List<StickFigure>();
            boundary = windowBoundary;
            random = new Random();
        }

        public void AddStickFigure(StickFigure stickFigure)
        {
            stickFigures.Add(stickFigure);
        }

        public void RemoveStickFigure(StickFigure stickFigure)
        {
            stickFigures.Remove(stickFigure);
        }

        public void Clear()
        {
            stickFigures.Clear();
        }

        public List<StickFigure> StickFigures
        {
            get
            {
                return stickFigures;
            }
        }

        public void Update(WorldParameters parameters)
        {
            foreach (StickFigure curStickFigure in stickFigures)
            {
                UpdateStickFigure(parameters, curStickFigure);
            }
        }

        public virtual void UpdateStickFigure(WorldParameters parameters, StickFigure stickFigure)
        {
            stickFigure.Update(parameters);

            Rectangle stickRectangle = stickFigure.CalculateBoundingBox();

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

        public void Draw(Graphics graphics)
        {
            foreach (StickFigure curStickFigure in stickFigures)
            {
                curStickFigure.Draw(graphics);
            }
        }
    }
}

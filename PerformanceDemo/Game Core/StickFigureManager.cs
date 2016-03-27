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

        public StickFigureManager()
        {
            stickFigures = new List<StickFigure>();
        }

        public List<StickFigure> StickFigures
        {
            get
            {
                return stickFigures;
            }
        }

        public int Count
        {
            get
            {
                return stickFigures.Count;
            }
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

        public void Update(WorldParameters parameters)
        {
            foreach (StickFigure curStickFigure in stickFigures)
            {
                curStickFigure.Update(parameters);
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

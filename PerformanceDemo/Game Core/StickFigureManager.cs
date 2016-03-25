using System;
using System.Collections.Generic;
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
        }
    }
}

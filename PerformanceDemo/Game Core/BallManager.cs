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

        public BallManager()
        {
            balls = new List<Ball>();
        }

        public List<Ball> Balls => balls;

        public int Count => balls.Count;

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
                curBall.Update(parameters);
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

using PerformanceDemo.Utilities;
using System;
using System.Collections.Generic;
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

        public int Count
        {
            get
            {
                return balls.Count;
            }
        }

        public void Update(WorldParameters parameters)
        {
            foreach (Ball curBall in balls)
            {
                UpdateBall(parameters, curBall);
            }
        }

        public virtual void UpdateBall(WorldParameters parameters, Ball ball)
        {
            ball.Update(parameters);
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
    }
}

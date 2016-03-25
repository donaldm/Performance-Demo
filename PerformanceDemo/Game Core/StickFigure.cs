using PerformanceDemo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Game_Core
{
    class StickFigure
    {
        private Vector2 position;
        private Vector2 velocity;
        private int width;
        private int height;
        private double headMultiplier;

        public StickFigure(Vector2 startPosition, Vector2 startVelocity, int startWidth, int startHeight, int startHeadMultiplier)
        {
            position = startPosition;
            velocity = startVelocity;
            width = startWidth;
            height = startHeight;
            headMultiplier = startHeadMultiplier;
        }

        public void Update(WorldParameters parameters)
        {
            velocity.Y += parameters.Gravity;
            position += velocity;
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
    }
}

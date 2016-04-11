using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Game_Core
{
    public class WorldParameters
    {
        private Random worldRandom;

        public WorldParameters(double pGravity, double pDamping, Rectangle pBoundary)
        {
            Gravity = pGravity;
            Damping = pDamping;
            Boundary = pBoundary;
            worldRandom = new Random();
        }

        public double Gravity { get; set; }

        public double Damping { get; set; }

        public Rectangle Boundary { get; set; }

        public Random WorldRandom => worldRandom;
    }
}

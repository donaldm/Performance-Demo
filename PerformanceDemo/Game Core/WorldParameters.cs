using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Game_Core
{
    class WorldParameters
    {
        private double gravity;
        private double damping;

        public WorldParameters(double pGravity, double pDamping)
        {
            gravity = pGravity;
            damping = pDamping;
        }

        public double Gravity
        {
            set
            {
                gravity = value;
            }

            get
            {
                return gravity;
            }
        }

        public double Damping
        {
            set
            {
                damping = value;
            }

            get
            {
                return damping;
            }
        }
    }
}

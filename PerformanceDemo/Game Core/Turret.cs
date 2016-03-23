using PerformanceDemo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Game_Core
{
    class Turret
    {
        Vector2 location;
        double angle;
        double length;
        double baseWidth;
        double baseHeight;
        double turretWidth;

        public Turret(Vector2 startLocation, double startAngle, double startLength, 
                      double startBaseWidth, double startBaseHeight, double startTurretWidth)
        {
            location = startLocation;
            angle = startAngle;
            length = startLength;
            baseWidth = startBaseWidth;
            baseHeight = startBaseHeight;
            turretWidth = startTurretWidth;
        }

        public void RotateTowards(double x, double y)
        {
            double deltaX = x - location.X;
            double deltaY = y - location.Y;
            angle = Math.Atan2(deltaY, deltaX);
        }

        public Vector2 Location
        {
            set
            {
                location = value;
            }

            get
            {
                return location;
            }
        }

        public Vector2 EndLocation
        {
            get
            {
                Vector2 turretVector = Vector2.FromAngleAndLength(angle, length);
                return location + turretVector;
            }
        }

        public double Angle
        {
            set
            {
                angle = value;
            }

            get
            {
                return angle;
            }
        }

        public double Length
        {
            set
            {
                length = Length;
            }

            get
            {
                return length;
            }
        }

        public double BaseWidth
        {
            set
            {
                baseWidth = value;
            }

            get
            {
                return baseWidth;
            }
        }

        public double BaseHeight
        {
            set
            {
                baseHeight = value;
            }

            get
            {
                return baseHeight;
            }
        }

        public double TurretWidth
        {
            set
            {
                turretWidth = value;
            }

            get
            {
                return turretWidth;
            }
        }
    }
}

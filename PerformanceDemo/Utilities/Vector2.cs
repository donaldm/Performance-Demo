using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Utilities
{
    class Vector2
    {
        double x;
        double y;

        public Vector2(double pX, double pY)
        {
            x = pX;
            y = pY;
        }

        public static Vector2 FromAngleAndLength(double angle, double length)
        {
            double x = Math.Cos(angle) * length;
            double y = Math.Sin(angle) * length;
            return new Vector2(x, y);
        }

        public double X
        {
            set
            {
                x = value;
            }
            get
            {
                return x;
            }
        }

        public double Y
        {
            set
            {
                y = value;
            }
            get
            {
                return y;
            }
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            }
        }

        public double Angle
        {
            get
            {
                return Math.Atan2(Y, X);
            }
        }

        public Vector2 Normalized
        {
            get
            {
                double normalizeLength = Length;
                if (normalizeLength == 0)
                {
                    normalizeLength = 1;
                }
                return new Vector2(x / normalizeLength, y / normalizeLength);
            }
        }

        public static Vector2 operator +(Vector2 first, Vector2 second)
        {
            return new Vector2(first.X + second.X, first.Y + second.Y);
        }

        public static Vector2 operator -(Vector2 first, Vector2 second)
        {
            return new Vector2(first.X - second.X, first.Y - second.Y);
        }

        public static Vector2 operator *(Vector2 input, double val)
        {
            return new Vector2(input.X * val, input.Y * val);
        }
    }
}

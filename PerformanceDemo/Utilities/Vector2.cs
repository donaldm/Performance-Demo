using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Utilities
{
    public class Vector2
    {
        public Vector2(double pX, double pY)
        {
            X = pX;
            Y = pY;
        }

        public Vector2(Vector2 vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        public static Vector2 FromAngleAndLength(double angle, double length)
        {
            double x = Math.Cos(angle) * length;
            double y = Math.Sin(angle) * length;
            return new Vector2(x, y);
        }

        public double X { set; get; }

        public double Y { set; get; }

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
                return new Vector2(X / normalizeLength, Y / normalizeLength);
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

        public static bool operator ==(Vector2 first, Vector2 second)
        {
            if (first.X == second.X && first.Y == second.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Vector2 first, Vector2 second)
        {
            if (first.X != second.X || first.Y != second.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

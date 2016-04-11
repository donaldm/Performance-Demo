using PerformanceDemo.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Game_Core
{
    public class Turret
    {
        private Pen turretPen;

        public Turret(Vector2 startLocation, double startAngle, double startLength, 
                      double startBaseWidth, double startBaseHeight, double startTurretWidth)
        {
            Location = startLocation;
            Angle = startAngle;
            Length = startLength;
            BaseWidth = startBaseWidth;
            BaseHeight = startBaseHeight;
            TurretWidth = startTurretWidth;

            turretPen = new Pen(Color.White, (int)TurretWidth);
        }

        public Vector2 Location { set; get; }

        public Vector2 EndLocation
        {
            get
            {
                Vector2 turretVector = Vector2.FromAngleAndLength(Angle, Length);
                return Location + turretVector;
            }
        }

        public double Angle { set; get; }

        public double Length { set; get; }

        public double BaseWidth { set; get; }

        public double BaseHeight { set; get; }

        public double TurretWidth { set; get; }

        public Rectangle CalculateBoundingBox()
        {
            double turretX = Location.X;
            double turretY = Location.Y;
            double halfTurretWidth = BaseWidth / 2.0;
            double halfTurretHeight = BaseHeight / 2.0;
            double turretStartX = turretX - halfTurretWidth;
            double turretStartY = turretY - halfTurretHeight;

            Rectangle turretRectangle = new Rectangle((int)turretStartX, (int)turretStartY, (int)BaseWidth, (int)BaseHeight);
            return turretRectangle;
        }

        public void RotateTowards(double x, double y)
        {
            Vector2 targetLocation = new Vector2(x, y);
            Vector2 delta = targetLocation - Location;
            Angle = delta.Angle;
        }

        public void Draw(Graphics graphics)
        {
            Rectangle turretRectangle = CalculateBoundingBox();
            graphics.FillEllipse(Brushes.White, turretRectangle);
            Point startPoint = new Point((int)Location.X, (int)Location.Y);
            Point endPoint = new Point((int)EndLocation.X, (int)EndLocation.Y);
            graphics.DrawLine(turretPen, startPoint, endPoint);
        }
    }
}

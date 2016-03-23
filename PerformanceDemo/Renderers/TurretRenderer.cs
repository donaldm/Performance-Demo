using PerformanceDemo.Game_Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Renderers
{
    class TurretRenderer
    {
        private Turret turret;
        private Pen turretPen;

        public TurretRenderer(Turret turretToRender)
        {
            turret = turretToRender;
            turretPen = new Pen(Color.White, (int)turret.TurretWidth);
        }

        public Turret CurrentTurret
        {
            set
            {
                turret = value;
            }
            get
            {
                return turret;
            }
        }

        public Rectangle CalculateBoundingBox()
        {
            double turretX = turret.Location.X;
            double turretY = turret.Location.Y;
            double halfTurretWidth = turret.BaseWidth / 2.0;
            double halfTurretHeight = turret.BaseHeight / 2.0;
            double turretStartX = turretX - halfTurretWidth;
            double turretStartY = turretY - halfTurretHeight;

            Rectangle turretRectangle = new Rectangle((int)turretStartX, (int)turretStartY, (int)turret.BaseWidth, (int)turret.BaseHeight);
            return turretRectangle;
        }

        public void Draw(Graphics graphics)
        {
            Rectangle turretRectangle = CalculateBoundingBox();
            graphics.FillEllipse(Brushes.White, turretRectangle);
            Point startPoint = new Point((int)turret.Location.X, (int)turret.Location.Y);
            Point endPoint = new Point((int)turret.EndLocation.X, (int)turret.EndLocation.Y);
            graphics.DrawLine(turretPen, startPoint, endPoint);
        }
    }
}

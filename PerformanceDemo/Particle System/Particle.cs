using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceDemo.Game_Core;
using PerformanceDemo.Utilities;

namespace PerformanceDemo.Particle_System
{
    public class Particle : IGraphicalItem
    {
        public event Action<IGraphicalItem> Destroyed;

        public Particle(Vector2 location, Vector2 velocity, int particleSize, int lifeSpan, Color particleColor)
        {
            Location = location;
            Velocity = velocity;
            ParticleSize = particleSize;
            TotalLife = lifeSpan;
            LifeSpan = lifeSpan;
            ParticleColor = particleColor;
        }

        public Vector2 Location { set; get; }
        public Vector2 Velocity { set; get; }
        public int LifeSpan { set; get; }
        public int TotalLife { set; get; }
        public int ParticleSize { set; get; }
        public Color ParticleColor { set; get; }

        public void Update(WorldParameters parameters)
        {
            Velocity.Y += parameters.Gravity;
            Location += Velocity;
            LifeSpan = Math.Max(LifeSpan - 1, 0);

            if (LifeSpan <= 0)
            {
                Destroy();
            }
        }

        public void Draw(Graphics graphics)
        {
            double colorPercentage = (LifeSpan/(TotalLife + 0.0));
            int red = ParticleColor.R;
            int green = ParticleColor.G;
            int blue = ParticleColor.B;
            int alpha = (int)(255*colorPercentage);
            Color currentParticle = Color.FromArgb(alpha, red, green, blue);
            graphics.FillEllipse(new SolidBrush(currentParticle), CalculateBoundingBox() );
        }

        public bool Contains(Vector2 testLocation)
        {
            int x = (int)Location.X;
            int y = (int)Location.Y;
            return CalculateBoundingBox().Contains(x, y);
        }

        public Rectangle CalculateBoundingBox()
        {
            int x = (int)Location.X;
            int y = (int)Location.Y;
            int width = ParticleSize;
            int height = ParticleSize;

            return new Rectangle(x, y, width, height);
        }

        public void Destroy()
        {
            Destroyed(this);
        }
    }
}

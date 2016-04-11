using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceDemo.Utilities;

namespace PerformanceDemo.Particle_System
{
    public class EmitterSettings
    {
        public EmitterSettings()
        {
            Location = new Vector2(0,0);
            Velocity = new Vector2(1,1);
            Radius = 0;
            ParticleCount = 0;
            ParticleColor = Color.White;
            ParticleLifeSpan = 0;
        }

        public EmitterSettings(Vector2 location, Vector2 velocity, int radius, int particleCount, int particleLifeSpan, Color particleColor)
        {
            Location = location;
            Velocity = velocity;
            Radius = radius;
            ParticleCount = particleCount;
            ParticleColor = particleColor;
        }

        public Vector2 Location { set; get; }
        public Vector2 Velocity { set; get; }
        public int Radius { set; get; }
        public int ParticleCount { set; get; }
        public int ParticleLifeSpan { set; get; }
        public Color ParticleColor { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PerformanceDemo.Game_Core;
using PerformanceDemo.Particle_System;
using PerformanceDemo.Utilities;

namespace PerformanceDemo.Particle_System
{
    public class ParticleSystem : GraphicalManager
    {
        private List<IGraphicalItem> destroyedItems;
 
        public ParticleSystem()
          :base()
        {
            destroyedItems = new List<IGraphicalItem>();
        }

        public void Emit(EmitterSettings emitterSettings)
        {
            Random particleRandom = new Random();
            Vector2 startingLocation = emitterSettings.Location;
            int radius = emitterSettings.Radius;

            for (int curIdx = 0; curIdx < emitterSettings.ParticleCount; curIdx++)
            {
                int xoffset = particleRandom.Next(-radius, radius);
                int yoffset = particleRandom.Next(-radius, radius);
                int lifeSpan = particleRandom.Next(1, emitterSettings.ParticleLifeSpan);
                int particleSize = particleRandom.Next(1, 5);
                Vector2 offset = new Vector2(xoffset, yoffset);
                Vector2 particleLocation = startingLocation + offset;
                int xVelocity = particleRandom.Next(-10, 10);
                int yVelocity = particleRandom.Next(-10, 10);
                Vector2 particleVelocity = new Vector2(xVelocity, yVelocity);

                Particle particle = new Particle(particleLocation, particleVelocity, particleSize, lifeSpan,
                    emitterSettings.ParticleColor);

                particle.Destroyed += Particle_Destroyed;

                AddItem(particle);
            }
        }

        public override void Update(WorldParameters worldParameters)
        {
            base.Update(worldParameters);

            foreach (IGraphicalItem graphicalItem in destroyedItems)
            {
                RemoveItem(graphicalItem);
            }
            destroyedItems.Clear();
        }

        private void Particle_Destroyed(IGraphicalItem graphicalItem)
        {
            destroyedItems.Add(graphicalItem);
        }
    }
}

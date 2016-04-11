using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PerformanceDemo.Properties;
using PerformanceDemo.Utilities;

namespace PerformanceDemo.Game_Core
{
    class LionBall : Ball
    {
        private static Image lionHeadImage;

        public LionBall(double startRadius, Vector2 startPosition, Vector2 startVelocity, bool reduced = false)
         : base(startRadius, startPosition, startVelocity)
        {
            string lionResourceName = "LionHead";
            if (reduced)
            {
                lionResourceName = "LionHeadReduced";
            }

            lionHeadImage = Resources.ResourceManager.GetObject(lionResourceName) as Image;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(lionHeadImage, CalculateBoundingBox());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PerformanceDemo.Utilities;

namespace PerformanceDemo.Game_Core
{
    public interface IGraphicalItem
    {
        void Update(WorldParameters parameters);
        void Draw(Graphics graphics);
        bool Contains(Vector2 testLocation);
        Rectangle CalculateBoundingBox();
        void Destroy();
    }
}

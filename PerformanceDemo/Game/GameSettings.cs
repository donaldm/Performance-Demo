using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Game
{
    public enum GameMode
    {
        Normal,
        Lion
    }

    public class GameSettings
    {
        public GameSettings()
        {
            Mode = GameMode.Normal;
            OptimizeGraphics = true;
            ImmortalParticles = false;
            CrazyAlgorithm = false;
        }

        public GameMode Mode { set; get; }

        public bool OptimizeGraphics { set; get; }
        public bool ImmortalParticles;
        public bool CrazyAlgorithm;
    }
}

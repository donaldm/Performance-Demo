using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

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

        public void Load(String filepath)
        {
            string jsonText = File.ReadAllText(filepath);
            GameSettings loadedSettings = JsonConvert.DeserializeObject<GameSettings>(jsonText);
            Copy(loadedSettings);
        }

        public void Copy(GameSettings gameSettings)
        {
            Mode = gameSettings.Mode;
            OptimizeGraphics = gameSettings.OptimizeGraphics;
            ImmortalParticles = gameSettings.ImmortalParticles;
            CrazyAlgorithm = gameSettings.CrazyAlgorithm;
        }

        public void Save(String filepath)
        {
            string jsonText = JsonConvert.SerializeObject(this);
            File.WriteAllText(filepath, jsonText);
        }
    }
}

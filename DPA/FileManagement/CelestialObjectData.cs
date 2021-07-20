using DPA.Enum;
using DPA.State;
using System.Drawing;

namespace DPA.FileManagement
{
    public class CelestialObjectData
    {
        public CelestialObjectType type { get; set; }
        public string name { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public int radius { get; set; }
        public double vx { get; set; }
        public double vy { get; set; }
        public string[] neighbours { get; set; }
        public Color color { get; set; }
        public EffectState effectState { get; set; }
    }
}

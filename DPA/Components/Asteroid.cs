using DPA.Enum;
using DPA.State;
using System.Drawing;

namespace DPA.Components
{
    public class Asteroid : CelestialObject
    {
        public Asteroid() { }

		public Asteroid(Color color, float coord_x, float coord_y, EffectState effectState, int radius, CelestialObjectType type, double vx, double vy) : base(color, coord_x, coord_y, effectState, radius, type, vx, vy) { }

		public override CelestialObject copy()
		{
			return new Asteroid(Color, CoordX, CoordY, EffectState.Copy(), Radius, Type, VelX, VelY);
		}
	}
}
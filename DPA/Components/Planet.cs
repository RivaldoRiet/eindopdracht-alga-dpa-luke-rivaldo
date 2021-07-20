using DPA.Enum;
using DPA.Repository;
using DPA.State;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DPA.Components
{
    public class Planet : CelestialObject
    {
        protected static readonly int CONNECTION_WIDTH = 2;
        protected static readonly Color CONNECTION_COLOR = Color.Aqua;

        public string Name { get; set; }
        public string[] Neighbours { get; set; }

        public Planet() { }

		public Planet(string name, Color color, float coord_x, float coord_y, string[] neighbours, EffectState effectState, int radius, CelestialObjectType type, double vx, double vy)
			: base(color, coord_x, coord_y, effectState, radius, type, vx, vy)
		{
			Name = name;
			Neighbours = neighbours;
		}

        public override void Draw(PaintEventArgs e)
        {
            base.Draw(e);
            // TODO: Draws each connection twice. How should we fix this?
            foreach (string neighbour in Neighbours)
            {
                Planet neighbourPlanet = CelestialObjectRepository.Instance.GetPlanetByName(neighbour);
                Pen pen = new Pen(CONNECTION_COLOR, CONNECTION_WIDTH);
                int planetOffset = (Radius / 2);
                int neighbourPlanetOffset = (neighbourPlanet.Radius / 2);
                e.Graphics.DrawLine(pen, CoordX + planetOffset, CoordY + planetOffset, neighbourPlanet.CoordX + neighbourPlanetOffset, neighbourPlanet.CoordY + neighbourPlanetOffset);
            }
        }

		public override CelestialObject copy()
		{
			return new Planet((string)Name.Clone(), Color, CoordX, CoordY, Neighbours.Select(s => (string)s.Clone()).ToArray(), EffectState.Copy(), Radius, Type, VelX, VelY);
		}
	}
}
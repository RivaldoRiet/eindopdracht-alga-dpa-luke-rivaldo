using DPA.Enum;
using DPA.Interface;
using DPA.Observer;
using DPA.Repository;
using DPA.State;
using System.Drawing;
using System.Windows.Forms;

namespace DPA.Components
{
	public abstract class CelestialObject : ICollisionObserver
	{
		public CelestialObjectType Type { get; set; }
		public Color Color { get; set; }
		public float CoordX { get; set; }
		public float CoordY { get; set; }
		public int Radius { get; set; }
		public double VelX { get; set; }
		public double VelY { get; set; }
		public EffectState EffectState { get; set; }
		public bool HasCollisionTriggeredEffectOnce { get; set; }

		public CelestialObject(Color color, float coord_x, float coord_y, EffectState effectState, int radius, CelestialObjectType type, double vx, double vy)
		{
			Color = color;
			CoordX = coord_x;
			CoordY = coord_y;
			Radius = radius;
			Type = type;
			VelX = vx;
			VelY = vy;
			EffectState = effectState;
			EffectState.SetContext(this);
		}

        public CelestialObject() { }

        public virtual void Destroy()
        {
            CelestialObjectRepository.Instance.RemoveFromCelestialObjectList(this);
        }

        public void UpdateCollisions(ICollisionDetector subject)
        {
            if (subject.GetCurrentColliders().Contains(this))
            {
                EffectState.SetContext(this);
                EffectState.DoEffect();
            }
            else if (subject.GetPreviousColliders().Contains(this))
            {
                if (HasCollisionTriggeredEffectOnce)
                {
                    HasCollisionTriggeredEffectOnce = false;
                }

                EffectState.Restore();
                EffectState.SetContext(this);
            }
        }

        public virtual void Draw(PaintEventArgs e)
        {
            Pen pen = new Pen(Color, Radius);
            e.Graphics.DrawEllipse(pen, CoordX, CoordY, Radius,
                    Radius);
        }

        public virtual void ChangeEffectState(EffectState state)
        {
            EffectState = state;
            EffectState.SetContext(this);
        }

        public virtual void Move()
        {
            ChangeDirectionIfNecessary(0, 0, 800, 600); // TODO: Remove hard coded values.
            CoordX += (float)VelX;
            CoordY += (float)VelY;
        }

        private void ChangeDirectionIfNecessary(int xPos1, int yPos1, int xPos2, int yPos2)
        {
            if (xPos1 >= CoordX || CoordX >= xPos2)
            {
                VelX = -VelX;
            }

            if (yPos1 >= CoordY || CoordY >= yPos2)
            {
                VelY = -VelY;
            }
        }

        public abstract CelestialObject copy();
    }
}
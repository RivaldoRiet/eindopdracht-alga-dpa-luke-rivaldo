using DPA.Components;

namespace DPA.State
{
    public abstract class EffectState
    {
        protected CelestialObject Context { get; set; }
        protected int EffectCount { get; set; }

		public EffectState(CelestialObject context, int effectCount)
		{
			Context = context;
			EffectCount = effectCount;
		}

		public EffectState(int effectCount)
        {
            EffectCount = effectCount;
        }

		public void SetContext(CelestialObject value)
		{
			Context = value;
		}

		public abstract void DoEffect();
		public abstract void Restore();
		public abstract EffectState Copy();
	}
}

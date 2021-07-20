using DPA.Components;

namespace DPA.State
{
    public class BounceEffect : EffectState
    {
        private readonly bool _hasSpawnedFromExplode;

		public BounceEffect(CelestialObject context, int bounceCount, bool hasSpawnedFromExplode) : base(context, bounceCount)
		{
			_hasSpawnedFromExplode = hasSpawnedFromExplode;
		}

		public BounceEffect(bool hasSpawnedFromExplode) : base(0)
		{
			_hasSpawnedFromExplode = hasSpawnedFromExplode;
		}

        public override void DoEffect()
        {
            if (_hasSpawnedFromExplode && EffectCount >= 1)
            {
                if (!Context.HasCollisionTriggeredEffectOnce)
                {
                    if (EffectCount > 5)
                    {
                        Context.ChangeEffectState(new BlinkEffect(Context.Color));
                    }
                    else
                    {
                        Context.VelX = -Context.VelX;
                        Context.VelY = -Context.VelY;
                        EffectCount++;
                    }

                    Context.HasCollisionTriggeredEffectOnce = true;
                }
            }
        }

        public override void Restore()
        {

		}
		public override EffectState Copy()
		{
			return new BounceEffect(Context, EffectCount, _hasSpawnedFromExplode);
		}
	}
}

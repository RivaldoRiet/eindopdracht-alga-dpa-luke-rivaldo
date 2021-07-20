using DPA.Components;

namespace DPA.State
{
	public class GrowEffect : EffectState
	{
		public GrowEffect(CelestialObject context, int growCount) : base(context, growCount)
		{
		}

		public GrowEffect() : base(0)
		{
		}

        public override void DoEffect()
        {
            if (!Context.HasCollisionTriggeredEffectOnce)
            {
                if (Context.Radius >= 20)
                {
                    Context.ChangeEffectState(new ExplodeEffect());
                }
                else
                {
                    Context.Radius++;
                }

                Context.HasCollisionTriggeredEffectOnce = true;
            }
        }

        public override void Restore()
        {

		}

		public override EffectState Copy()
		{
			return new GrowEffect(Context, EffectCount);
		}
	}
}

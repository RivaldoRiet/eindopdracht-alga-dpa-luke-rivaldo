using DPA.Components;

namespace DPA.State
{
    public class DisappearEffect : EffectState
    {
		public DisappearEffect(CelestialObject context, int disappearCount) : base(context, disappearCount)
		{
		}

		public DisappearEffect() : base(0)
		{
		}

        public override void DoEffect()
        {
            if (EffectCount < 1)
            {
                EffectCount++;
                Context.Destroy();
            }
        }

        public override void Restore()
        {

		}

		public override EffectState Copy()
		{
			return new DisappearEffect(Context, EffectCount);
		}
	}
}

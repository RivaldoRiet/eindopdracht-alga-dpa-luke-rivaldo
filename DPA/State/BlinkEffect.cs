using DPA.Components;
using System;
using System.Drawing;

namespace DPA.State
{
    public class BlinkEffect : EffectState
    {
        private static readonly Random RANDOM = new Random();
        private readonly Color _originalColor;

		public BlinkEffect(CelestialObject context, int blinkCount, Color originalColor) : base(context, blinkCount)
		{
			_originalColor = originalColor;
		}

		public BlinkEffect(Color originalColor) : base(0)
		{
			_originalColor = originalColor;
		}

        public override void DoEffect()
        {
            Context.Color = Color.FromArgb(RANDOM.Next(256), RANDOM.Next(256), RANDOM.Next(256));
        }

		public override void Restore()
		{
			Context.Color = _originalColor;
		}

		public override EffectState Copy()
		{
			return new BlinkEffect(_originalColor);
		}
	}
}

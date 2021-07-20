using DPA.Components;
using DPA.Enum;
using DPA.Repository;
using System;
using System.Drawing;

namespace DPA.State
{
	public class ExplodeEffect : EffectState
	{
		private static readonly int CHILD_AMOUNT = 5;
		private static readonly int CHILD_RADIUS = 3;
		private static readonly double CHILD_SPEED_MULTIPLIER = 7.5;

		public ExplodeEffect(CelestialObject context, int explodeCount) : base(context, explodeCount)
		{
		}

		public ExplodeEffect() : base(0)
		{
		}

		public override void DoEffect()
		{
			if (EffectCount < 1)
			{
				Random rand = new Random();
				for (int i = 0; i < CHILD_AMOUNT; i++)
				{
					double vX = 0;
					double vY = 0;
					while (vX == 0 && vY == 0)
					{
						vX = (rand.NextDouble() - 0.5) * CHILD_SPEED_MULTIPLIER;
						vY = (rand.NextDouble() - 0.5) * CHILD_SPEED_MULTIPLIER;
					}

					CelestialObject childAsteroid = new Asteroid(Color.Black, Context.CoordX, Context.CoordY, new BounceEffect(true), CHILD_RADIUS, CelestialObjectType.ASTEROID, vX, vY);
					CelestialObjectRepository.Instance.AddCelestialObject(childAsteroid);
				}

				EffectCount++;
				Context.Destroy();
			}
		}

		public override void Restore()
		{

		}

		public override EffectState Copy()
		{
			return new ExplodeEffect(Context, EffectCount);
		}
	}
}

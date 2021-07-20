using DPA.Components;
using DPA.Enum;
using DPA.Repository;
using DPA.State;
using System;
using System.Drawing;

namespace DPA.Command
{
    public class AddAsteroidCommand : ICommand
    {
        private static readonly double SPEED_MULTIPLIER = 7.5;
        private static readonly int ASTEROID_RADIUS = 3;

        public void Execute()
        {
            Random rand = new Random();
            double vX = 0;
            double vY = 0;
            while (vX == 0 && vY == 0)
            {
                vX = (rand.NextDouble() - 0.5) * SPEED_MULTIPLIER;
                vY = (rand.NextDouble() - 0.5) * SPEED_MULTIPLIER;
            }
            int xPos = rand.Next(0, 800);
            int yPos = rand.Next(0, 600);

			CelestialObject childAsteroid = new Asteroid(Color.Black, xPos, yPos, new BounceEffect(false), ASTEROID_RADIUS, CelestialObjectType.ASTEROID, vX, vY);
			CelestialObjectRepository.Instance.AddCelestialObject(childAsteroid);
        }
    }
}

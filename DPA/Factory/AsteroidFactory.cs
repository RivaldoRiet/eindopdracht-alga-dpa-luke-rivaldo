using DPA.Components;
using DPA.FileManagement;
using DPA.Repository;

namespace DPA.Factory
{
	public class AsteroidFactory : ICelestialObjectFactory
	{
		public void Make(CelestialObjectData celestialObjectData)
		{
			var newAsteroid = new Asteroid(celestialObjectData.color, celestialObjectData.x, celestialObjectData.y, celestialObjectData.effectState, celestialObjectData.radius, celestialObjectData.type,
									celestialObjectData.vx, celestialObjectData.vy);
			CelestialObjectRepository.Instance.AddCelestialObject(newAsteroid);
		}
	}
}

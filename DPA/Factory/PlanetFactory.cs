using DPA.Components;
using DPA.FileManagement;
using DPA.Repository;

namespace DPA.Factory
{
	class PlanetFactory : ICelestialObjectFactory
	{
		public void Make(CelestialObjectData celestialObjectData)
		{
			Planet newPlanet = new Planet(celestialObjectData.name, celestialObjectData.color, celestialObjectData.x, celestialObjectData.y, celestialObjectData.neighbours, celestialObjectData.effectState, celestialObjectData.radius,
										celestialObjectData.type, celestialObjectData.vx, celestialObjectData.vy);
			CelestialObjectRepository.Instance.AddCelestialObject(newPlanet);
		}
	}
}

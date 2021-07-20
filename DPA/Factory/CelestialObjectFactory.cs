using DPA.Enum;
using DPA.FileManagement;
using DPA.Repository;
using System.Collections.Generic;

namespace DPA.Factory
{
    public class CelestialObjectFactory
    {
        private readonly AsteroidFactory asteroidFactory;
        private readonly PlanetFactory planetFactory;

        private readonly Dictionary<string, ICelestialObjectFactory> celestialObjectDictionary;
        public CelestialObjectFactory()
        {
            celestialObjectDictionary = new Dictionary<string, ICelestialObjectFactory>();
            asteroidFactory = new AsteroidFactory();
            planetFactory = new PlanetFactory();
            celestialObjectDictionary.Add(CelestialObjectType.PLANET.ToString(), planetFactory);
            celestialObjectDictionary.Add(CelestialObjectType.ASTEROID.ToString(), asteroidFactory);
        }
        public void MakeCelestialObjects(List<CelestialObjectData> celestialObjectData)
        {
            CelestialObjectRepository.Instance.ClearList();
            foreach (CelestialObjectData celestialObject in celestialObjectData)
            {
                if (celestialObjectDictionary[celestialObject.type.ToString()] != null && celestialObjectDictionary.ContainsKey(celestialObject.type.ToString()))
                {
                    celestialObjectDictionary[celestialObject.type.ToString()].Make(celestialObject);
                }
            }
        }
    }
}

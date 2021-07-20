using DPA.Components;
using DPA.Enum;
using System.Collections.Generic;
using System.Diagnostics;

namespace DPA.Repository
{
    public class CelestialObjectRepository
    {
        private static readonly CelestialObjectRepository _instance = new CelestialObjectRepository();
        private List<CelestialObject> _celestialObjectList;
        private readonly List<CelestialObject> _toSubscribe;
        private readonly List<CelestialObject> _toUnsubscribe;

        static CelestialObjectRepository()
        {
        }

        private CelestialObjectRepository()
        {
            _celestialObjectList = new List<CelestialObject>();
            _toSubscribe = new List<CelestialObject>();
            _toUnsubscribe = new List<CelestialObject>();
        }


        public static CelestialObjectRepository Instance => _instance;

        public List<CelestialObject> GetCelestialObjectList()
        {
            return _celestialObjectList;
        }

        public List<CelestialObject> GetToSubscribeList()
        {
            return _toSubscribe;
        }

        public List<CelestialObject> GetToUnsubscribeList()
        {
            return _toUnsubscribe;
        }

        public void SetCelestialObjectList(List<CelestialObject> celestialObjects)
        {
            _celestialObjectList = celestialObjects;

            // Initialize the collision system.
            SimulationRepository.Instance.GetCollisionDetector().ClearSubscribers();
            foreach (CelestialObject co in _celestialObjectList)
            {
                _toSubscribe.Add(co);
            }
        }

        public void AddCelestialObject(CelestialObject celestialObject)
        {
            _celestialObjectList.Add(celestialObject);
            _toSubscribe.Add(celestialObject);
        }

        public void RemoveFromCelestialObjectList(CelestialObject celestialObject)
        {
            _celestialObjectList.Remove(celestialObject);
            _toUnsubscribe.Add(celestialObject);
        }

        // TODO: Remove after command pattern
        public void RemoveCelestialObjectAtIndex(int index)
        {
            if (0 <= index && index < _celestialObjectList.Count)
            {
                CelestialObject co = _celestialObjectList[index];
                _celestialObjectList.Remove(co);
                _toUnsubscribe.Add(co);
            }
            else
            {
                Debug.WriteLine("There was an attempt of removing a celestialobject at: " + index + ", but the index given is out of bounds. Request has been ignored.");
            }
        }

        // TODO: Remove after command pattern
        public CelestialObject GetCelestialObjectAtIndex(int index)
        {
            if (0 <= index && index < _celestialObjectList.Count)
            {
                return _celestialObjectList[index];
            }
            else
            {
                Debug.WriteLine("There was an attempt of fetching a celestialobject at: " + index + ", but the index given is out of bounds. Null was returned.");
            }

            return null;
        }

        public int GetAsteroidCount()
        {
            int count = 0;
            foreach (CelestialObject co in _celestialObjectList)
            {
                if (co.Type == CelestialObjectType.ASTEROID)
                {
                    count++;
                }
            }

            return count;
        }

        public void ClearList()
        {
            foreach (CelestialObject co in _celestialObjectList)
            {
                _toUnsubscribe.Add(co);
            }
            _celestialObjectList.Clear();
        }

        public Planet GetPlanetByName(string name)
        {
            List<CelestialObject> celestialObjectList = _celestialObjectList;
            foreach (CelestialObject co in celestialObjectList)
            {
                if (co.Type == CelestialObjectType.PLANET)
                {
                    Planet planet = (Planet)co;
                    if (planet.Name.Equals(name))
                    {
                        return planet;
                    }
                }
            }

            Debug.WriteLine("There was an attempt of fetching a planet by name: " + name + ", but no such planet was found. Null was returned.");
            return null;
        }
    }
}
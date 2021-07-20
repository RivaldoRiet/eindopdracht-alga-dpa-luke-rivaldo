using DPA.Components;
using System.Collections.Generic;

namespace DPA.Memento
{
    public class CelestialObjectListMemento
    {
        public List<CelestialObject> CelestialObjects { get; set; }

        public CelestialObjectListMemento(List<CelestialObject> CelestialObjects)
        {
            this.CelestialObjects = CelestialObjects;
        }

        public void Restore(CelestialObjectListMemento objMemento)
        {
			CelestialObjects = objMemento.CelestialObjects;
		}
	}
}
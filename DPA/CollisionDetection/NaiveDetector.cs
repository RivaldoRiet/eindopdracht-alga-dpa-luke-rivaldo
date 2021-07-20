using DPA.Components;
using DPA.Interface;
using DPA.Observer;
using DPA.Repository;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DPA.CollisionDetection
{
    public class NaiveDetector : ICollisionDetector
    {
        private static readonly string IDENTIFIER = "Naive";
        private readonly List<ICollisionObserver> _observers;
        private List<CelestialObject> _previousColliders;
        private List<CelestialObject> _currentColliders;

        public NaiveDetector()
        {
            _observers = new List<ICollisionObserver>();
            _previousColliders = new List<CelestialObject>();
            _currentColliders = new List<CelestialObject>();
        }

        public NaiveDetector(List<ICollisionObserver> observers, List<CelestialObject> previousColliders, List<CelestialObject> currentColliders)
        {
            _observers = new List<ICollisionObserver>(observers);
            _previousColliders = new List<CelestialObject>(previousColliders);
            _currentColliders = new List<CelestialObject>(currentColliders);
        }

        public List<CelestialObject> HandleCollisions()
        {
            List<CelestialObject> collisions = new List<CelestialObject>();
            // Check collisions between all objects in the current leaf.
            foreach (CelestialObject co1 in CelestialObjectRepository.Instance.GetCelestialObjectList())
            {
                foreach (CelestialObject co2 in CelestialObjectRepository.Instance.GetCelestialObjectList())
                {
                    if (co1 != co2 && !collisions.Contains(co1))
                    {
                        // Calculation to check if two circles overlap.
                        float co1CenterX = co1.CoordX + co1.Radius;
                        float co2CenterX = co2.CoordX + co2.Radius;
                        float co1CenterY = co1.CoordY + co1.Radius;
                        float co2CenterY = co2.CoordY + co2.Radius;

                        int radius = co1.Radius + co2.Radius;
                        float deltaX = co1CenterX - co2CenterX;
                        float deltaY = co1CenterY - co2CenterY;
                        if ((deltaX * deltaX) + (deltaY * deltaY) <= radius * radius)
                        {
                            collisions.Add(co1);
                        }
                    }
                }
            }

            _previousColliders = new List<CelestialObject>(_currentColliders);
            _currentColliders = new List<CelestialObject>(collisions);

            Notify();
            return _currentColliders;
        }

        public void Draw(PaintEventArgs e)
        {
            // I don't draw anything. But I could. This function gets called automatically when the Naive collision detector is active during runtime.
        }

        public List<CelestialObject> GetPreviousColliders()
        {
            return _previousColliders;
        }

        public List<CelestialObject> GetCurrentColliders()
        {
            return _currentColliders;
        }

        public List<ICollisionObserver> GetObservers()
        {
            return _observers;
        }

        public void Subscribe(ICollisionObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Unsubscribe(ICollisionObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void ClearSubscribers()
        {
            _observers.Clear();
        }

        public void Notify()
        {
            foreach (ICollisionObserver obs in _observers)
            {
                obs.UpdateCollisions(this);
            }
        }

        public string GetIdentifier()
        {
            return IDENTIFIER;
        }
    }
}
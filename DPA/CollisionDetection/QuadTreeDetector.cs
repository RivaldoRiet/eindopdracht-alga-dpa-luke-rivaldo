using DPA.Components;
using DPA.Interface;
using DPA.Observer;
using DPA.Repository;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DPA.CollisionDetection
{
    public class QuadTreeDetector : ICollisionDetector
    {
        private static readonly string IDENTIFIER = "QuadTree";
        private QuadTree root;
        private readonly List<ICollisionObserver> _observers;
        private List<CelestialObject> _previousColliders;
        private List<CelestialObject> _currentColliders;

        public QuadTreeDetector()
        {
            _observers = new List<ICollisionObserver>();
            _previousColliders = new List<CelestialObject>();
            _currentColliders = new List<CelestialObject>();
        }

        public QuadTreeDetector(List<ICollisionObserver> observers, List<CelestialObject> previousColliders, List<CelestialObject> currentColliders)
        {
            _observers = new List<ICollisionObserver>(observers);
            _previousColliders = new List<CelestialObject>(previousColliders);
            _currentColliders = new List<CelestialObject>(currentColliders);
        }

        public List<CelestialObject> HandleCollisions()
        {
            List<CelestialObject> collisions = new List<CelestialObject>();

            // Create a tree from scratch every update.
            if (root == null)
            {
                root = new QuadTree(0, 0, 0, 800, 600); // last 2 parameters hardcoded for now, should be dynamic
            }
            else
            {
                root.Clear();
            }

            // Insert all CelestialObjects into the initialised tree.
            foreach (CelestialObject co in CelestialObjectRepository.Instance.GetCelestialObjectList())
            {
                root.Insert(co);
            }


            _previousColliders = new List<CelestialObject>(_currentColliders);
            _currentColliders = new List<CelestialObject>(root.GetCollisions(collisions));

            Notify();
            return _currentColliders;
        }

        public void Draw(PaintEventArgs e)
        {
            if (root != null)
            {
                root.DrawNode(e);
            }
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
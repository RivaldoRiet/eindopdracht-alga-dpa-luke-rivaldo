using DPA.Components;
using System.Collections.Generic;
using System.Linq;

namespace DPA.Memento
{
	public class CareTaker
	{
		private readonly LinkedList<CelestialObjectListMemento> _mementoList;
		private LinkedListNode<CelestialObjectListMemento> _currentItem;
		private CelestialObjectListMemento _originalCelestialObjects;
		private bool _firstTime;
		public CareTaker()
		{
			_mementoList = new LinkedList<CelestialObjectListMemento>();
			_firstTime = true;
		}

        public void Save(CelestialObjectListMemento memento)
        {
            if (_firstTime)
            {
                _originalCelestialObjects = memento;
                _firstTime = !_firstTime;
            }
            if (_currentItem == null)
            {
                _mementoList.AddFirst(memento);
                _currentItem = _mementoList.First;
            }
            else
            {
                _currentItem = _currentItem.ReplaceNext(memento);
            }
        }

		public CelestialObjectListMemento Undo()
		{
			if (!CanUndo)
			{
				List<CelestialObject> tempList = new List<CelestialObject>();
				tempList = _originalCelestialObjects.CelestialObjects.Select(o => o.copy()).ToList();
				return new CelestialObjectListMemento(tempList);
			}
			else
			{
				_currentItem = _currentItem.Previous;
				return _currentItem.Value;
			}
		}

		public bool CanUndo => _currentItem != null && _currentItem.Previous != null;
	}
}
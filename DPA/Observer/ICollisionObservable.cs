using System.Collections.Generic;

namespace DPA.Observer
{
    public interface ICollisionObservable
    {
        void Subscribe(ICollisionObserver observer);
        void Unsubscribe(ICollisionObserver observer);
        void ClearSubscribers();
        void Notify();
        List<ICollisionObserver> GetObservers();
    }
}

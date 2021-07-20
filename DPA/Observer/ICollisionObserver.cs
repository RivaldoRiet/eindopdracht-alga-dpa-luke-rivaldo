using DPA.Interface;

namespace DPA.Observer
{
    public interface ICollisionObserver
    {
        void UpdateCollisions(ICollisionDetector subject);
    }
}

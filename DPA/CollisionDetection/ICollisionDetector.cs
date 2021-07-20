using DPA.Components;
using DPA.Observer;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DPA.Interface
{
    public interface ICollisionDetector : ICollisionObservable
    {
        List<CelestialObject> HandleCollisions();
        void Draw(PaintEventArgs e);
        List<CelestialObject> GetPreviousColliders();
        List<CelestialObject> GetCurrentColliders();

        string GetIdentifier();
    }
}
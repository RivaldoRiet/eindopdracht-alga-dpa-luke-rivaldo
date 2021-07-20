using DPA.FileManagement;

namespace DPA.Factory
{
    internal interface ICelestialObjectFactory
    {
        void Make(CelestialObjectData celestialObjectData);
    }
}

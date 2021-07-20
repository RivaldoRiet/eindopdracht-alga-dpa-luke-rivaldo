using DPA.FileManagement;
using System.Collections.Generic;
using System.IO;

namespace DPA.Interface
{
    public interface ICelestialObjectFilePersistence
    {
        List<CelestialObjectData> Load(Stream file);
    }
}
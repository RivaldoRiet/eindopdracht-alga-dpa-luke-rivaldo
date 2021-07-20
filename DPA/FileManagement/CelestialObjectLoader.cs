using DPA.FileManagement;
using DPA.Interface;
using System.IO;
using System.Net;

namespace DPA.Factory
{
    public class CelestialObjectLoader
    {
        private readonly CelestialObjectXML celestialObjectXml = new CelestialObjectXML();
        private readonly CelestialObjectCSV celestialObjectCsv = new CelestialObjectCSV();
        private readonly CelestialObjectFactory celestialObjectFactory = new CelestialObjectFactory();
        private readonly string file;
        private readonly bool isXml;
        private readonly bool isWebFile;
        public CelestialObjectLoader(string file, bool isXml, bool isWebFile)
        {
            this.file = file;
            this.isXml = isXml;
            this.isWebFile = isWebFile;
        }

        public virtual void CelestialObjectFile(ICelestialObjectFilePersistence celestialObjectPersistence, Stream file)
        {
            System.Collections.Generic.List<CelestialObjectData> celestialObjectData = celestialObjectPersistence.Load(file);
            celestialObjectFactory.MakeCelestialObjects(celestialObjectData);
        }

        public bool LoadFile()
        {
            if (!string.IsNullOrEmpty(file))
            {
                Stream fileStream;
                if (isXml)
                {
                    if (isWebFile)
                    {
                        fileStream = LoadWebFile(file);
                        if (fileStream != null)
                        {
                            CelestialObjectFile(celestialObjectXml, fileStream);
                            return true;
                        }
                    }
                    else
                    {
                        fileStream = loadLocalFile(file);
                        if (fileStream != null)
                        {
                            CelestialObjectFile(celestialObjectXml, fileStream);
                            return true;
                        }
                    }
                }
                else
                {
                    if (isWebFile)
                    {
                        fileStream = LoadWebFile(file);
                        if (fileStream != null)
                        {
                            CelestialObjectFile(celestialObjectCsv, fileStream);
                            return true;
                        }
                    }
                    else
                    {
                        fileStream = loadLocalFile(file);
                        if (fileStream != null)
                        {
                            CelestialObjectFile(celestialObjectCsv, fileStream);
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private Stream LoadWebFile(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            return resp.GetResponseStream();
        }

        private Stream loadLocalFile(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            return fs;
        }
    }
}
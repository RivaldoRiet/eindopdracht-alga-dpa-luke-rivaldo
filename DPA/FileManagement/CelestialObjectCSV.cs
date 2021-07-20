using DPA.Components;
using DPA.Enum;
using DPA.Interface;
using DPA.State;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace DPA.FileManagement
{
    public class CelestialObjectCSV : ICelestialObjectFilePersistence
    {
        private List<CelestialObject> _celestialObjectList = new List<CelestialObject>();
        private readonly List<CelestialObjectData> celestialObjectData = new List<CelestialObjectData>();
        public List<CelestialObject> CelestialObjectList
        {
            get => _celestialObjectList;
            set => _celestialObjectList = value;
        }


        public List<CelestialObjectData> Load(Stream file)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                int counter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    Regex csvParser = new Regex(";(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    string[] fields = csvParser.Split(line);
                    if (counter > 0) // want de eerste regel bevat de headers
                    {
                        CelestialObjectType type = !string.IsNullOrEmpty(fields[1]) ? (CelestialObjectType)System.Enum.Parse(typeof(CelestialObjectType), fields[1].ToUpper()) : CelestialObjectType.UNDEFINED;
                        if (type != CelestialObjectType.UNDEFINED)
                        {
                            string name = "N/A";
                            if (type == CelestialObjectType.PLANET)
                            {
                                name = !string.IsNullOrEmpty(fields[0]) ? fields[0] : "N/A";
                            }
                            float x = !string.IsNullOrEmpty(fields[2]) ? float.Parse(fields[2]) : 0f;
                            float y = !string.IsNullOrEmpty(fields[3]) ? float.Parse(fields[3]) : 0f;
                            double vx = !string.IsNullOrEmpty(fields[4]) ? (double)decimal.Parse(fields[4], CultureInfo.InvariantCulture) : 0;
                            double vy = !string.IsNullOrEmpty(fields[5]) ? (double)decimal.Parse(fields[5], CultureInfo.InvariantCulture) : 0;
                            string[] neighbours = !string.IsNullOrEmpty(fields[6]) ? fields[6].Split(',') : new string[0];
                            int radius = !string.IsNullOrEmpty(fields[7]) ? int.Parse(fields[7]) : 0;
                            string colorString = !string.IsNullOrEmpty(fields[8]) ? fields[8] : "black";
                            if (colorString.ToLower() == "grey")
                            {
                                colorString = "gray";
                            }

                            Color color = Color.FromName(colorString) != null ? Color.FromName(colorString) : Color.Black;
                            OnCollisionEffects onCollisionEffects = !string.IsNullOrEmpty(fields[9]) ? (OnCollisionEffects)System.Enum.Parse(typeof(OnCollisionEffects), fields[9].ToUpper()) : OnCollisionEffects.BOUNCE;

                            CelestialObjectData celestialObject = new CelestialObjectData
                            {
                                name = name,
                                x = x,
                                y = y,
                                radius = radius,
                                neighbours = neighbours,
                                effectState = OnCollisionEffectsToEffectState(onCollisionEffects, color),
                                vx = vx,
                                vy = vy,
                                type = type,
                                color = color
                            };
                            celestialObjectData.Add(celestialObject);
                        }
                    }

                    counter++;
                }
            }
            return celestialObjectData;
        }
        private EffectState OnCollisionEffectsToEffectState(OnCollisionEffects onCollision, Color color)
        {
            switch (onCollision)
            {
                case OnCollisionEffects.BLINK:
                    return new BlinkEffect(color);
                case OnCollisionEffects.BOUNCE:
                    return new BounceEffect(false);
                case OnCollisionEffects.DISAPPEAR:
                    return new DisappearEffect();
                case OnCollisionEffects.EXPLODE:
                    return new ExplodeEffect();
                case OnCollisionEffects.GROW:
                    return new GrowEffect();
                default:
                    return null;
            }
        }
    }
}
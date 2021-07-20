using DPA.Components;
using DPA.Enum;
using DPA.Interface;
using DPA.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Xml;

namespace DPA.FileManagement
{
    public class CelestialObjectXML : ICelestialObjectFilePersistence
    {
        private readonly List<CelestialObject> _celestialObjectList = new List<CelestialObject>();
        private readonly List<CelestialObjectData> celestialObjectData = new List<CelestialObjectData>();
        public List<CelestialObjectData> Load(Stream file)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(file);

            XmlNode xnRoot = xml.SelectSingleNode("/galaxy");
            int n = 0;
            if (xnRoot.HasChildNodes)
            {
                XmlNode xn = xnRoot.FirstChild;

                while (true)
                {
                    if (n > 0)
                    {
                        xn = xn.NextSibling;
                    }

                    if (xn.HasChildNodes)
                    {
                        CelestialObjectType type = (CelestialObjectType)System.Enum.Parse(typeof(CelestialObjectType), xn.Name.ToUpper());
                        string name = !XNIsNullOrEmptyInnerText(xn["name"]) ? xn["name"].InnerText : "N/A";
                        XmlNode positionNode = xn["position"];
                        XmlNode speedNode = xn["speed"];
                        float x = 0f;
                        float y = 0f;
                        int radius = 1;
                        double vx = 0;
                        double vy = 0;
                        if (positionNode != null)
                        {
                            x = !XNIsNullOrEmptyInnerText(positionNode["x"]) ? float.Parse(positionNode["x"].InnerText) : 0f;
                            y = !XNIsNullOrEmptyInnerText(positionNode["y"]) ? float.Parse(positionNode["y"].InnerText) : 0f;
                            radius = !XNIsNullOrEmptyInnerText(positionNode["radius"]) ? Convert.ToInt32(float.Parse(positionNode["radius"].InnerText)) : 1;
                        }
                        if (speedNode != null)
                        {
                            vx = !XNIsNullOrEmptyInnerText(speedNode["x"]) ? double.Parse(speedNode["x"].InnerText, CultureInfo.InvariantCulture) : 0;
                            vy = !XNIsNullOrEmptyInnerText(speedNode["y"]) ? double.Parse(speedNode["y"].InnerText, CultureInfo.InvariantCulture) : 0;
                        }

                        List<string> neighbours = new List<string>();
                        if (xn["neighbours"] != null && xn["neighbours"].HasChildNodes)
                        {
                            foreach (XmlNode neighbour in xn["neighbours"])
                            {
                                if (!XNIsNullOrEmptyInnerText(neighbour))
                                {
                                    neighbours.Add(neighbour.InnerText);
                                }
                            }
                        }

                        string colorString = !XNIsNullOrEmptyInnerText(xn["color"]) ? xn["color"].InnerText : "black";
                        if (colorString.ToLower() == "grey")
                        {
                            colorString = "gray";
                        }

                        Color color = Color.FromName(colorString) != null ? Color.FromName(colorString) : Color.Black;
                        OnCollisionEffects onCollisionEffects = !XNIsNullOrEmptyInnerText(xn["oncollision"]) ?
                            (OnCollisionEffects)System.Enum.Parse(typeof(OnCollisionEffects), xn["oncollision"].InnerText.ToUpper()) : OnCollisionEffects.BLINK;

                        CelestialObjectData celestialObject = new CelestialObjectData
                        {
                            name = name,
                            x = x,
                            y = y,
                            radius = radius,
                            neighbours = neighbours.ToArray(),
                            effectState = OnCollisionEffectsToEffectState(onCollisionEffects, color),
                            vx = vx,
                            vy = vy,
                            type = type,
                            color = color
                        };
                        celestialObjectData.Add(celestialObject);
                    }

                    if (xn == xnRoot.LastChild)
                    {
                        break;
                    }
                    else
                    {
                        n++;
                    }
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

        private bool XNIsNullOrEmptyInnerText(XmlNode xn)
        {
            return xn == null || string.IsNullOrEmpty(xn.InnerText);
        }
    }
}
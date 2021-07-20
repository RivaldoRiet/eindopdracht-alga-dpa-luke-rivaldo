using System;
using System.Collections.Generic;
using DPA.CollisionDetection;
using DPA.Components;
using DPA.Enum;
using DPA.Factory;
using DPA.FileManagement;
using DPA.Memento;
using DPA.Repository;
using DPA.State;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DPA_UnitTesting
{
    [TestClass]
    public class DPA_Tests
    {
        [TestMethod]
        public void AddCelestialObject()
        {
            var list = CelestialObjectRepository.Instance.GetCelestialObjectList();
            CelestialObjectRepository.Instance.AddCelestialObject(new Planet());
            int count = CelestialObjectRepository.Instance.GetCelestialObjectList().Count;
            Assert.IsTrue(count == 1);
        }

        [TestMethod]
        public void BadFileScenario()
        {
            CelestialObjectLoader _celestialObjectFactory = new CelestialObjectLoader("", true, false);
            bool fileLoaded = _celestialObjectFactory.LoadFile();
            Assert.IsFalse(fileLoaded);
        }
        [TestMethod]
        public void AddFactoryObject()
        {
            CelestialObjectFactory celestialObjectFactory = new CelestialObjectFactory();
            CelestialObjectData celestialObjectData = new CelestialObjectData();
            celestialObjectData.type = CelestialObjectType.PLANET;
            EffectState effectState = new BounceEffect(false);
            celestialObjectData.effectState = effectState;
            List<CelestialObjectData> dataList = new List<CelestialObjectData>();
            dataList.Add(celestialObjectData);
            celestialObjectFactory.MakeCelestialObjects(dataList);
            int count = CelestialObjectRepository.Instance.GetCelestialObjectList().Count;
            Assert.IsTrue(count == 1);
        }

        [TestMethod]
        public void TestMomentoSave()
        {
            CareTaker careTaker = new CareTaker();
            List<CelestialObject> celestialObjects = new List<CelestialObject>();
            celestialObjects.Add(new Asteroid());
            celestialObjects.Add(new Planet());
            CelestialObjectListMemento momento = new CelestialObjectListMemento(celestialObjects);
            careTaker.Save(momento);
            CelestialObjectListMemento momento1 = new CelestialObjectListMemento(celestialObjects);
            careTaker.Save(momento1);
            Assert.IsTrue(careTaker.CanUndo);
        }

        [TestMethod]
        public void TestMomentoUndo()
        {
            CareTaker careTaker = new CareTaker();
            List<CelestialObject> celestialObjects = new List<CelestialObject>();
            celestialObjects.Add(new Asteroid());
            celestialObjects.Add(new Planet());
            CelestialObjectListMemento momento = new CelestialObjectListMemento(celestialObjects);
            celestialObjects.Add(new Asteroid());
            CelestialObjectListMemento momento1 = new CelestialObjectListMemento(celestialObjects);
            careTaker.Save(momento);
            careTaker.Save(momento1);
            careTaker.Save(momento);


            Assert.IsTrue(momento1.CelestialObjects.Equals(careTaker.Undo().CelestialObjects));
        }
    }



}

using DPA.CollisionDetection;
using DPA.Components;
using DPA.Factory;
using DPA.Memento;
using DPA.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DPA.Controller
{
	public class GameHandler
	{
		private CelestialObjectLoader _celestialObjectFactory;
		private int _tickCounter = 0;

		public GameHandler()
		{
			SimulationRepository.Instance.SetDrawCollisionDebug(true);
			SimulationRepository.Instance.SetCollisionDetector(new QuadTreeDetector());
			SimulationRepository.Instance.SetCareTaker(new CareTaker());
			SimulationRepository.Instance.bfsActive = false;
			SimulationRepository.Instance.dijkstraActive = false;
		}

		public bool Initialize(string file, bool isXml, bool isWebFile)
		{
			_celestialObjectFactory = new CelestialObjectLoader(file, isXml, isWebFile);
			if (_celestialObjectFactory.LoadFile())
			{
				List<CelestialObject> tempList = new List<CelestialObject>();
				tempList = CelestialObjectRepository.Instance.GetCelestialObjectList().Select(o => o.copy())
					.ToList();

				//hierin willen we een momento maken om de originele staat van de objecten te bewaren
				SimulationRepository.Instance.GetCareTaker().Save(new CelestialObjectListMemento(tempList));
				return true;
			}
			return false;
		}

		public void Undo()
		{
			if (SimulationRepository.Instance.IsRunning())
			{
				//zet de huidige lijst van objecten naar de lijst van de undo
				CelestialObjectRepository.Instance.SetCelestialObjectList(SimulationRepository.Instance.GetCareTaker().Undo().CelestialObjects);
			}
		}

		public void MoveObjects(int ticks)
		{
			List<CelestialObject> toDestroy = new List<CelestialObject>();
			foreach (CelestialObject co in CelestialObjectRepository.Instance.GetCelestialObjectList())
			{
				co.Move();
			}

			UpdateCollisionSubscribers();
			SimulationRepository.Instance.GetCollisionDetector().HandleCollisions();

			//als er 100 ticks geweest zijn dan is het mogelijk voor de user om de simulatie 5 seconde terug te zetten want 50 ms * 100 = 5 seconde
			_tickCounter++;
			if (_tickCounter >= ticks)
			{
				List<CelestialObject> tempList = new List<CelestialObject>();
				tempList = CelestialObjectRepository.Instance.GetCelestialObjectList().Select(o => o.copy()).ToList();

				//hierin willen we een momento maken
				SimulationRepository.Instance.GetCareTaker().Save(new CelestialObjectListMemento(tempList));
				_tickCounter = 0;
			}
		}

		public void Paint(PaintEventArgs e)
		{
			if (SimulationRepository.Instance.IsRunning())
			{
				DrawCelestialObjects(e, CelestialObjectRepository.Instance.GetCelestialObjectList());

				if (SimulationRepository.Instance.GetDrawCollisionDebug())
				{
					SimulationRepository.Instance.GetCollisionDetector().Draw(e);
				}

				if (SimulationRepository.Instance.dijkstraActive)
				{
					Dijkstra.Dijkstra algorithm_dijsktra = new Dijkstra.Dijkstra();
					algorithm_dijsktra.DoDijkstra(e);
				}

				if (SimulationRepository.Instance.bfsActive)
				{
					BFS.BFS algorithm_bfs = new BFS.BFS();
					algorithm_bfs.DoBreadthFirstSearch(e);
				}
			}
		}

		private void DrawCelestialObjects(PaintEventArgs e, List<CelestialObject> celestialObjectList)
		{
			foreach (CelestialObject co in celestialObjectList)
			{
				co.Draw(e);
			}
		}

		private void UpdateCollisionSubscribers()
		{
			foreach (CelestialObject co in CelestialObjectRepository.Instance.GetToUnsubscribeList())
			{
				SimulationRepository.Instance.GetCollisionDetector().Subscribe(co);
			}

			foreach (CelestialObject co in CelestialObjectRepository.Instance.GetToSubscribeList())
			{
				SimulationRepository.Instance.GetCollisionDetector().Subscribe(co);
			}
		}
	}
}
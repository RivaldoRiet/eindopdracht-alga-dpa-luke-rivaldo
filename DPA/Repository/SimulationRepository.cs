using DPA.Controller;
using DPA.Interface;
using DPA.Memento;

namespace DPA.Repository
{
    public class SimulationRepository
    {
        private static readonly SimulationRepository _instance = new SimulationRepository();
        private bool _isRunning;
        private int _tickTime = 50;
        private bool _drawCollisionDebug;
        private ICollisionDetector _collisionDetector;
        private CareTaker _caretaker;
        public bool dijkstraActive { get; set; }
        public bool bfsActive { get; set; }
        public string BreadthFirstSearchData { get; set; }
        public string DijkstraData { get; set; }
        public GameHandler GameHandler { get; set; }
        public static SimulationRepository Instance => _instance;

        static SimulationRepository()
        {

        }

        public void SetCollisionDetector(ICollisionDetector collisionDetector)
        {
            _collisionDetector = collisionDetector;
        }

        public ICollisionDetector GetCollisionDetector()
        {
            return _collisionDetector;
        }

        public void SetCareTaker(CareTaker caretaker)
        {
            _caretaker = caretaker;
        }

        public CareTaker GetCareTaker()
        {
            return _caretaker;
        }

        public bool GetDrawCollisionDebug()
        {
            return _drawCollisionDebug;
        }

        public void SetDrawCollisionDebug(bool collisionDebug)
        {
            _drawCollisionDebug = collisionDebug;
        }

        public bool IsRunning()
        {
            return _isRunning;
        }

        public void SetIsRunning(bool isRunning)
        {
            _isRunning = isRunning;
        }

        public int GetTickTime()
        {
            return _tickTime;
        }

        public void SetTickTime(int time)
        {
            _tickTime = time;
        }
    }
}

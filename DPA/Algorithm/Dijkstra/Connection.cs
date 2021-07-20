namespace DPA.Dijkstra
{
    public class Connection
    {
        private Location _a, _b;
        private int _weight;
        private bool selected = false;

        public bool Selected
        {
            get => selected;
            set => selected = value;
        }

        public Connection(Location a, Location b, int weight)
        {
            _a = a;
            _b = b;
            _weight = weight;
        }
        public Location B
        {
            get => _b;
            set => _b = value;
        }

        public Location A
        {
            get => _a;
            set => _a = value;
        }

        public int Weight
        {
            get => _weight;
            set => _weight = value;
        }


    }
}

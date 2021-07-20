using System.Collections.Generic;

namespace DPA.Dijkstra
{
    public class Route
    {
        private int _cost;
        private List<Connection> _connections;
        private readonly string _identifier;

        public Route(string _identifier)
        {
            _cost = int.MaxValue;
            _connections = new List<Connection>();
            this._identifier = _identifier;
        }


        public List<Connection> Connections
        {
            get => _connections;
            set => _connections = value;
        }
        public int Cost
        {
            get => _cost;
            set => _cost = value;
        }

        public override string ToString()
        {
            return "Id:" + _identifier + " Cost:" + Cost;
        }
    }
}

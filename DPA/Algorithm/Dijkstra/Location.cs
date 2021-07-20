namespace DPA.Dijkstra
{
    public class Location
    {
        private string _identifier;
        public Location()
        {

        }
        public string Identifier
        {
            get => _identifier;
            set => _identifier = value;
        }
        public override string ToString()
        {
            return _identifier;
        }
    }
}

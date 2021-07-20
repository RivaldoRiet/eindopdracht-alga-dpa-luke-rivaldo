using DPA.Components;
using DPA.Enum;
using DPA.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DPA.Dijkstra
{
    public class Dijkstra
    {
        private readonly List<CelestialObject> celestialObjects = CelestialObjectRepository.Instance.GetCelestialObjectList();
        private readonly StringBuilder _bfsAlgData = new StringBuilder();
        private List<Connection> _connections;
        private List<Location> _locations;
        public List<Location> Locations
        {
            get => _locations;
            set => _locations = value;
        }
        public List<Connection> Connections
        {
            get => _connections;
            set => _connections = value;
        }

        public Dijkstra()
        {
            _connections = new List<Connection>();
            _locations = new List<Location>();
        }

        public CelestialObject GetLargestCelestialObject()
        {
            List<CelestialObject> planetList = celestialObjects.FindAll(c => c.Type == CelestialObjectType.PLANET);

            if (planetList.Count >= 1)
            {
                return planetList.OrderByDescending(c => c.Radius).First();
            }

            return null;
        }

        public CelestialObject GetSecondLargestCelestialObject()
        {
            List<CelestialObject> planetList = celestialObjects.FindAll(c => c.Type == CelestialObjectType.PLANET);

            if (planetList.Count >= 2)
            {
                return planetList.OrderByDescending(c => c.Radius).ElementAt(1);
            }

            return null;
        }

        public Location GetFirstLocation()
        {
            return _locations.First();
        }

        public List<Route> CalculateMinCost(string _startLocation, string _endLocation)
        {
            //Initialise a new empty route list
            Dictionary<string, Route> _shortestPaths = new Dictionary<string, Route>();
            //Initialise a new empty handled locations list
            List<string> _handledLocations = new List<string>();
            List<Route> shortestRoutes = new List<Route>();
            //Initialise the new routes. the constructor will set the route weight to int.max
            foreach (Location location in _locations)
            {
                _shortestPaths.Add(location.Identifier, new Route(location.Identifier));
            }

            //The startPosition has a weight 0. 
            _shortestPaths[_startLocation].Cost = 0;


            //If all locations are handled, stop the search and return the result
            while (_handledLocations.Count != _locations.Count)
            {
                //Order the locations in respect to their cost
                List<string> _shortestLocations = (from s in _shortestPaths
                                                   orderby s.Value.Cost
                                                   select s.Key).ToList();

                string _locationToProcess = null;

                //Search for the nearest location that isn't handled
                foreach (string _location in _shortestLocations)
                {
                    if (!_handledLocations.Contains(_location))
                    {
                        //If the cost equals int.max, there are no more possible connections to the remaining locations
                        if (_shortestPaths[_location].Cost >= int.MaxValue)
                        {
                            shortestRoutes.Add(_shortestPaths[_endLocation]);
                            return shortestRoutes;
                        }

                        _locationToProcess = _location.ToString();
                        break;
                    }
                }

                //Select all connections where the startposition is the location to Process
                IEnumerable<Connection> selectedConnections = from c in _connections
                                                              where c.A.Identifier.Equals(_locationToProcess)
                                                              select c;

                //Iterate through all connections and search for a connection which is shorter
                foreach (Connection conn in selectedConnections)
                {
                    //if the old route to this point is more expensive then the new route, change this route
                    if (_shortestPaths[conn.B.Identifier].Cost > conn.Weight + _shortestPaths[conn.A.Identifier].Cost)
                    {
                        _shortestPaths[conn.B.Identifier].Connections = _shortestPaths[conn.A.Identifier].Connections.ToList();
                        _shortestPaths[conn.B.Identifier].Connections.Add(conn);
                        //Cost of the full route calculated over the different connections
                        _shortestPaths[conn.B.Identifier].Cost = conn.Weight + _shortestPaths[conn.A.Identifier].Cost;
                        if (conn.B.Identifier.Equals(_endLocation))
                        {
                            shortestRoutes.Add(_shortestPaths[_endLocation]);
                            return shortestRoutes;
                        }
                    }
                    else if (_shortestPaths[conn.B.Identifier].Cost == conn.Weight + _shortestPaths[conn.A.Identifier].Cost)
                    {
                        if (conn.B.Identifier.Equals(_endLocation))
                        {
                            shortestRoutes.Add(_shortestPaths[_endLocation]);
                        }
                    }
                }
                //Add the location to the list of processed locations
                _handledLocations.Add(_locationToProcess);
            }


            shortestRoutes.Add(_shortestPaths[_endLocation]);
            return shortestRoutes;
        }

        private double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
        }

        public void DoDijkstra(PaintEventArgs e)
        {
            //iterate through planets and make a new location for each of them
            foreach (CelestialObject celestialObject in celestialObjects)
            {
                if (celestialObject.Type == CelestialObjectType.PLANET)
                {
                    Planet planet = (Planet)celestialObject;
                    Location temp = new Location
                    {
                        Identifier = planet.Name
                    };
                    Locations.Add(temp);
                }
            }
            //iterate through planets and link each planet to its neighbours
            foreach (CelestialObject celestialObject in celestialObjects)
            {
                if (celestialObject.Type == CelestialObjectType.PLANET)
                {
                    Planet planet = (Planet)celestialObject;
                    foreach (string neighbour in planet.Neighbours)
                    {

                        Planet neighbourPlanet = CelestialObjectRepository.Instance.GetPlanetByName(neighbour);
                        int dist = (int)GetDistance(planet.CoordX, planet.CoordY, neighbourPlanet.CoordX, neighbourPlanet.CoordY);
                        Location temp = new Location
                        {
                            Identifier = planet.Name
                        };
                        Location temp1 = new Location
                        {
                            Identifier = neighbourPlanet.Name
                        };
                        Connections.Add(new Connection(temp, temp1, dist));
                    }
                }
            }


            Planet startPlanet = (Planet)GetLargestCelestialObject();
            Planet endPlanet = (Planet)GetSecondLargestCelestialObject();
            if (startPlanet != null && endPlanet != null)
            {
                _bfsAlgData.Clear();
                //returns the shortest routes between the start and end planet, returning the cost and the different planets it has to go to
                List<Route> shortestRoutes = CalculateMinCost(startPlanet.Name, endPlanet.Name);

                foreach (Route shortestPath in shortestRoutes)
                {
                    Debug.WriteLine("Shortest path from " + startPlanet.Name + " to " + endPlanet.Name + " equals " +
                                    shortestPath.Cost);
                    _bfsAlgData.AppendLine("Shortest path from " + startPlanet.Name + " to " + endPlanet.Name +
                                           " equals " + shortestPath.Cost);
                    Pen mypen = new Pen(Color.Chartreuse, 2);

                    //draw a line between all planets that are part of the route
                    foreach (Connection planetName in shortestPath.Connections)
                    {
                        Debug.WriteLine("From planet: " + planetName.A.Identifier + " to planet " +
                                        planetName.B.Identifier + " weight: " + planetName.Weight);
                        _bfsAlgData.AppendLine("From planet: " + planetName.A.Identifier + " to planet " +
                                               planetName.B.Identifier + " weight: " + planetName.Weight);
                        Planet planetFrom = CelestialObjectRepository.Instance.GetPlanetByName(planetName.A.Identifier);
                        Planet planetTo = CelestialObjectRepository.Instance.GetPlanetByName(planetName.B.Identifier);
                        int planetFromOffset = (planetFrom.Radius / 2);
                        int planetToOffset = (planetTo.Radius / 2);
                        e.Graphics.DrawLine(mypen, planetFrom.CoordX + planetFromOffset,
                            planetFrom.CoordY + planetFromOffset, planetTo.CoordX + planetToOffset,
                            planetTo.CoordY + planetToOffset);

                    }

                    Pen mypen1 = new Pen(Color.Cyan, 2);
                    e.Graphics.DrawEllipse(mypen1, startPlanet.CoordX, startPlanet.CoordY, startPlanet.Radius,
                        startPlanet.Radius);
                    e.Graphics.DrawEllipse(mypen1, endPlanet.CoordX, endPlanet.CoordY, endPlanet.Radius,
                        endPlanet.Radius);
                    SimulationRepository.Instance.DijkstraData = _bfsAlgData.ToString();
                }
            }
        }
    }
}

using DPA.Components;
using DPA.Enum;
using DPA.Repository;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DPA.BFS
{
    public class BFS
    {
        private Dictionary<string, HashSet<string>> _edgeDictionary { get; }

        private readonly List<CelestialObject> _celestialObjects = CelestialObjectRepository.Instance.GetCelestialObjectList();
        private readonly StringBuilder _bfsAlgData = new StringBuilder();
        public BFS()
        {
            _edgeDictionary = new Dictionary<string, HashSet<string>>();
        }

        public CelestialObject GetLargestCelestialObject()
        {
            List<CelestialObject> planetList = _celestialObjects.FindAll(c => c.Type == CelestialObjectType.PLANET);

            if (planetList.Count >= 1)
            {
                return planetList.OrderByDescending(c => c.Radius).First();
            }

            return null;
        }

        public CelestialObject GetSecondLargestCelestialObject()
        {
            List<CelestialObject> planetList = _celestialObjects.FindAll(c => c.Type == CelestialObjectType.PLANET);

            if (planetList.Count >= 2)
            {
                return planetList.OrderByDescending(c => c.Radius).ElementAt(1);
            }

            return null;
        }


        public void AddEdge(string source, string target)
        {
            if (_edgeDictionary.ContainsKey(source))
            {
                try
                {
                    _edgeDictionary[source].Add(target);
                }
                catch
                {
                    Debug.WriteLine("This edge already exists: " + source + " to " + target);
                }
            }
            else
            {
                HashSet<string> hs = new HashSet<string>
                {
                    target
                };
                _edgeDictionary.Add(source, hs);
            }
        }

        public void BFSFindNode(string vertex, string lookingFor, PaintEventArgs e)
        {
            _bfsAlgData.Clear();
            _bfsAlgData.AppendLine("Start node: " + vertex);
            List<string> visitList = new List<string>();
            //if the starting node equals the node we are looking for then stop and return 0 steps
            if (vertex.Equals(lookingFor))
            {
                _bfsAlgData.AppendLine("Found it!");
                _bfsAlgData.AppendLine("Steps Took: 0");
                Debug.WriteLine("Found it!");
                Debug.WriteLine("Steps Took: 0");
                return;
            }
            HashSet<string> visited = new HashSet<string>
            {
                // Mark this node as visited
                vertex
            };
            // Queue for BFS
            Queue<string> q = new Queue<string>();
            // Add this node to the queue
            q.Enqueue(vertex);

            int count = 0;

            while (q.Count > 0)
            {
                //Dequeue the topmost node and mark it as such
                string current = q.Dequeue();
                Planet currentPlanet = CelestialObjectRepository.Instance.GetPlanetByName(current);
                if (visitList.Count > 0)
                {
                    Debug.WriteLine("Previous node: " + visitList.Last() + " - current node: " + current);
                    _bfsAlgData.AppendLine("Previous node: " + visitList.Last() + " - current node: " + current);
                    Pen myPen = new Pen(Color.Blue, 2);

                    Planet prevPlanet = CelestialObjectRepository.Instance.GetPlanetByName(visitList.Last());
                    int planetOffset = (currentPlanet.Radius / 2);
                    int previousPlanetOffset = (prevPlanet.Radius / 2);
                    e.Graphics.DrawLine(myPen, currentPlanet.CoordX + planetOffset, currentPlanet.CoordY + planetOffset, prevPlanet.CoordX + previousPlanetOffset, prevPlanet.CoordY + previousPlanetOffset);
                }
                //If our current node equals the node we were looking for then print steps
                if (current.Equals(lookingFor))
                {
                    Debug.WriteLine("Found it!");
                    Debug.WriteLine("Steps Took: " + count);
                    _bfsAlgData.AppendLine("Found it!");
                    _bfsAlgData.AppendLine("Steps Took: " + count + "  to end node " + lookingFor);
                    visitList.Add(current);
                    return;
                }

                // Only if the node has neighbours to visit
                if (_edgeDictionary.ContainsKey(current))
                {
                    Pen myPlanetPen = new Pen(Color.LightGreen, 3);
                    // Iterate through UNVISITED nodes and add them to the queue
                    foreach (string neighbour in _edgeDictionary[current].Where(a => !visited.Contains(a)))
                    {
                        Planet neighPlanet = CelestialObjectRepository.Instance.GetPlanetByName(neighbour);
                        e.Graphics.DrawEllipse(myPlanetPen, currentPlanet.CoordX - currentPlanet.Radius / 2, currentPlanet.CoordY - currentPlanet.Radius / 2, currentPlanet.Radius * 2, currentPlanet.Radius * 2);
                        e.Graphics.DrawEllipse(myPlanetPen, neighPlanet.CoordX - neighPlanet.Radius / 2, neighPlanet.CoordY - neighPlanet.Radius / 2, neighPlanet.Radius * 2, neighPlanet.Radius * 2);
                        visited.Add(neighbour);
                        q.Enqueue(neighbour);
                    }
                }
                //if the current doesn't equal our starting point add it to where we've been
                if (!current.Equals(vertex))
                {
                    visitList.Add(current);
                }
                count++;
            }
            //iterated through nodes and haven't found what were looking for
            Debug.WriteLine("Could not find node!");
            _bfsAlgData.AppendLine("Could not find node!");
            return;
        }

        public void DoBreadthFirstSearch(PaintEventArgs e)
        {
            //add all planets and their neighbours to our dictionary
            foreach (CelestialObject celestialObject in _celestialObjects)
            {
                if (celestialObject.Type == CelestialObjectType.PLANET)
                {
                    Planet planet = (Planet)celestialObject;
                    foreach (string neighbour in planet.Neighbours)
                    {
                        AddEdge(planet.Name, neighbour);
                    }
                }
            }

            Planet largest = (Planet)GetLargestCelestialObject();
            Planet secondLargest = (Planet)GetSecondLargestCelestialObject();

            if (largest != null && secondLargest != null)
            {
                BFSFindNode(largest.Name, secondLargest.Name, e);
            }

            SimulationRepository.Instance.BreadthFirstSearchData = _bfsAlgData.ToString();
        }
    }
}

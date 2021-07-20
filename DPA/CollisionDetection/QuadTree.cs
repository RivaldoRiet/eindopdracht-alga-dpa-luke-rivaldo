using DPA.Components;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DPA.CollisionDetection
{
    internal class QuadTree
    {
        private static readonly int MAX_ENTITIES = 4;
        private static readonly int MAX_LEVELS = 4;
        private static readonly int BOUNDARY_WIDTH = 2;
        private static readonly Color BOUNDARY_COLOR = Color.Red;
        private readonly int _level = 0;
        private readonly Rectangle _bounds;
        private readonly List<CelestialObject> _entityList;
        private readonly List<QuadTree> _leafs;

        public QuadTree(int _level, int xPos, int yPos, int width, int height)
        {
            this._level = _level;
            _bounds = new Rectangle(xPos, yPos, width, height);
            _entityList = new List<CelestialObject>();
            _leafs = new List<QuadTree>();
        }

        // Clears the entire tree of leafs and celestialobjects recursively.
        public void Clear()
        {
            foreach (QuadTree leaf in _leafs)
            {
                leaf.Clear();
            }

            _entityList.Clear();
            _leafs.Clear();
        }

        // Splits a leaf (or root of) a QuadTree in 4 more leafs.
        private void Split()
        {
            int width = _bounds.Width / 2;
            int height = _bounds.Height / 2;
            int xPos = _bounds.X;
            int yPos = _bounds.Y;

            _leafs.Add(new QuadTree(_level + 1, xPos, yPos, width, height));
            _leafs.Add(new QuadTree(_level + 1, xPos + width, yPos, width, height));
            _leafs.Add(new QuadTree(_level + 1, xPos, yPos + height, width, height));
            _leafs.Add(new QuadTree(_level + 1, xPos + width, yPos + height, width, height));
        }

        // Recursively inserts an Celestial Object into the deepest nodes it fits into and all the nodes it's passed through to get there.
        public void Insert(CelestialObject co)
        {
            // Add the entity to the list in every leaf it's gone through before being inserted so that it remains possible to check collisions on edges of a QuadTree.
            _entityList.Add(co);

            if (_entityList.Count >= MAX_ENTITIES)
            {
                // Split the current leaf if the conditions are right.
                if (_leafs.Count == 0 && _level <= MAX_LEVELS)
                {
                    Split();
                }

                // Insert the CelestialObject into the correct leaf(s) recursively.
                foreach (QuadTree tree in _leafs)
                {
                    foreach (CelestialObject entity in _entityList)
                    {
                        if (!tree._entityList.Contains(entity) && tree._bounds.IntersectsWith(new Rectangle((int)entity.CoordX, (int)entity.CoordY, entity.Radius, entity.Radius)))
                        {
                            tree.Insert(entity);
                        }
                    }
                }
            }
        }

        // Navigates to the deepest node (leaf) recursively and does circle collision detection between it's CelestialObjects.
        public List<CelestialObject> GetCollisions(List<CelestialObject> collisions)
        {
            // Only check collisions within the deepest nodes.
            if (_leafs.Count == 0)
            {
                // Check collisions between all objects in the current leaf.
                foreach (CelestialObject co1 in _entityList)
                {
                    foreach (CelestialObject co2 in _entityList)
                    {
                        if (co1 != co2 && !collisions.Contains(co1))
                        {
                            // Calculation to check if two circles overlap.
                            float co1CenterX = co1.CoordX + co1.Radius;
                            float co2CenterX = co2.CoordX + co2.Radius;
                            float co1CenterY = co1.CoordY + co1.Radius;
                            float co2CenterY = co2.CoordY + co2.Radius;

                            int radius = co1.Radius + co2.Radius;
                            float deltaX = co1CenterX - co2CenterX;
                            float deltaY = co1CenterY - co2CenterY;
                            if ((deltaX * deltaX) + (deltaY * deltaY) <= radius * radius)
                            {
                                collisions.Add(co1);
                            }
                        }
                    }
                }
            }
            else
            {
                // Navigate to the deepest node recursively.
                foreach (QuadTree leaf in _leafs)
                {
                    leaf.GetCollisions(collisions);
                }
            }

            return collisions;
        }


        // Draw the boundaries of each deepest node recusively.
        public void DrawNode(PaintEventArgs e)
        {
            // Navigate to the deepest node recursively
            if (_leafs.Count != 0)
            {
                foreach (QuadTree leaf in _leafs)
                {
                    leaf.DrawNode(e);
                }
            }

            // Draw
            Pen pen = new Pen(BOUNDARY_COLOR, BOUNDARY_WIDTH);

            e.Graphics.DrawLine(pen, _bounds.X, _bounds.Y, _bounds.X + _bounds.Width, _bounds.Y);
            e.Graphics.DrawLine(pen, _bounds.X, _bounds.Y + _bounds.Height, _bounds.X + _bounds.Width, _bounds.Y + _bounds.Height);
            e.Graphics.DrawLine(pen, _bounds.X, _bounds.Y, _bounds.X, _bounds.Y + _bounds.Height);
            e.Graphics.DrawLine(pen, _bounds.X + _bounds.Width, _bounds.Y, _bounds.X + _bounds.Width, _bounds.Y + _bounds.Height);
        }
    }
}

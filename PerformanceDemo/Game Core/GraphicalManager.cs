using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceDemo.Utilities;

namespace PerformanceDemo.Game_Core
{
    public class GraphicalManager
    {
        protected List<IGraphicalItem> graphicalItems;

        public event Action<IGraphicalItem, IGraphicalItem> Collided;

        public GraphicalManager()
        {
            graphicalItems = new List<IGraphicalItem>();;
        }

        public List<IGraphicalItem> GraphicalItems => graphicalItems;

        public int Count => graphicalItems.Count;

        public void AddItem(IGraphicalItem item)
        {
            graphicalItems.Add(item);
        }

        public void RemoveItem(IGraphicalItem item)
        {
            graphicalItems.Remove(item);
        }

        public void Clear()
        {
            graphicalItems.Clear();
        }

        public IGraphicalItem FindItem(Vector2 location)
        {
            IGraphicalItem foundItem = null;

            foreach (IGraphicalItem curItem in graphicalItems)
            {
                if (curItem.Contains(location))
                {
                    foundItem = curItem;
                    break;
                }
            }

            return foundItem;
        }

        public virtual void Update(WorldParameters parameters)
        {
            foreach (IGraphicalItem curItem in graphicalItems)
            {
                curItem.Update(parameters);
            }
        }

        public void Draw(Graphics graphics)
        {
            foreach (IGraphicalItem curItem in graphicalItems)
            {
                curItem.Draw(graphics);
            }
        }

        public void CheckCollisions(GraphicalManager otherGraphicalManager)
        {
            List<IGraphicalItem> myItemsToCollide = new List<IGraphicalItem>();
            List<IGraphicalItem> otherItemsToCollide = new List<IGraphicalItem>();

            foreach (IGraphicalItem curItem in GraphicalItems)
            {
                Rectangle myRect = curItem.CalculateBoundingBox();
                foreach (IGraphicalItem otherItem in otherGraphicalManager.GraphicalItems)
                {
                    Rectangle otherRect = otherItem.CalculateBoundingBox();
                    if (myRect.IntersectsWith(otherRect) &&
                        !myItemsToCollide.Contains(curItem) &&
                        !otherItemsToCollide.Contains(otherItem))
                    {
                        myItemsToCollide.Add(curItem);
                        otherItemsToCollide.Add(otherItem);
                    }
                }
            }

            CollideItems(this, myItemsToCollide, otherItemsToCollide);
        }

        public void CollideItems(GraphicalManager graphicalManager, List<IGraphicalItem> graphicalItems, List<IGraphicalItem> otherGraphicalItems)
        {
            foreach (IGraphicalItem curItem in graphicalItems)
            {
                foreach (IGraphicalItem otherItem in otherGraphicalItems)
                {
                    Collided(curItem, otherItem);
                }
            }
        }
    }
}

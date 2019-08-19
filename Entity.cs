using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    class Entity
    {
        private Coordinate position;
        private string display;
        private double lineOfSight;
        private int displayPriority;

        public Entity()
        {
        }

        public Entity(Coordinate position, string display, double lineOfSight, int displayPriority)
        {
            this.position = position;
            this.display = display;
            this.lineOfSight = lineOfSight;
            this.displayPriority = displayPriority;
        }

        public virtual Coordinate GetPosition()
        {
            return position;
        }

        public virtual double GetLineOfSight()
        {
            return lineOfSight;
        }

        public virtual string GetDisplay()
        {
            return display;
        }

        public void MoveEntity(Entity entity, Coordinate destination)
        {
            if (entity.CanMove(destination))
            {
                this.position = destination;
            }
        }
        
        public virtual bool CanMove(Coordinate destination)
        {
            try
            {
                if (Map.Instance.TileAt(destination).IsPathable())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public virtual int getDisplayPriority()
        {
            return displayPriority;
        }
    }
}

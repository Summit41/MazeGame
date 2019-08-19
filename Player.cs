using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    class Player : Entity
    {
        private Coordinate position;
        private string display;
        private double lineOfSight;
        private int displayPriority;

        public Player(Coordinate position, string display, double lineOfSight, int displayPriority)
        {
            this.display = display;
            this.lineOfSight = lineOfSight;
            this.position = position;
            this.displayPriority = displayPriority;
        }

        public void AcceptInput(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
            {
                if (CanMove(position.Offset(0, -1))) {
                    MoveEntity(this, position.Offset(0, -1));
                }
            }
            else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
            {
                if (CanMove(position.Offset(0, 1)))
                {
                    MoveEntity(this, position.Offset(0, 1));
                }
            }
            else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A)
            {
                if (CanMove(position.Offset(-1, 0)))
                {
                    MoveEntity(this, position.Offset(-1, 0));
                }
            }
            else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
            {
                if (CanMove(position.Offset(1, 0)))
                {
                    MoveEntity(this, position.Offset(1, 0));
                }
            }
        }

        public void MoveEntity(Player entity, Coordinate destination)
        {
            if (entity.CanMove(destination))
            {
                this.position = destination;
            }
        }
        
        public override Coordinate GetPosition()
        {
            return this.position;
        }

        public override double GetLineOfSight()
        {
            return this.lineOfSight;
        }

        public override string GetDisplay()
        {
            return this.display;
        }

        public override bool CanMove(Coordinate destination)
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

        public override int getDisplayPriority()
        {
            return displayPriority;
        }
    }
}

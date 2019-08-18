using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneration
{
    class Coordinate
    {
        public int x;
        public int y;

        public Coordinate (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Coordinate compare)
        {
            if (this.x == compare.x && this.y == compare.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Coordinate Offset(int x, int y)
        {
            return new Coordinate(this.x + x, this.y + y);
        }

        public string ToText()
        {
            return "(" + this.x + ", " + this.y + ")";
        }
    }
}

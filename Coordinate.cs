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

        public double DistanceBetween(Coordinate compare)
        {
            return Math.Sqrt(Math.Abs(this.x - compare.x) + Math.Abs(this.y - compare.y));
        }

        public double DistanceBetween(int x, int y)
        {
            return Math.Sqrt(Math.Abs(this.x - x) + Math.Abs(this.y - y));
        }
    }
}

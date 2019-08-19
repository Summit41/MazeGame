﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
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
            double a = Math.Abs(this.x - compare.x);
            double b = Math.Abs(this.y - compare.y);

            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }

        public double DistanceBetween(int x, int y)
        {
            double a = Math.Abs(this.x - x);
            double b = Math.Abs(this.y - y);

            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
    }
}

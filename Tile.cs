using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Tile
    {
        private string display;
        private string fow_display;
        private int index;
        private bool pathable;

        public Tile (int index, string display, string fow_display, bool pathable)
        {
            this.index = index;
            this.display = display;
            this.fow_display = fow_display;
            this.pathable = pathable;
        }

        public int GetIndex()
        {
            return index;
        }

        public string GetDisplay()
        {
            return display;
        }

        public string GetFOW_Display()
        {
            return fow_display;
        }

        public bool IsPathable()
        {
            return pathable;
        }

        public bool Compare(Tile compareTo)
        {
            if (this.index == compareTo.index)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

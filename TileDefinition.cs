using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    sealed class TileDefinition
    {
        public Tile PATH = new Tile(0, " ", ".", true);
        public Tile WALL = new Tile(1, "#", ".", false);
        public Tile END = new Tile(2, "!", "!", true);
        public Tile TEMPWALL = new Tile(3, "=", ".", false);
        public Tile PERMWALL = new Tile(4, "#", ".", false);
        public Tile START = new Tile(5, ".", ".", true);
        public Tile DEFAULT = new Tile(6, " ", ".", true);

        private static readonly TileDefinition INSTANCE = new TileDefinition();

        private TileDefinition()
        {
        }

        public static TileDefinition Instance
        {
            get
            {
                return INSTANCE;
            }
        }
    }
}

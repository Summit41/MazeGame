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

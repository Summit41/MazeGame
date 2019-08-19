using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    sealed class EntityList
    {
        public List<Entity> Entities = new List<Entity>();

        private static readonly EntityList INSTANCE = new EntityList();

        public static EntityList Instance
        {
            get
            {
                return INSTANCE;
            }
        }


    }
}

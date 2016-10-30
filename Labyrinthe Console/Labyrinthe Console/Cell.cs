using System;
using System.Collections.Generic;

namespace Labyrinthe_Console 
{
    class Cell
    {
        public String Type;
        static int _unicId = 1;
        public int Id = 0;
        public List<Coordinates> ListNeighbours = new List<Coordinates>();  

        public Cell(String type)
        {
            Type = type;
            if (type.Equals(" "))
            {
                Id = _unicId;
                _unicId++;              
            }
        }
    }
}

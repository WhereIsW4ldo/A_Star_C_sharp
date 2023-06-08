using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Star
{
    internal interface IInput
    {
        public int getSizeOfGrid();
        public (int x, int y) getPosition(int size_grid, bool start);
        public List<Tuple<int, int>> getWalls(int size_grid);
    }
}

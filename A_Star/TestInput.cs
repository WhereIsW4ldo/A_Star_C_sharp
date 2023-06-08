using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Star
{
    internal class TestInput : IInput
    {

        private int size = 10;
        private (int x, int y) s = (0, 0), e = (9, 9);

        public int getSizeOfGrid()
        {
            return size;
        }

        public (int x, int y) getPosition(int size_grid, bool start)
        {
            if (start)
            {
                return s;
            }
            else
            {
                return e;
            }
        }

        public List<Tuple<int, int>> getWalls(int size_grid)
        {
            List<Tuple<int, int>> walls = new List<Tuple<int, int>>
            {
                Tuple.Create(1, 1),
                Tuple.Create(2, 1),
                Tuple.Create(1, 2),
                Tuple.Create(1, 0),
                Tuple.Create(8, 8),
                Tuple.Create(8, 9),
                Tuple.Create(7, 8)
            };
            return walls;
        }
    }
}

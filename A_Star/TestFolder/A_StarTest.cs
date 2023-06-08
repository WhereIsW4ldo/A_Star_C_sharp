using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace A_Star.TestFolder
{
    public class A_StarTest
    {
        [Theory]
        [InlineData(0, 0, 10, 3)]
        [InlineData(1, 0, 10, 5)]
        [InlineData(0, 1, 10, 5)]
        [InlineData(1, 1, 10, 8)]
        [InlineData(9, 9, 10, 3)]
        public void get_adjacent_lenOfVector(int row, int col, int grid_size, int expect)
        {
            int res = A_star.get_adjacent(row, col, grid_size).Count;

            Assert.Equal(expect, res);
        }
    }
}

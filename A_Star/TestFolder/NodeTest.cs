using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace A_Star.TestFolder
{   
    public class NodeTest
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(0, 0, 1, 1, 2)]
        [InlineData(0, 0, 2, 2, 8)]
        [InlineData(0, 0, 3, 3, 18)]
        public void calculate_h_Test(int node_row, int node_col, int end_row, int end_col, int expect)
        {
            Node n = new Node(node_row, node_col);

            n.calculate_h(end_row, end_col);

            Assert.Equal(expect, n.h);
        }
    }
}

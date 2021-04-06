using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3.TriangleSort.Logic;

namespace _3.TriangleSort.View
{
    class SortedTriangleViewer
    {
        public SortedTriangleViewer(TriangleSquareSorter sortedTriangles)
        {
            _sortedTriangles = sortedTriangles;
        }

        private readonly TriangleSquareSorter _sortedTriangles;

        public void ShowSquares()
        {
            foreach (var triangle in _sortedTriangles.SortTriangles())
            {
                string fullTriangleMessage = string.Format("[{0}]: {1} cm",triangle.Name, triangle.Square);
                Console.WriteLine(fullTriangleMessage);
            }
        }
    }
}

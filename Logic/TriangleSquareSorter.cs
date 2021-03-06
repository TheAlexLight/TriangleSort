using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3.TriangleSort.View;

namespace _3.TriangleSort.Logic
{
    class TriangleSquareSorter 
    {
        public TriangleSquareSorter()
        {
            _listOfTriangles = new List<Triangle>();
        }

        private readonly List<Triangle> _listOfTriangles;

        public List<Triangle> AddTriangleIntoAList(Triangle oneTriangle)
        {
            if (oneTriangle == null)
            {
                throw new ArgumentNullException(Constant.EXCEPTION_NULL_TRIANGLE);
            }

           _listOfTriangles.Add(oneTriangle);

            return _listOfTriangles;
        }

        public List<Triangle> SortTriangles()
        {
            if (_listOfTriangles.Count == 0) 
            {
                throw new ArgumentNullException(Constant.EMPTY_TRIANGLE_LIST);
            }

             return _listOfTriangles.OrderByDescending(o=>o.Square).ToList();

        }
    }
}

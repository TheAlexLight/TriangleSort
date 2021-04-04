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

        public List<Triangle> ListOfTriangles { get { return _listOfTriangles; }  }

        public List<Triangle> SortedTriangleList 
        { 
            get 
            {
                return SortTriangles();
            }  
        }

        public void AddTriangleIntoAList(Triangle oneTriangle)
        {
            if (oneTriangle == null)
            {
                throw new ArgumentNullException(Constant.EXCEPTION_NULL_TRIANGLE);
            }

            _listOfTriangles.Add(oneTriangle);
        }

        public List<Triangle> SortTriangles()
        {
            if (_listOfTriangles.Count == 0) 
            {
                throw new ArgumentNullException(Constant.EMPTY_TRIANGLE_LIST);
            }

            List<Triangle> sortedList = _listOfTriangles.OrderByDescending(o=>o.Square).ToList();

            return sortedList;
        }
    }
}

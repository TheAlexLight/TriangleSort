using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TriangleSort.Logic
{
    class TriangleSquareSorter 
    {
        public TriangleSquareSorter()
        {
            listOfTriangles = new List<Triangle>();
        }

        private List<Triangle> listOfTriangles;

        public List<Triangle> ListOfTriangles { get { return listOfTriangles; }  }
        public List<Triangle> SortedTriangleList 
        { 
            get 
            {
                return SortTriangles();
            }  
        }

        public void AddTriangleIntoAList(Triangle oneTriangle)
        {
            if (oneTriangle == null) //ToDo: Validator
            {
                throw new Exception();
            }

            listOfTriangles.Add(oneTriangle);
        }

        public List<Triangle> SortTriangles()
        {
            if (listOfTriangles.Count == 0) //ToDo: Validator
            {
                throw new Exception();
            }

            List<Triangle> sortedList = listOfTriangles.OrderByDescending(o=>o.Square).ToList();

            return sortedList;
        }
    }
}

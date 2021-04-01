using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3.TriangleSort.Logic;
using _3.TriangleSort.View;

namespace _3.TriangleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (args.Length != 4)
            //{
            //    Console.WriteLine("Instruction"); //TODO: Implement instruction

            //    return;
            //}

            Triangle secondTriangle = new Triangle("FirstTriangle",1f, 1f, 1f);
            Triangle firstTriangle = new Triangle("SecondTriangle",3.2f,5.8f,7.4f);
            
            TriangleSquareSorter sorterOfTriangles = new TriangleSquareSorter();

            sorterOfTriangles.AddTriangleIntoAList(firstTriangle);
            sorterOfTriangles.AddTriangleIntoAList(secondTriangle);

            SortedTriangleViewer showSortedTriangles = new SortedTriangleViewer(sorterOfTriangles);

            showSortedTriangles.ShowSquares();

            Console.ReadKey();
        }
    }
}

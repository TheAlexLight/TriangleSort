using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3.TriangleSort.Controller;
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

            TriangleController controller = new TriangleController();
            TriangleParameters parameters = new TriangleParameters();

            parameters = controller.CheckTriangleStartData(args[0],args[1],args[2],args[3]);

            Triangle secondTriangle = new Triangle(parameters.Name, parameters.FirstSide, parameters.SecondSide, parameters.ThirdSide);

            Triangle firstTriangle = new Triangle("F",3.2f,5.8f,7.4f);
            
            TriangleSquareSorter sorterOfTriangles = new TriangleSquareSorter();

            sorterOfTriangles.AddTriangleIntoAList(firstTriangle);
            sorterOfTriangles.AddTriangleIntoAList(secondTriangle);

            SortedTriangleViewer showSortedTriangles = new SortedTriangleViewer(sorterOfTriangles);

            showSortedTriangles.ShowSquares();

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3.TriangleSort.Controller;
using _3.TriangleSort.Logic;
using _3.TriangleSort.View;
using ConsoleTaskLibrary;

namespace _3.TriangleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 4)
                {
                    throw new ArgumentException();
                }

                TriangleController _controller = new TriangleController();
                TriangleParameters _parameters;

                _parameters = _controller.CheckTriangleStartData(args[0], args[1], args[2], args[3]);


                TriangleSquareSorter sorterOfTriangles = new TriangleSquareSorter();

                sorterOfTriangles.AddTriangleIntoAList(new Triangle(_parameters.Name, _parameters.FirstSide, _parameters.SecondSide, _parameters.ThirdSide));

                bool needOneMoreTriangle = true;
                ConsolePrinter printer = new ConsolePrinter();


                while (needOneMoreTriangle)
                {
                    _parameters = _controller.AddOneMoreTriangle(ref needOneMoreTriangle);
                    sorterOfTriangles.AddTriangleIntoAList(new Triangle(_parameters.Name, _parameters.FirstSide, _parameters.SecondSide, _parameters.ThirdSide));
                }

                SortedTriangleViewer showSortedTriangles = new SortedTriangleViewer(sorterOfTriangles);

                showSortedTriangles.ShowSquares();

                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Instruction"); //TODO:Implement
            }
            
        }
    }
}

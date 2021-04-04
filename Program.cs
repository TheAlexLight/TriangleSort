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

                TriangleController controller = new TriangleController();
                TriangleParameters parameters;

                parameters = controller.CheckTriangleStartData(args[0], args[1], args[2], args[3]);

                //Triangle secondTriangle = new Triangle(parameters.Name, parameters.FirstSide, parameters.SecondSide, parameters.ThirdSide);

                TriangleSquareSorter sorterOfTriangles = new TriangleSquareSorter();

                sorterOfTriangles.AddTriangleIntoAList(new Triangle(parameters.Name, parameters.FirstSide, parameters.SecondSide, parameters.ThirdSide));

                bool addOneMoreTriangle = true;
                ConsolePrinter printer = new ConsolePrinter();

                while (addOneMoreTriangle)
                {
                    printer.WriteLine(Constant.ADD_NEW_TRIANGLE_PROMPT);
                    string checkAnswer = printer.ReadLine();

                    if (!checkAnswer.ToUpper().Equals(Constant.SIMPLE_YES) || checkAnswer.ToUpper().Equals(Constant.YES))
                    {
                        addOneMoreTriangle = false;
                        continue;
                    }

                    parameters = controller.EnterNewTriangle();
                    sorterOfTriangles.AddTriangleIntoAList(new Triangle(parameters.Name, parameters.FirstSide, parameters.SecondSide, parameters.ThirdSide));
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

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

                _controller.ExecuteMainOperations(args[0], args[1], args[2], args[3]);

                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Instruction"); //TODO:Implement
            }
            
        }
    }
}

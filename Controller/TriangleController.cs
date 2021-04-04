using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3.TriangleSort.Validation;
using _3.TriangleSort.View;
using ConsoleTaskLibrary;

namespace _3.TriangleSort.Controller
{
    class TriangleController
    {
        TriangleParameters triangleStartData = new TriangleParameters();
        readonly ConsolePrinter printer = new ConsolePrinter();
        readonly Converter converterArgs = new Converter();
        readonly Validator validArgs = new Validator();

        public TriangleParameters CheckTriangleStartData(string triangleName, string firstSide, string secondSide, string thirdSide)
        {
            if (!validArgs.CheckStringLength(triangleName))
            {
                triangleName = EnterNewName(Constant.NAME);
            }

            triangleStartData.Name = triangleName;

            triangleStartData.FirstSide = CheckTriangleSide(firstSide, Constant.FIRST_SIDE);
            triangleStartData.SecondSide = CheckTriangleSide(secondSide, Constant.SECOND_SIDE);
            triangleStartData.ThirdSide = CheckTriangleSide(thirdSide, Constant.THIRD_SIDE);

            if (!validArgs.IsTriangle(triangleStartData.FirstSide, triangleStartData.SecondSide, triangleStartData.ThirdSide))
            {
                printer.WriteLine(Constant.IS_NOT_TRIANGLE);

                triangleStartData = EnterNewTriangle();
            }
            
            return triangleStartData;
        }

        public TriangleParameters EnterNewTriangle()
        {
            bool isTriangle = false;

            while (!isTriangle)
            {
                triangleStartData.Name = EnterNewName(Constant.NAME);

                printer.Write(string.Format(Constant.ENTER_PROMPT, Constant.FIRST_SIDE));
                triangleStartData.FirstSide = CheckTriangleSide(printer.ReadLine(), Constant.FIRST_SIDE);

                printer.Write(string.Format(Constant.ENTER_PROMPT, Constant.FIRST_SIDE));
                triangleStartData.FirstSide = CheckTriangleSide(printer.ReadLine(), Constant.SECOND_SIDE);

                printer.Write(string.Format(Constant.ENTER_PROMPT, Constant.FIRST_SIDE));
                triangleStartData.FirstSide = CheckTriangleSide(printer.ReadLine(), Constant.THIRD_SIDE);

                if (validArgs.IsTriangle(triangleStartData.FirstSide, triangleStartData.SecondSide, triangleStartData.ThirdSide))
                {
                    isTriangle = true;
                }
                else
                {
                    printer.WriteLine(Constant.IS_NOT_TRIANGLE);
                }
            }

            return triangleStartData;
        }

        private string EnterNewName(string valueName)
        {
            bool successFormat = false;
            string name = "";

            while (!successFormat)
            {
                printer.Write(string.Format(Constant.ENTER_PROMPT, valueName));
                name = printer.ReadLine();

                if (!validArgs.CheckStringLength(name))
                {
                    printer.WriteLine(Constant.WRONG_BOUNDARIES);
                }
                else
                {
                    successFormat = true;
                }
            }

            return name;
        }

        private float CheckTriangleSide(string side, string valueName)
        {
            float result = -1.0f;
            bool successFormat = false;

            try
            {
                while (!successFormat)
                {
                    result = converterArgs.ParseToFloat(side);

                    if (result != -1)
                    {
                        if (!validArgs.CheckFloatOnPositive(result, Constant.MAX_TRIANGLE_SIDE))
                        {
                            printer.WriteLine(Constant.WRONG_BOUNDARIES);
                        }
                        else
                        {
                            successFormat = true;
                        }
                    }
                    else
                    {
                        printer.WriteLine(Constant.FLOAT_WRONG_TYPE);
                        printer.Write(string.Format(Constant.ENTER_PROMPT, valueName));

                        side = printer.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                printer.WriteLine(string.Format("{0}: {1}", Constant.EXCEPTION_OCCURED, ex.Message)); //Complete Exception
            }

            return result;
        }
    }
}

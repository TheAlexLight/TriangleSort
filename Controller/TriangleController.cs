using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3.TriangleSort.Validation;
using _3.TriangleSort.View;
using ConsolePrinterLibrary;

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
            bool needToCheck = NeedToCheckStartData();

            if (!validArgs.CheckStringLength(triangleName, needToCheck))
            {
                triangleName = EnterNewName(Constant.NAME, needToCheck);
            }

            triangleStartData.Name = triangleName;

            triangleStartData.FirstSide = CheckTriangleSide(firstSide, needToCheck, Constant.FIRST_SIDE);
            triangleStartData.SecondSide = CheckTriangleSide(secondSide, needToCheck, Constant.SECOND_SIDE);
            triangleStartData.ThirdSide = CheckTriangleSide(thirdSide, needToCheck, Constant.THIRD_SIDE);

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
                bool needToCheck = NeedToCheckStartData();

                triangleStartData.Name = EnterNewName(Constant.NAME, needToCheck);

                printer.Write(string.Format(Constant.ENTER_PROMPT, Constant.FIRST_SIDE));
                triangleStartData.FirstSide = CheckTriangleSide(printer.ReadLine(), needToCheck, Constant.FIRST_SIDE);

                printer.Write(string.Format(Constant.ENTER_PROMPT, Constant.FIRST_SIDE));
                triangleStartData.FirstSide = CheckTriangleSide(printer.ReadLine(), needToCheck, Constant.SECOND_SIDE);

                printer.Write(string.Format(Constant.ENTER_PROMPT, Constant.FIRST_SIDE));
                triangleStartData.FirstSide = CheckTriangleSide(printer.ReadLine(), needToCheck, Constant.THIRD_SIDE);

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

        private string EnterNewName(string valueName, bool needToCheck)
        {
            bool successFormat = false;
            string name = "";

            while (!successFormat)
            {
                printer.Write(string.Format(Constant.ENTER_PROMPT, valueName));
                name = printer.ReadLine();

                if (!validArgs.CheckStringLength(name, needToCheck))
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

        private float CheckTriangleSide(string side, bool needToCheck, string valueName)
        {
            float result = -1.0f;
            bool successFormat = false;

            try
            {
                while (!successFormat)
                {
                    result = converterArgs.ParseToFloat(side, needToCheck);

                    if (result != -1)
                    {
                        if (!validArgs.CheckFloatOnPositive(result, TriangleParameters.MAX_TRIANGLE_SIDE, needToCheck))
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

        private bool NeedToCheckStartData()
        {
            printer.Write(Constant.CHECK_ARGS_PROMPT);

            string prompt = printer.ReadLine();

            bool needToCheck = false;

            if (prompt.ToUpper().Equals(Constant.SIMPLE_YES) || prompt.ToUpper().Equals(Constant.YES))
            {
                needToCheck = true;
            }

            return needToCheck;
        }
    }
}

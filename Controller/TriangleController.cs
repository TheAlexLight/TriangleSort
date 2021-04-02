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
        ConsolePrinter consoleActor = new ConsolePrinter();
        Converter converterArgs = new Converter();
        Validator validArgs = new Validator();

        public TriangleParameters CheckTriangleStartData(string triangleName, string firstSide, string secondSide, string thirdSide)
        {
            bool needToCheck = NeedToCheckStartData();

            if (!validArgs.CheckStringLength(triangleName, needToCheck))
            {
                triangleName = EnterNewName("name", needToCheck);
            }

            triangleStartData.Name = triangleName;

            triangleStartData.FirstSide = CheckTriangleSide(firstSide, needToCheck, Constant.LEFT_SIDE);
            triangleStartData.SecondSide = CheckTriangleSide(secondSide, needToCheck, Constant.RIGHT_SIDE);
            triangleStartData.ThirdSide = CheckTriangleSide(thirdSide, needToCheck, Constant.BOTTOM_SIDE);

            if (!validArgs.IsTriangle(triangleStartData.FirstSide, triangleStartData.SecondSide, triangleStartData.ThirdSide))
            {
                Console.WriteLine("Wrong sides, try again "); // TODO: implement next Triangles;
            }
            
            return triangleStartData;
        }

        //public TriangleParameters EnterNewTriangle()
        //{
        //    Console.WriteLine("Enter name of Triangle and lengths of sides in format: name, firstSide, secondSide, thirdSide"); 
        //}

        private string EnterNewName(string valueName, bool needToCheck)
        {
            bool successFormat = false;
            string name = "";

            while (!successFormat)
            {
                consoleActor.Write(string.Format(Constant.ENTER_PROMPT, valueName));
                name = consoleActor.ReadLine();

                if (!validArgs.CheckStringLength(name, needToCheck))
                {
                    consoleActor.WriteLine(Constant.WRONG_BOUNDARIES);
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
                            consoleActor.WriteLine(Constant.WRONG_BOUNDARIES);
                        }
                        else
                        {
                            successFormat = true;
                        }
                    }
                    else
                    {
                        consoleActor.WriteLine(Constant.FLOAT_WRONG_TYPE);
                        consoleActor.Write(string.Format(Constant.ENTER_PROMPT, valueName));

                        side = consoleActor.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                consoleActor.WriteLine(string.Format("{0}: {1}", Constant.EXCEPTION_OCCURED, ex.Message)); //Complete Exception
            }

            return result;
        }

        private bool NeedToCheckStartData()
        {
            consoleActor.Write(Constant.CHECK_ARGS_PROMPT);

            string prompt = consoleActor.ReadLine();

            bool needToCheck = false;

            if (prompt.ToUpper().Equals(Constant.SIMPLE_YES) || prompt.ToUpper().Equals(Constant.YES))
            {
                needToCheck = true;
            }

            return needToCheck;
        }
    }
}

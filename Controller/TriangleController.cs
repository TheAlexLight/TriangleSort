using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3.TriangleSort.View;
using SoftServeProjectsLibrary;

namespace _3.TriangleSort.Controller
{
    class TriangleController
    {
        TriangleParameters triangleStartData = new TriangleParameters();
        ConsolePrinter consoleActor = new ConsolePrinter();

        public TriangleParameters CheckTriangleStartData(String triangleName, float leftSide, float rightSide, float bottomSide)
        {
            bool needToCheck = NeedToCheckStartData();

            return triangleStartData;
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

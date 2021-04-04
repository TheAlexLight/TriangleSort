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
        private TriangleParameters _triangleStartData = new TriangleParameters();
        private readonly ConsolePrinter _printer = new ConsolePrinter();
        private readonly Converter _converterArgs = new Converter();
        private readonly Validator _validArgs = new Validator();

        public TriangleParameters CheckTriangleStartData(string triangleName, string firstSide, string secondSide, string thirdSide)
        {
            try
            {
                if (!_validArgs.CheckStringLength(triangleName))
                {
                    triangleName = EnterNewName(Constant.NAME);
                }

                _triangleStartData.Name = triangleName;

                _triangleStartData.FirstSide = CheckTriangleSide(firstSide, Constant.FIRST_SIDE);
                _triangleStartData.SecondSide = CheckTriangleSide(secondSide, Constant.SECOND_SIDE);
                _triangleStartData.ThirdSide = CheckTriangleSide(thirdSide, Constant.THIRD_SIDE);

                if (!_validArgs.IsTriangle(_triangleStartData.FirstSide, _triangleStartData.SecondSide, _triangleStartData.ThirdSide))
                {
                    _printer.WriteLine(Constant.IS_NOT_TRIANGLE);

                    _triangleStartData = EnterNewTriangle();
                }

                return _triangleStartData;
            }
            catch (Exception ex)
            {
                _printer.WriteLine(string.Format("{0}: {1}",Constant.EXCEPTION_OCCURED, ex.Message));
                throw;
            }
        }

        public TriangleParameters EnterNewTriangle()
        {
            bool isTriangle = false;

            while (!isTriangle)
            {
                _triangleStartData.Name = EnterNewName(Constant.NAME);

                _triangleStartData = PromptToEnterNewSides();

                if (_validArgs.IsTriangle(_triangleStartData.FirstSide, _triangleStartData.SecondSide, _triangleStartData.ThirdSide))
                {
                    isTriangle = true;
                }
                else
                {
                    _printer.WriteLine(Constant.IS_NOT_TRIANGLE);
                }
            }

            return _triangleStartData;
        }

        public TriangleParameters AddOneMoreTriangle(ref bool needToAddNewTriangle)
        {
            _printer.WriteLine(Constant.ADD_NEW_TRIANGLE_PROMPT);
            string checkAnswer = _printer.ReadLine();

            if (!checkAnswer.ToUpper().Equals(Constant.SIMPLE_YES) || checkAnswer.ToUpper().Equals(Constant.YES))
            {
                needToAddNewTriangle = false;
                return new TriangleParameters();
            }

            return EnterNewTriangle();
        }

        private string EnterNewName(string valueName)
        {
            bool successFormat = false;
            string name = "";

            while (!successFormat)
            {
                _printer.Write(string.Format(Constant.ENTER_PROMPT, valueName));
                name = _printer.ReadLine();

                if (!_validArgs.CheckStringLength(name))
                {
                    _printer.WriteLine(Constant.WRONG_BOUNDARIES);
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
                    result = _converterArgs.ParseToFloat(side);

                    if (result != -1)
                    {
                        if (!_validArgs.CheckFloatOnPositive(result, Constant.MAX_TRIANGLE_SIDE))
                        {
                            _printer.WriteLine(Constant.WRONG_BOUNDARIES);
                        }
                        else
                        {
                            successFormat = true;
                        }
                    }
                    else
                    {
                        _printer.WriteLine(Constant.FLOAT_WRONG_TYPE);
                        _printer.Write(string.Format(Constant.ENTER_PROMPT, valueName));

                        side = _printer.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                _printer.WriteLine(string.Format("{0}: {1}", Constant.EXCEPTION_OCCURED, ex.Message)); //Complete Exception
            }

            return result;
        }

        private TriangleParameters PromptToEnterNewSides()
        {
            _printer.Write(string.Format(Constant.ENTER_PROMPT, Constant.FIRST_SIDE));
            _triangleStartData.FirstSide = CheckTriangleSide(_printer.ReadLine(), Constant.FIRST_SIDE);

            _printer.Write(string.Format(Constant.ENTER_PROMPT, Constant.SECOND_SIDE));
            _triangleStartData.FirstSide = CheckTriangleSide(_printer.ReadLine(), Constant.SECOND_SIDE);

            _printer.Write(string.Format(Constant.ENTER_PROMPT, Constant.THIRD_SIDE));
            _triangleStartData.FirstSide = CheckTriangleSide(_printer.ReadLine(), Constant.THIRD_SIDE);

            return _triangleStartData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3.TriangleSort.Logic;
using _3.TriangleSort.Validation;
using _3.TriangleSort.View;
using ConsoleTaskLibrary;

namespace _3.TriangleSort.Controller
{
    class TriangleController
    {
        private readonly ConsolePrinter _printer = new ConsolePrinter();
        private readonly Converter _converterArgs = new Converter();
        private readonly Validator _validArgs = new Validator();

        public void ExecuteMainOperations(string triangleName, string firstSide, string secondSide, string thirdSide)
        {
            TriangleParameters _triangleStartData;

            _triangleStartData = CheckTriangleStartData(triangleName, firstSide, secondSide, thirdSide); 

          TriangleSquareSorter _sorterOfTriangles = new TriangleSquareSorter();

            AddTriangleIntoAList( _sorterOfTriangles, _triangleStartData);

            bool needOneMoreTriangle = true;

            while (needOneMoreTriangle)
            {
                _triangleStartData = AddOneMoreTriangle(ref needOneMoreTriangle);

                if (_triangleStartData.Name != null)
                {
                    _sorterOfTriangles.AddTriangleIntoAList(new Triangle(_triangleStartData.Name, _triangleStartData.FirstSide,
                                                                         _triangleStartData.SecondSide, _triangleStartData.ThirdSide));
                }
               
            }

            SortedTriangleViewer showSortedTriangles = new SortedTriangleViewer(_sorterOfTriangles);

            showSortedTriangles.ShowSquares();
        }

        public List<Triangle> AddTriangleIntoAList(TriangleSquareSorter sorterOfTriangles, TriangleParameters parameters)
        {
            return sorterOfTriangles.AddTriangleIntoAList(new Triangle(parameters.Name, parameters.FirstSide, parameters.SecondSide, parameters.ThirdSide));
        }

        public TriangleParameters AddOneMoreTriangle(ref bool needToAddNewTriangle)
        {
            _printer.WriteLine(Constant.ADD_NEW_TRIANGLE_PROMPT);
            string checkAnswer = _printer.ReadLine();

            if (!checkAnswer.ToUpper().Equals(Constant.SIMPLE_YES) || checkAnswer.ToUpper().Equals(Constant.YES))
            {
                needToAddNewTriangle = false;
                return default;
            }

            return EnterNewTriangle();
        }

        private float CheckTriangleSide(string side)
        {
            float result = -1.0f;

            try
            {
                    result = _converterArgs.ParseToFloat(side);

                    if (result != -1)
                    {
                        if (!_validArgs.CheckFloatOnPositive(result, Constant.MAX_TRIANGLE_SIDE))
                        {
                            _printer.WriteLine(Constant.WRONG_BOUNDARIES); //TODO: Instruction
                        }
                    }
                    else
                    {
                        _printer.WriteLine(Constant.FLOAT_WRONG_TYPE);
                    }
            }
            catch (Exception ex)
            {
                _printer.WriteLine(string.Format("{0}: {1}", Constant.EXCEPTION_OCCURED, ex.Message)); //Complete Exception
            }

            return result;
        }

        public TriangleParameters CheckTriangleStartData(string triangleName, string firstSide, string secondSide, string thirdSide)
        {
            try
            {
                if (!_validArgs.CheckStringLength(triangleName))
                {
                    _printer.WriteLine(Constant.WRONG_BOUNDARIES);
                    _printer.ShowInstruction(Constant.INSTRUCTION, Constant.FIRST_ARGUMENT, 
                            Constant.SECOND_ARGUMENT, Constant.THIRD_ARGUMENT, Constant.FOURTH_ARGUMENT);

                    Environment.Exit(-1);
                }

                TriangleParameters _parameters = new TriangleParameters
                {
                    Name = triangleName,

                    FirstSide = CheckTriangleSide(firstSide),
                    SecondSide = CheckTriangleSide(secondSide),
                    ThirdSide = CheckTriangleSide(thirdSide)
                };

                if (!_validArgs.IsTriangle(_parameters.FirstSide, _parameters.SecondSide, _parameters.ThirdSide))
                {
                    _printer.WriteLine(Constant.IS_NOT_TRIANGLE);
                    _printer.ShowInstruction(Constant.INSTRUCTION, Constant.FIRST_ARGUMENT,
                            Constant.SECOND_ARGUMENT, Constant.THIRD_ARGUMENT, Constant.FOURTH_ARGUMENT);

                    Environment.Exit(-1);
                }

                return _parameters;
            }
            catch (Exception ex)
            {
                _printer.WriteLine(string.Format("{0}: {1}", Constant.EXCEPTION_OCCURED, ex.Message));
                throw;
            }
        }

        public TriangleParameters EnterNewTriangle()
        {
            _printer.WriteLine(Constant.ENTER_PROMPT);

            string[] newArgs = _printer.ReadLine().Split(',');

            if (newArgs.Length != 4)
            {
                _printer.WriteLine(Constant.WRONG_NEW_ARGUMENTS);

                _printer.ShowInstruction(Constant.INSTRUCTION, Constant.FIRST_ARGUMENT,
                           Constant.SECOND_ARGUMENT, Constant.THIRD_ARGUMENT, Constant.FOURTH_ARGUMENT);

                Environment.Exit(-1);
            }

            newArgs = RemoveSpaces(newArgs);
            newArgs = RemoveTabulation(newArgs);

            for (int i = 0; i < newArgs.Length; i++)
            {
                if (newArgs[i] == "")
                {
                    _printer.WriteLine(Constant.WRONG_NEW_ARGUMENTS);

                    _printer.ShowInstruction(Constant.INSTRUCTION, Constant.FIRST_ARGUMENT,
                               Constant.SECOND_ARGUMENT, Constant.THIRD_ARGUMENT, Constant.FOURTH_ARGUMENT);

                    Environment.Exit(-1);
                }
            }
            TriangleParameters _parameters;

            _parameters = new TriangleParameters()
            {
                FirstSide = CheckTriangleSide(newArgs[1]),
                SecondSide = CheckTriangleSide(newArgs[2]),
                ThirdSide = CheckTriangleSide(newArgs[3])
            };

            if (!_validArgs.CheckStringLength(newArgs[0]))
            {
                _printer.WriteLine(Constant.WRONG_BOUNDARIES);
                _printer.ShowInstruction(Constant.INSTRUCTION, Constant.FIRST_ARGUMENT,
                        Constant.SECOND_ARGUMENT, Constant.THIRD_ARGUMENT, Constant.FOURTH_ARGUMENT);

                Environment.Exit(-1);
            }

            _parameters.Name = newArgs[0];

            if (!_validArgs.IsTriangle(_parameters.FirstSide, _parameters.SecondSide, _parameters.ThirdSide))
            {
                _printer.WriteLine(Constant.IS_NOT_TRIANGLE);

                _printer.ShowInstruction(Constant.INSTRUCTION, Constant.FIRST_ARGUMENT,
                       Constant.SECOND_ARGUMENT, Constant.THIRD_ARGUMENT, Constant.FOURTH_ARGUMENT);

                Environment.Exit(-1);
            }

            return _parameters;
        }

        public string[] RemoveSpaces(string[] newArgs)
        {
            for (int i = 0; i < newArgs.Length; i++)
            {
               newArgs[i] = newArgs[i].Replace(" ", "");
            }

            return newArgs;
        }

        public string[] RemoveTabulation(string[] newArgs)
        {
            for (int i = 0; i < newArgs.Length; i++)
            {
                newArgs[i] = newArgs[i].Replace("    ", "");
            }

            return newArgs;
        }
    }
}

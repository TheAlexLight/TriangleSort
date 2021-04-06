﻿using System;
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

            _triangleStartData = CheckTriangleStartData(triangleName, firstSide, secondSide, thirdSide); //check arguments

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
                            _printer.Write(string.Format(Constant.ENTER_PROMPT, valueName));

                            side = _printer.ReadLine();
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

        public TriangleParameters CheckTriangleStartData(string triangleName, string firstSide, string secondSide, string thirdSide)
        {
            try
            {
                if (!_validArgs.CheckStringLength(triangleName))
                {
                    triangleName = EnterNewName(Constant.NAME);
                }

                TriangleParameters _parameters = new TriangleParameters
                {
                    Name = triangleName,

                    FirstSide = CheckTriangleSide(firstSide, Constant.FIRST_SIDE),
                    SecondSide = CheckTriangleSide(secondSide, Constant.SECOND_SIDE),
                    ThirdSide = CheckTriangleSide(thirdSide, Constant.THIRD_SIDE)
                };

                if (!_validArgs.IsTriangle(_parameters.FirstSide, _parameters.SecondSide, _parameters.ThirdSide))
                {
                    _printer.WriteLine(Constant.IS_NOT_TRIANGLE);

                    _parameters = EnterNewTriangle();
                }

                return _parameters;
            }
            catch (Exception ex)
            {
                _printer.WriteLine(string.Format("{0}: {1}", Constant.EXCEPTION_OCCURED, ex.Message));
                throw;
            }
        }

        private TriangleParameters PromptToEnterNewSides()
        {
            TriangleParameters parameters = new TriangleParameters();

            _printer.Write(string.Format(Constant.ENTER_PROMPT, Constant.FIRST_SIDE));
            parameters.FirstSide = CheckTriangleSide(_printer.ReadLine(), Constant.FIRST_SIDE);

            _printer.Write(string.Format(Constant.ENTER_PROMPT, Constant.SECOND_SIDE));
            parameters.SecondSide = CheckTriangleSide(_printer.ReadLine(), Constant.SECOND_SIDE);

            _printer.Write(string.Format(Constant.ENTER_PROMPT, Constant.THIRD_SIDE));
            parameters.ThirdSide = CheckTriangleSide(_printer.ReadLine(), Constant.THIRD_SIDE);

            return parameters;
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

        public TriangleParameters EnterNewTriangle()
        {
            bool isTriangle = false;

            TriangleParameters _parameters = new TriangleParameters();

            while (!isTriangle)
            {
                string triangleName = EnterNewName(Constant.NAME);

                _parameters = PromptToEnterNewSides();

                _parameters.Name = triangleName;

                if (_validArgs.IsTriangle(_parameters.FirstSide, _parameters.SecondSide, _parameters.ThirdSide))
                {
                    isTriangle = true;
                }
                else
                {
                    _printer.WriteLine(Constant.IS_NOT_TRIANGLE);
                }
            }

            return _parameters;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3.TriangleSort.Controller;
using _3.TriangleSort.View;

namespace _3.TriangleSort.Validation
{
    class Validator
    {

        public bool IsTriangle(float firstSide, float secondSide, float thirdSide)
        {
            return ((firstSide + secondSide > thirdSide)
                    && (secondSide + thirdSide > firstSide)
                    && (firstSide + thirdSide > secondSide));
        }

        public bool CheckFloatOnPositive(float floatToCheck, bool needToCheck)
        {
            if (!needToCheck)
            {
                if (floatToCheck <= 0)
                {
                    throw new ArgumentOutOfRangeException(Constant.OUT_OF_RANGE_ERROR);
                }
            }

            return floatToCheck > 0;
        }

        public bool CheckFloatOnPositive(float intToCheck, float maxValue, bool needToCheck)
        {
            if (!needToCheck)
            {
                if (intToCheck <= 0 || intToCheck > maxValue)
                {
                    throw new ArgumentOutOfRangeException(Constant.OUT_OF_RANGE_ERROR);
                }
            }

            return (intToCheck > 0 && intToCheck <= maxValue);
        }

        public bool CheckStringLength(string name, bool needToCheck)
        {
            bool result;

            if (needToCheck)
            {
                if (string.IsNullOrWhiteSpace(name) || name.Length > TriangleParameters.MAX_NAME_LENGTH)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException(Constant.ARGUMENT_NULL_EXCEPTION);
                }
                else if (name.Length > TriangleParameters.MAX_NAME_LENGTH)
                {
                    throw new ArgumentOutOfRangeException(Constant.WRONG_BOUNDARIES);
                }
                else
                {
                    result = true;
                }
            }

            return result;
        }


    }
}

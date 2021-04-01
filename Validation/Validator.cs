using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3.TriangleSort.View;

namespace _3.TriangleSort.Validation
{
    class Validator
    {
        public bool IsTriangle(float leftSide, float rightSide, float bottomSide)
        {
            return ((leftSide + rightSide <= bottomSide) 
                    && (bottomSide + rightSide <= leftSide) 
                    && (bottomSide + leftSide <= rightSide));
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
    }
}

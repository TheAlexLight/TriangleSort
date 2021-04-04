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

        public bool CheckFloatOnPositive(float floatToCheck)
        {
            return floatToCheck > 0;
        }

        public bool CheckFloatOnPositive(float intToCheck, float maxValue)
        {
            return (intToCheck > 0 && intToCheck <= maxValue);
        }

        public bool CheckStringLength(string name)
        {
            bool result = false;

                if (!(string.IsNullOrWhiteSpace(name) || name.Length > Constant.MAX_NAME_LENGTH))
                {
                    result = true;
                }
            
            return result;
        }
    }
}

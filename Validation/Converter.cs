using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TriangleSort.Validation
{
    class Converter
    {
        public float ParseToFloat(string strToCheck, bool needToCheck)
        {
            float result = -1;

            if (needToCheck)
            {
                if (float.TryParse(strToCheck, out _))
                {
                    result = float.Parse(strToCheck);
                }
            }
            else
            {
                try
                {
                    result = float.Parse(strToCheck);
                }
                catch (FormatException ex)
                {

                    throw new FormatException(ex.Message); //TODO: Exception
                }
                catch (ArgumentNullException ex)
                {
                    throw new FormatException(ex.Message);
                }
            }

            return result;
        }
    }
}

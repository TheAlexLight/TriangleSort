using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TriangleSort.Validation
{
    class Converter
    {
        CultureInfo culture = (CultureInfo)CultureInfo.CurrentUICulture.Clone();

        public Converter()
        {
            culture.NumberFormat.CurrencyDecimalSeparator = ".";
        }
        public float ParseToFloat(string strToCheck, bool needToCheck)
        {
            float result = -1;

            if (needToCheck)
            {
                if (float.TryParse(strToCheck, NumberStyles.Any, culture, out _))
                {
                    result = float.Parse(strToCheck, NumberStyles.Any, culture);
                }
            }
            else
            {
                try
                {
                    result = float.Parse(strToCheck, NumberStyles.Any, culture);
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

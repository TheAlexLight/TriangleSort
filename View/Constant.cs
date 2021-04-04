using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TriangleSort.View
{
    static class Constant
    {
        public static int MAX_TRIANGLE_SIDE = 1000000;
        public static int MAX_NAME_LENGTH = 50;

        public const string CHECK_ARGS_PROMPT = @"Do you want to check arguments?(Write """"y"""" or """"yes"""" to accept): ";
        public const string ADD_NEW_TRIANGLE_PROMPT = @"Do you want to add one more triangle?(Write """"y"""" or """"yes"""" to accept): ";
        public const string SIMPLE_YES = "Y";
        public const string YES = "Yes";
        public const string OUT_OF_RANGE_ERROR = "ERROR: The number is out of range";
        public const string WRONG_BOUNDARIES = "Wrong number boundaries, try again";
        public const string FLOAT_WRONG_TYPE = "Type of data should be float, try again";
        public const string ENTER_PROMPT = "Enter your triangle {0}: ";
        public const string EXCEPTION_OCCURED = "ERROR occured";
        public const string FIRST_SIDE = "Side 1";
        public const string SECOND_SIDE = "Side 2";
        public const string THIRD_SIDE = "Side 3";
        public const string ARGUMENT_NULL_EXCEPTION = "ERROR: Wrong data";
        public const string NAME = "name";
        public const string IS_NOT_TRIANGLE = "Cannot build triangle with this sides, enter new data";

    }
}

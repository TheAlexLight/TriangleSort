using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TriangleSort.View
{
    static class Constant
    {
        public static int MAX_TRIANGLE_SIDE = 10000;
        public static int MAX_NAME_LENGTH = 50;

        public const string ADD_NEW_TRIANGLE_PROMPT = @"Do you want to add one more triangle?(Write ""y"" or ""yes"" to accept): ";
        public const string SIMPLE_YES = "Y";
        public const string YES = "Yes";
        public const string OUT_OF_RANGE_ERROR = "ERROR: The number is out of range";
        public const string WRONG_BOUNDARIES = "Wrong number boundaries";
        public const string FLOAT_WRONG_TYPE = "Type of data should be float";
        public const string ENTER_PROMPT = "Enter new triangle data: <name>, <first side>, <second side>, <third side>";
        public const string EXCEPTION_OCCURED = "ERROR occured";
        public const string ARGUMENT_NULL_EXCEPTION = "ERROR: Wrong data";
        public const string IS_NOT_TRIANGLE = "Cannot build triangle with this sides";
        public const string EXCEPTION_NULL_TRIANGLE = "Cannot add triangle without data";
        public const string EMPTY_TRIANGLE_LIST = "There no any triangles in the list";
        public const string INSTRUCTION = "Instruction of using: You should use 4 arguments:";
        public const string FIRST_ARGUMENT = "1 argument - Triangle name: Type - String";
        public const string SECOND_ARGUMENT = "2 argument - First triangle side: Type - Integer(Greater than 0)";
        public const string THIRD_ARGUMENT = "3 argument - Second triangle side: Type - Integer(Greater than 0)";
        public const string FOURTH_ARGUMENT = "4 argument - Third triangle side: Type - Integer(Greater than 0)";
        public const string WRONG_NEW_ARGUMENTS = "Wrong triangle data";

    }
}

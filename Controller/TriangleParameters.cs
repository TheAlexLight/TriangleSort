using _3.TriangleSort.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TriangleSort.Controller
{
    struct TriangleParameters
    {
        public static int MAX_TRIANGLE_SIDE = 1000000;

       private float leftSide;
       private float rightSide;
       private float bottomSide;

        public float LeftSide 
        {
            get 
            {
                return leftSide;
            } 
            set
            {
                if (value > 0 && value <= MAX_TRIANGLE_SIDE)
                {
                    leftSide = value;
                }
            } 
        }
        public float RightSide
        {
            get
            {
                return rightSide;
            }
            set
            {
                if (value > 0 && value <= MAX_TRIANGLE_SIDE)
                {
                    rightSide = value;
                }
            }
        }
        public float BottomSide
        {
            get
            {
                return bottomSide;
            }
            set
            {
                if (value > 0 && value <= MAX_TRIANGLE_SIDE)
                {
                    bottomSide = value;
                }
            }
        }
    }
}

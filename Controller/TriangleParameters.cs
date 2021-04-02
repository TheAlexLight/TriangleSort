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

        private string name;
       private float firstSide;
       private float secondSide;
       private float thirdSide;

        public float FirstSide 
        {
            get 
            {
                return firstSide;
            } 
            set
            {
                if (value > 0 && value <= MAX_TRIANGLE_SIDE)
                {
                    firstSide = value;
                }
            } 
        }
        public float SecondSide
        {
            get
            {
                return secondSide;
            }
            set
            {
                if (value > 0 && value <= MAX_TRIANGLE_SIDE)
                {
                    secondSide = value;
                }
            }
        }
        public float ThirdSide
        {
            get
            {
                return thirdSide;
            }
            set
            {
                if (value > 0 && value <= MAX_TRIANGLE_SIDE)
                {
                    thirdSide = value;
                }
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length < 255 && value.Length > 0)
                {
                    name = value;
                }
            }
        }
    }
}

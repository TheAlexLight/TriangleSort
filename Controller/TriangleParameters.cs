using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3.TriangleSort.Validation;
using _3.TriangleSort.View;

namespace _3.TriangleSort.Controller
{
    struct TriangleParameters
    {
       private string _name;
       private float _firstSide;
       private float _secondSide;
       private float _thirdSide;

        public float FirstSide 
        {
            get 
            {
                return _firstSide;
            } 
            set
            {
                if (value > 0 && value <= Constant.MAX_TRIANGLE_SIDE)
                {
                    _firstSide = value;
                }
            } 
        }
        public float SecondSide
        {
            get
            {
                return _secondSide;
            }
            set
            {
                if (value > 0 && value <= Constant.MAX_TRIANGLE_SIDE)
                {
                    _secondSide = value;
                }
            }
        }
        public float ThirdSide
        {
            get
            {
                return _thirdSide;
            }
            set
            {
                if (value > 0 && value <= Constant.MAX_TRIANGLE_SIDE)
                {
                    _thirdSide = value;
                }
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < Constant.MAX_NAME_LENGTH && value.Length > 0)
                {
                    _name = value;
                }
            }
        }
    }
}

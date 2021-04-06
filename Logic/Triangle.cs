using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TriangleSort.Logic
{
    class Triangle : Shape
    {
        public Triangle(string name, float firstSide, float secondSide, float thirdSide)
        {
            _name = name;
            _firstSide = firstSide;
            _secondSide = secondSide;
            _thirdSide = thirdSide;

            CalculateSquare();
        }
 
        private readonly float _firstSide;
        private readonly float _secondSide;
        private readonly float _thirdSide;

        public float Square => _square;
        public string Name => _name;

        protected override void CalculateSquare()
        {
            float halfPerimeter = CalculateSemiPerimeter();

            _square = (float)Math.Sqrt(halfPerimeter * (halfPerimeter - _firstSide) * (halfPerimeter - _secondSide)
                * (halfPerimeter - _thirdSide));
        }

        private float CalculateSemiPerimeter()
        {
            return (_firstSide + _secondSide + _thirdSide) / 2.0f;
        }
    }
}

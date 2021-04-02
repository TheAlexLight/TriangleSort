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
            this.name = name;
            this.firstSide = firstSide;
            this.secondSide = secondSide;
            this.thirdSide = thirdSide;

            CalculateSquare();
        }
 
        private readonly float firstSide;
        private readonly float secondSide;
        private readonly float thirdSide;

        public float Square { get { return square; } }
        public string Name { get { return name; } }

        protected override void CalculateSquare()
        {
            float halfPerimeter = CalculateSemiPerimeter();

            square = (float)Math.Sqrt(halfPerimeter * (halfPerimeter - firstSide) * (halfPerimeter - secondSide)
                * (halfPerimeter - thirdSide));
        }

        private float CalculateSemiPerimeter()
        {
            return (firstSide + secondSide + thirdSide) / 2.0f;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TriangleSort.Logic
{
    class Triangle
    {
        public Triangle(float leftSide, float rightSide, float bottomSide)
        {
            arrayOfSides[0] = leftSide;
            arrayOfSides[1] = rightSide;
            arrayOfSides[2] = bottomSide;

            CalculateSquare();

        }

        private float[] arrayOfSides = new float[3]; //left, right, bottom
        private float square;

        public float Square { get { return square; } }

        private void CalculateSquare()
        {
            float halfPerimeter = CalculateSemiPerimeter();

            square = (float)Math.Sqrt(halfPerimeter * (halfPerimeter - arrayOfSides[0]) * (halfPerimeter - arrayOfSides[1]) 
                * (halfPerimeter - arrayOfSides[2]));
        }

        private float CalculateSemiPerimeter()
        {
            return (arrayOfSides[0] + arrayOfSides[1] + arrayOfSides[2]) / 2.0f;
        }
    }
}

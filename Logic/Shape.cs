using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TriangleSort.Logic
{
   public abstract class Shape
    {
        protected string name;
        protected float square;

        protected abstract void CalculateSquare();
    }
}

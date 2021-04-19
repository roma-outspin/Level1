using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6
{
    class MyArrayDataException: Exception
    {

        public int X { get; }
        public int Y { get; }

        public MyArrayDataException(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

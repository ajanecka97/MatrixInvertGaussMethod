using System;

namespace MatrixInvertGaussMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(3, 2, 2, 3, 4, 7, 1, 8, 1, 9);
            matrix.Print();
        }
    }
}

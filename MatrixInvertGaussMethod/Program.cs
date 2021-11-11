using System;

namespace MatrixInvertGaussMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Matrix matrix = new Matrix(3, 3, 2, 2, 3, 4, 7, 1, 8, 1, 9);
                Matrix matrix2 = new Matrix(3);
                matrix
                    .Print()
                    .Concat(matrix2)
                    .Print()
                    .Invert()
                    .Print();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

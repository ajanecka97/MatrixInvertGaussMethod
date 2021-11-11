using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixInvertGaussMethod
{
    class Matrix
    {
        private readonly double[,] _matrix;
        private readonly int _size;

        public Matrix(int size, params double[] elements )
        {
            this._size = size;
            this._matrix = new double[size, size];
            for(var i = 0; i < size; i++)
                for(var j = 0; j < size; j++)
                    this._matrix[i, j] = elements[i * size + j];
        }

        public void Print()
        {
            for (var i = 0; i < this._size; i++)
            {
                for (var j = 0; j < this._size; j++)
                    Console.Write("{0} ", this._matrix[i, j]);
                Console.WriteLine();
            }

        }
    }
}

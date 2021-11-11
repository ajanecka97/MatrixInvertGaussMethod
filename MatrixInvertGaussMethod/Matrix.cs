using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixInvertGaussMethod
{
    class Matrix
    {
        private readonly double[,] _matrix;

        public double[,] GetMatrix { get { return this._matrix; } }
        public int Rows { get { return this._matrix.GetLength(0); } }
        public int Cols { get { return this._matrix.GetLength(1); } }


        //create matrix with certain amoung of rows and columns
        public Matrix(int rows, int cols, params double[] elements )
        {
            this._matrix = new double[rows, cols];
            for(var i = 0; i < rows; i++)
                for(var j = 0; j < cols; j++)
                    this._matrix[i, j] = elements[i * cols + j];
        }

        //create matrix from another matrix but with 1 changed row
        public Matrix(Matrix matrix, double[] row, int rowNumber)
        {
            if (matrix.Cols != row.Length) throw new Exception("Liczba kolumn macierzy musi być równa długości wiersza");

            var newMatrix = matrix.GetMatrix;
            for(var i = 0; i < matrix.Cols; i++)
            {
                newMatrix[rowNumber, i] = row[i];
            }
            this._matrix = newMatrix;
        }
        
        //create new identity matrix
        public Matrix(int size)
        {
            this._matrix = new double[size, size];

            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                    if (i == j) this._matrix[i, j] = 1;
                    else this._matrix[i, j] = 0;

        }

        public double[] GetRow(int rowNumber)
        {
            return Enumerable.Range(0, this.Cols).Select(x => this._matrix[rowNumber, x]).ToArray();
        }

        public Matrix Concat(Matrix matrix)
        {
            if (this.Rows != matrix.Rows) throw new Exception("Concat: Liczba wierzy musi być równa w obu macierzach");

            var resultParams = new double[0];

            for(var i = 0; i < this.Rows; i++)
            {
                resultParams = resultParams.Concat(this.GetRow(i)).Concat(matrix.GetRow(i)).ToArray();
            }

            return new Matrix(this.Rows, this.Cols + matrix.Cols, resultParams);
        }

        public Matrix RowTimesScalar(int rowNumber, double scalar)
        {
            var multipliedRow = this.GetRow(rowNumber);
            for (var i = 0; i < multipliedRow.Length; i++) multipliedRow[i] *= scalar;

            return new Matrix(this, multipliedRow, rowNumber);
        }

        public Matrix ZeroElem(int rowOneNumber, int rowTwoNumber, double scalar)
        {
            var rowOne = this.GetRow(rowOneNumber);
            var rowTwo = this.GetRow(rowTwoNumber);

            for (var i = 0; i < rowOne.Length; i++) rowOne[i] -= rowTwo[i] * scalar;

            return new Matrix(this, rowOne, rowOneNumber);
        }

        public Matrix Invert() {
            Matrix result = this;

            for(var j = 0; j < this.Rows; j++)
            {
                result = result.RowTimesScalar(j, 1/result.GetMatrix[j, j]);
                for(int i = j+1; i < this.Rows; i++)
                {
                    result = result.ZeroElem(i, j, result.GetMatrix[i, j]);
                }

            }

            for(var j = this.Rows - 1; j >= 0; j--)
            {
                result = result.RowTimesScalar(j, 1 / result.GetMatrix[j, j]);
                for (int i = j - 1; i >= 0; i--)
                {
                    result = result.ZeroElem(i, j, result.GetMatrix[i, j]);
                }
            }

            return result;
        }

        public Matrix Print()
        {
            for (var i = 0; i < this.Rows; i++)
            {
                for (var j = 0; j < this.Cols; j++)
                    Console.Write("{0:0.##}\t", this._matrix[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();

            return this;
        }
    }
}

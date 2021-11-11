using System;

namespace MatrixInvertGaussMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Podaj rozmiar macierzy: ");
                int size = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Podaj {0} liczb oddzielonych spacjami: ", size*size);
                string[] numbersAsStrings = Console.ReadLine().Split(" ");
                var numbers = new double[numbersAsStrings.Length];
                for(var i = 0; i < numbersAsStrings.Length; i++)
                {
                    numbers[i] = Convert.ToDouble(numbersAsStrings[i]);
                }

                Matrix matrix = new Matrix(size, size, numbers);

                matrix
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

using Test;
namespace P
{
    class P
    {
        static void Main()
        {

            double[,] m1 = {
                {0, 1, 5, 2, 3 },
                {0, 1, 5, 1, 4 },
                {2, 0, 5, 6, 2 },
                {0, 1, 5, 0, 6 },
            };
            double[,] m2 = {
                {1, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] m3 = {
                {10, 3, 40, 31 },
                {10, 2, 35, 31 },
                {12, 8, 65, 34 },
                {10, 1, 30, 31 },
            };
            double[,] m4 = {
                {-2, 4.5, 14 },
                {25, 0, -1 },
                {-10.5, 4, 1.5 }
            };
            Matrix matrix1 = new Matrix(m1);
            SquareMatrix matrix2 = new SquareMatrix(m2);

            SquareMatrix matrix3 = new SquareMatrix(m4);
            Console.WriteLine(matrix3.AdjointMatrix());
            //Console.WriteLine(matrix1 * 5);
            //Console.WriteLine(matrix2.ReversedMatrix());
        }
    }
}
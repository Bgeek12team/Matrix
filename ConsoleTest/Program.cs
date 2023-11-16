using Test;
namespace P
{
    class P
    {
        static void Main()
        {

            double[,] m1 = {
                {-1, 2, 1, 5},
                {5, 1, 7, 9},
                {9, 3, 4, 8},
                {7, 4, 4, 7},

            };
            double[,] m2 = {
                {0, 1, 5, 2 },
                {0, 3, 5, 1 },
                {0, 0, 7, 6 },
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
                {25, 0, -1},
                {-10.5, 4, 1.5 },
                {-10.5, 4, 1.5 },
                {-10.5, 4, 1.5 }
            };
            SquareMatrix matrix1 = new SquareMatrix(Matrix.GenerateRandomMatrix(100, 100, -10, 10));
            //SquareMatrix matrix1 = new SquareMatrix(m1);

            Console.WriteLine(matrix1);
            Console.WriteLine(matrix1.Determinant());
            Console.WriteLine(matrix1.ReversedMatrix());

            //SquareMatrix factInverse = new SquareMatrix(Matrix.GenerateRandomMatrix(20, 20, 1, 1000));
            //Console.WriteLine(factInverse.Determinant());
            //Console.WriteLine(factInverse.ReversedMatrix());

            //Console.WriteLine(matrix1 * factInverse);

            //foreach (var root in matrix1.GetRoots(new double[] { 1, 1, 1, 1 }))
            //    Console.WriteLine(root);

            //Console.WriteLine(matrix1 * 5);
            //Console.WriteLine(matrix2.ReversedMatrix());
        }
    }
}
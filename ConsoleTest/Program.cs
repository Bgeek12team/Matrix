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
                {9, 3, 3,8},
                {7, 4, 4,7},

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
                {25, 0, -1},
                {-10.5, 4, 1.5 },
                {-10.5, 4, 1.5 },
                {-10.5, 4, 1.5 }
            };
            SquareMatrix matrix1 = new SquareMatrix(m1);
            SquareMatrix matrix2 = new SquareMatrix(m2);

            
            SquareMatrix factInverse = new SquareMatrix(matrix1.ReversedMatrix());
            Console.WriteLine(factInverse);
            
            Console.WriteLine(matrix1 * factInverse);

            foreach (var root in matrix1.GetRoots(new double[] { 1, 1, 1, 1 }))
                Console.WriteLine(root);

            Console.WriteLine(matrix1 * 5);
            Console.WriteLine(matrix2.ReversedMatrix());
        }
    }
}
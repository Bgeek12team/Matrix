using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tests
{
    [TestClass()]
    public class MatrixTests
    {
        /// <summary>
        /// Проверка метода ZeroMatrix с нулевой матрицей
        /// </summary>
        [TestMethod()]
        public void IsZeroMatrixTest()
        {
            Matrix matrix = new Matrix(5,5);
            if (!matrix.IsZeroMatrix())
                Assert.Fail();
        }
        /// <summary>
        /// Проверка метода ZeroMatrix с одним ненулевым значением
        /// </summary>
        [TestMethod()]
        public void IsZeroMatrixTest2()
        {
            Matrix matrix = new Matrix(5, 5);
            matrix.SetElem(1, 1, 4);
            if (matrix.IsZeroMatrix())
                Assert.Fail();
        }
        /// <summary>
        /// Проверка метода ZeroMatrix с отрицательными значениями
        /// </summary>
        [TestMethod()]
        public void IsZeroMatrixNegative()
        {
            Matrix matrix = new Matrix(2, 2);
            matrix.SetElem(1, 1, -4);
            matrix.SetElem(0, 0, -3);
            if (matrix.IsZeroMatrix())
                Assert.Fail();
        }
        /// <summary>
        ///  Тест складывающий две ненулевые матрицы размером 4х4
        /// </summary>
        [TestMethod()]
        public void AddMatrixTest()
        {
            double[,] m1 = { 
                {0, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] m2 = {
                {1, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] mRes = {
                {1, 2, 10, 4 },
                {0, 2, 10, 2 },
                {4, 0, 10, 12 },
                {0, 2, 10, 0 },
            };

            Matrix matrix1 = new Matrix(m1);
            Matrix matrix2 = new Matrix(m2);

            Matrix matrixRes = new Matrix(mRes);

            Assert.AreEqual(matrixRes, matrix1.AddMatrix(matrix2));
        }
        /// <summary>
        ///  Тест складывающий элементы текущей матрицы с константой
        /// </summary>
        [TestMethod()]
        public void AddMatrixWithConst()
        {
            double[,] m1 = {
                {0, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double value = 5;
            double[,] mRes = {
                {5, 6, 10, 7 },
                {5, 6, 10, 6 },
                {7, 5, 10, 11 },
                {5, 6, 10, 5 },
            };

            Matrix matrix1 = new Matrix(m1);

            Matrix matrixRes = new Matrix(mRes);

            Assert.AreEqual(matrixRes, matrix1.AddMatrixWithConst(value));
        }
        /// <summary>
        ///  Тест складывающий элементы текущей матрицы с константой = 0
        /// </summary>
        [TestMethod()]
        public void AddMatrixWithConstZero()
        {
            double[,] m1 = {
                {0, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double value = 0;
            double[,] mRes = {
                {0, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };

            Matrix matrix1 = new Matrix(m1);

            Matrix matrixRes = new Matrix(mRes);

            Assert.AreEqual(matrixRes, matrix1.AddMatrixWithConst(value));
        }
        /// <summary>
        ///  Тест складывающий элементы текущей матрицы с отрицательной константой
        /// </summary>
        [TestMethod()]
        public void AddMatrixWithConstNegative()
        {
            double[,] m1 = {
                {0, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double value = -100;
            double[,] mRes = {
                {-100, -99, -95, -98 },
                {-100, -99, -95, -99 },
                {-98, -100, -95, -94 },
                {-100, -99, -95, -100 },
            };

            Matrix matrix1 = new Matrix(m1);

            Matrix matrixRes = new Matrix(mRes);

            Assert.AreEqual(matrixRes, matrix1.AddMatrixWithConst(value));
        }
        /// <summary>
        ///  Тест складывающий две ненулевые матрицы размером 1x1
        /// </summary>
        [TestMethod()]
        public void AddMatrixTest2()
        {
            double[,] m1 = {{9}};
            double[,] m2 = {{5}};
            double[,] mRes = {{14}};

            Matrix matrix1 = new Matrix(m1);
            Matrix matrix2 = new Matrix(m2);

            Matrix matrixRes = new Matrix(mRes);

            Assert.AreEqual(matrixRes, matrix1.AddMatrix(matrix2));
        }
        /// <summary>
        ///  Тест складывающий две отритацельные матрицы размером 4х4
        /// </summary>
        [TestMethod()]
        public void AddMatrixWithTwoNeagive()
        {
            double[,] m1 = {
                {0, -1, -5, -2 },
                {0, -1, -5, -1 },
                {-2, 0, -5, -6 },
                {0, -1, -5, 0 },
            };
            double[,] m2 = {
                {-1, -1, -5, -2 },
                {0, -1, -5, -1 },
                {-2, 0, -5, -6 },
                {0, -1, -5, 0 },
            };
            double[,] mRes = {
                {-1, -2, -10, -4 },
                {0, -2,-10, -2 },
                {-4, 0, -10, -12 },
                {0, -2, -10, 0 },
            };

            Matrix matrix1 = new Matrix(m1);
            Matrix matrix2 = new Matrix(m2);

            Matrix matrixRes = new Matrix(mRes);

            Assert.AreEqual(matrixRes, matrix1.AddMatrix(matrix2));
        }
        /// <summary>
        ///  Тест вычитающий из одной матрицы размером 4х4 другую
        /// </summary>
        [TestMethod()]
        public void SubMatrixTest()
        {
            double[,] m1 = {
                {0, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] m2 = {
                {1, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] mRes = {
                {-1, 0, 0, 0 },
                {0, 0, 0, 0 },
                {0, 0, 0, 0 },
                {0, 0, 0, 0 },
            };

            Matrix matrix1 = new Matrix(m1);
            Matrix matrix2 = new Matrix(m2);
            Matrix matrixRes = new Matrix(mRes);
            Assert.AreEqual(matrixRes, matrix1.SubMatrix(matrix2));
        }
        /// <summary>
        ///  Тест вычитающий из матрицы с отрицательными значениями другую
        /// </summary>
        [TestMethod()]
        public void SubNegativeMatrix()
        {
            double[,] m1 = {
                {-10, -1, -5, -2 },
                {-5, -1, -7, -8},
                {-4, -3, -1, -2 },
                {-8, -1, -5, -5 },
            };
            double[,] m2 = {
                {-5, -10, -7, -12 },
                {-10, -5, -5, -2 },
                {-2, -6, -5, -6 },
                {-4, -11, -5, -3 },
            };
            double[,] mRes = {
                {-5, 9, 2, 10 },
                {5, 4, -2, -6 },
                {-2, 3, 4, 4 },
                {-4, 10, 0, -2 },
            };

            Matrix matrix1 = new Matrix(m1);
            Matrix matrix2 = new Matrix(m2);
            Matrix matrixRes = new Matrix(mRes);
            Assert.AreEqual(matrixRes, matrix1.SubMatrix(matrix2));
        }
        /// <summary>
        ///  Тест вычитающий из матрицы размером 1x1 другую такую же
        /// </summary>
        [TestMethod()]
        public void SubOneValueMatrix()
        {
            double[,] m1 = {
                {10},
            };
            double[,] m2 = {
                {-5},
            };
            double[,] mRes = {
                {15 } };

            Matrix matrix1 = new Matrix(m1);
            Matrix matrix2 = new Matrix(m2);
            Matrix matrixRes = new Matrix(mRes);
            Assert.AreEqual(matrixRes, matrix1.SubMatrix(matrix2));
        }
        /// <summary>
        /// Проверка умножения матрицы на константу
        /// </summary>
        [TestMethod()]
        public void MultiplyMatrxTest()
        {
            double[,] m1 = {
                {0, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double scalar = 3;
            double[,] mRes = {
                {0, 3, 15, 6 },
                {0, 3, 15, 3 },
                {6, 0, 15, 18 },
                {0, 3, 15, 0 },
            };

            Matrix matrix1 = new Matrix(m1);

            Matrix matrixRes = new Matrix(mRes);
            Matrix matrixRes2 = matrix1.MultiplyMatrx(scalar);

            Assert.AreEqual(matrixRes, matrixRes2);
        }
        /// <summary>
        /// Тест перемножающий две матрицы размером 4x4
        /// </summary>
        [TestMethod()]
        public void MultiplyMatrxTest1()
        {
            double[,] m1 = {
                {0, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] m2 = {
                {1, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] mRes = {
                {10, 3, 40, 31 },
                {10, 2, 35, 31 },
                {12, 8, 65, 34 },
                {10, 1, 30, 31 },
            };

            Matrix matrix1 = new Matrix(m1);
            Matrix matrix2 = new Matrix(m2);

            Matrix matrixRes = new Matrix(mRes);
            Matrix matrixRes2 = matrix1.MultiplyMatrx(matrix2);

            Assert.AreEqual(matrixRes, matrixRes2);
        }
        /// <summary>
        /// Проверка умножения матрицы на константу = 0
        /// </summary>
        [TestMethod()]
        public void MultiplyMatrxWithZero()
        {
            double[,] m1 = {
                {1, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double scalar = 0;
            double[,] mRes = {
                {0, 0, 0, 0 },
                {0, 0, 0, 0 },
                {0, 0, 0, 0 },
                {0, 0, 0, 0 },
            };

            Matrix matrix1 = new Matrix(m1);

            Matrix matrixRes = new Matrix(mRes);
            Assert.AreEqual(matrixRes, matrix1.MultiplyMatrx(scalar));
        }
        /// <summary>
        /// Проверка умножения матрицы на константу = 0
        /// </summary>
        [TestMethod()]
        public void MultiplyMatrxWithNegativeConst()
        {
            double[,] m1 = {
                {1, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double scalar = -1.5;
            double[,] mRes = {
                {-1.5, -1.5, -7.5, -3 },
                {0, -1.5, -7.5, -1.5 },
                {-3, 0, -7.5, -9 },
                {0, -1.5, -7.5, 0 },
            };

            Matrix matrix1 = new Matrix(m1);

            Matrix matrixRes = new Matrix(mRes);
            Assert.AreEqual(matrixRes, matrix1.MultiplyMatrx(scalar));
        }
        /// <summary>
        /// Перемножает матрицы состоящие из одного элемента
        /// </summary>
        [TestMethod()]
        public void MultiplyMatrxWithOneElement()
        {
            double[,] m1 = {
                {57},
            };
            double[,] m2 = {
                {11 },
            };
            double[,] mRes = {
                {627},
            };

            Matrix matrix1 = new Matrix(m1);
            Matrix matrix2 = new Matrix(m2);

            Matrix matrixRes = new Matrix(mRes);
            Assert.AreEqual(matrixRes, matrix1.MultiplyMatrx(matrix2));
        }

    }
}
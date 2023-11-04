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
        [TestMethod()]
        public void IsZeroMatrixTest()
        {
            Matrix matrix = new Matrix(5,5);
            if (!matrix.IsZeroMatrix())
                Assert.Fail();
        }
        [TestMethod()]
        public void IsZeroMatrixTest2()
        {
            Matrix matrix = new Matrix(5, 5);
            matrix.SetElem(1, 1, 4);
            if (matrix.IsZeroMatrix())
                Assert.Fail();
        }

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
            Matrix matrixRes2 = matrix1.AddMatrix(matrix2);

            Assert.AreEqual(matrixRes, matrixRes2);
        }

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
            Matrix matrixRes2 = matrix1.SubMatrix(matrix2);

            Assert.AreEqual(matrixRes, matrixRes2);
        }

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
                {2, 0, 15, 18 },
                {0, 3, 15, 0 },
            };

            Matrix matrix1 = new Matrix(m1);

            Matrix matrixRes = new Matrix(mRes);
            Matrix matrixRes2 = matrix1.MultiplyMatrx(scalar);

            Assert.AreEqual(matrixRes, matrixRes2);
        }

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

    }
}
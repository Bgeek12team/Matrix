using System;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Test
{
    /// <summary>
    /// Класс, позволяющий осуществлять работу с типом данных Матрица,
    /// хранящим числа в виде двумерного массива
    /// </summary>
    public class Matrix 
    {
        protected const int PAD_MARGIN = 5;
        /// <summary>
        /// Поле, отображающее максимальную длину матрицы в одном измерении,
        /// при котором она будет выводиться полностью
        /// </summary>
        protected const int MAX_TO_PRINT = 10;
        /// <summary>
        /// Поле класса, отображающее количество строк
        /// </summary>
        protected int amountOfRows;
        /// <summary>
        /// Поле класса, отображающее количество столбцов
        /// </summary>
        protected int amountOfCols;
        /// <summary>
        /// Основное поле класса - двумерный массив, 
        /// и являющийся матрицей
        /// </summary>
        protected double[,] matrix;
        /// <summary>
        /// Пустой конструктор, создающий матрицу 3x3, 
        /// заполненную случайными элементами от 0 до 10
        /// </summary>
        public Matrix()
        {
            this.amountOfRows = 3;
            this.amountOfCols = 3;
            this.matrix = new double[3, 3];
            this.FillRandom(0, 10);
        }
        /// <summary>
        /// Конструктор, создающий экземпляр класса на основе данного массива - 
        /// целочисленного
        /// </summary>
        /// <param name="mtx">
        /// Двумерный целочисленный массив, на основе
        /// которого создается экземпляр класса
        /// </param>
        public Matrix(double[,] mtx)
        {
            this.amountOfCols = mtx.GetLength(0);
            this.amountOfRows = mtx.GetLength(1);
            this.matrix = mtx;
        }
        /// <summary>
        /// Конструктор, создающий новую пустую квадратную
        /// матрицу с заданной длиной
        /// </summary>
        /// <param name="size">Длина квадратной матрицы</param>
        public Matrix(int size)
        {
            this.amountOfRows = size;
            this.amountOfCols = size;
            this.matrix = new double[size, size];
        }
        /// <summary>
        /// Создает новую пустую матрицу с заданным количеством
        /// строк и столбцов
        /// </summary>
        /// <param name="amountOfRows">Количество строк в новой матрице</param>
        /// <param name="amountOfCols">Количество столбцов в новой матрице</param>
        public Matrix(int amountOfRows, int amountOfCols)
        {
            this.amountOfCols = amountOfCols;
            this.amountOfRows = amountOfRows;
            this.matrix = new double[amountOfCols, amountOfRows];
        }
        /// <summary>
        /// Возвращает длину матрицы по горизонтали
        /// </summary>
        /// <returns>Длина матрицы по горизонтали, т.е.
        /// количество столбцов</returns>
        public int AmountOfCols
        {
            get { return amountOfCols; }
        }
        /// <summary>
        /// Возвращает элемент по заданной строке и столбцу
        /// </summary>
        /// <param name="row">Заданная строка</param>
        /// <param name="col">Заданный столбец</param>
        /// <returns>Элемент, имеющий координаты [строка; столбец]</returns>
        public double this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }
        /// <summary>
        /// Возвращает длину матрицы по вертикали
        /// </summary>
        /// <returns>Длина матрицы по вертикали, т.е.
        /// количество строк</returns>ё
        public int AmountOfRows
        {
            get { return amountOfRows; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double[,] GetMatrix
        {
            get { return matrix; }
        }
        /// <summary>
        /// Возвращает элемент по заданной строке и столбцу
        /// </summary>
        /// <param name="row">Заданная строка</param>
        /// <param name="col">Заданный столбец</param>
        /// <returns>Элемент, имеющий координаты [строка; столбец]</returns>
        public double GetElem(int row, int col)
        {
            return this.matrix[row, col];
        }
        /// <summary>
        /// Позволяет установить элемент на данную позицию
        /// </summary>
        /// <param name="row">Строка, на которой будет находиться элемент</param>
        /// <param name="col">Столбец, на котором будет находиться элемент</param>
        /// <param name="elem">Вствляемый элемент</param>
        public void SetElem(int row, int col, double elem)
        {
            this.matrix[row, col] = elem;
        }
        /// <summary>
        /// Проверяет, состоит ли текущая матрица
        /// исключительно из нулей
        /// </summary>
        /// <returns>
        /// True: текущая матрица состоит только из нулей;
        /// False: текущая матрица не состоит только из нулей;
        /// </returns>
        public bool IsZeroMatrix()
        {
            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    if (matrix[i, j] != 0)
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Добавляет к текущей матрице данную, если это возможно
        /// </summary>
        /// <param name="matrix">
        /// Складываемая матрица, размеры которой
        /// совпадают с размерами данной
        /// </param>
        /// <returns>Матрица - сумма текущей матрицы и складываемой</returns>
        /// <exception cref="ArgumentException">
        /// Исключение, возникающее в случае, если размеры матриц не совпадают,
        /// и сложение невозможно
        /// </exception>
        public Matrix AddMatrix(Matrix matrix)
        {
            if (!HasSameSize(this, matrix))
                throw new ArgumentException("Матрицы должны иметь одинаковый размер. " +
                    "Сложение невозможно.");

            Matrix mat = new Matrix(AmountOfRows, AmountOfCols);
            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    mat.SetElem(i, j, this.matrix[i, j] + matrix.GetElem(i, j));
                }
            }
            return mat;
        }
        /// <summary>
        /// Увеличивает все элементы текущей матрицы на константу
        /// /// </summary>
        /// <param name="value">
        /// Складываемая матрица
        /// </param>
        /// <returns>Матрица - сумма текущей матрицы с константой/returns>
        public Matrix AddMatrixWithConst(double value)
        {
            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    matrix[i,j] += value;
                }
            }
            return new Matrix(matrix);
        }
        /// <summary>
        /// Вычитает из текущей матрицы данную, если это возможно
        /// </summary>
        /// <param name="matrix">Вычитаемая матрица</param>
        /// <returns>Разность текущей матрицы и вычитаемой</returns>
        /// <exception cref="ArgumentException">
        /// Исключение, возникающее в случае, если размеры матриц не совпадают,
        /// и вычитание невозможно
        /// </exception>
        public Matrix SubMatrix(Matrix matrix)
        {
            if (!HasSameSize(this, matrix))
                throw new ArgumentException("Матрицы должны иметь одинаковый размер. " +
                    "Вычитание невозможно.");
            Matrix mat = new Matrix(AmountOfRows, AmountOfCols);
            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    mat.SetElem(i, j, this.matrix[i, j] - matrix.GetElem(i, j));
                }
            }
            return mat;
        }

        /// <summary>
        /// Возращает результат матричного умножения текущей матрицы
        /// и данной в случае, если оно возможно
        /// </summary>
        /// <param name="matrix">
        /// Матрица, на которую умножается текущая,
        /// имеющая количество строк равное количеству столбцов текущей
        /// </param>
        /// <returns>Произведение текущей матрицы и данной</returns>
        /// <exception cref="ArgumentException">
        /// Исключение, возникающее в случае,
        /// если размеры количество строк умножаемой матрицы не равно
        /// количеству столбцов текущей,
        /// и умножение невозможно
        /// </exception>
        public Matrix MultiplyMatrx(Matrix matrix)
        {
            int rows1 = this.amountOfCols;
            int cols1 = this.AmountOfRows;
            int rows2 = matrix.amountOfCols;
            int cols2 = matrix.AmountOfRows;

            if (cols1 != rows2)
            {
                throw new ArgumentException("Умножение невозможно");
            }

            double[,] result = new double[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    for (int k = 0; k < cols1; k++)
                    {
                        result[i, j] += this[i, k] * matrix[k, j];
                    }
                }
            }

            return new(result);
        }
        /// <summary>
        /// Умножает текущую матрицу на скаляр
        /// </summary>
        /// <param name="value">Целочисленный скаляр,
        /// на который умножается текущая матрица</param>
        /// <returns>Произведение текущей матрицы и скаляра</returns>
        public Matrix MultiplyMatrx(double value)
        {
            Matrix mat = new Matrix(AmountOfRows, AmountOfCols);

            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    mat.SetElem(i, j, matrix[i, j] * value);
                }
            }

            return mat;
        }

        public Matrix Transpose()
        {
            double[,] result = new double[amountOfRows, amountOfCols];

            for (int i = 0; i < amountOfCols; i++)
            {
                for (int j = 0; j < amountOfRows; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return new(result);
        }

        /// <summary>
        /// Оператор, осуществляющий сложение двух заданный матрица
        /// </summary>
        /// <param name="matrix">Первая складываемая матрица</param>
        /// <param name="secondMatrix">Вторая складываемая матрица</param>
        /// <returns>Сумма данных матриц</returns>
        public static Matrix operator +(Matrix matrix, Matrix secondMatrix)
        {
            return matrix.AddMatrix(secondMatrix);
        }
        /// <summary>
        /// Оператор, осуществляющий вычитание двух заданный матрица
        /// </summary>
        /// <param name="matrix">Матрица, из которой вычитается вторая</param>
        /// <param name="secondMatrix">Вычитаемая матрица</param>
        /// <returns>Разность данных матриц</returns>
        public static Matrix operator -(Matrix matrix, Matrix secondMatrix)
        {
            return matrix.SubMatrix(secondMatrix);
        }
        /// <summary>
        /// Оператор, осуществляющий умножение двух заданный матриц
        /// </summary>
        /// <param name="matrix">Первая умножаемая матрица</param>
        /// <param name="secondMatrix">Вторая умножаемая матрица</param>
        /// <returns>Произведение данных матриц</returns>
        public static Matrix operator *(Matrix matrix, Matrix secondMatrix)
        {
            return matrix.MultiplyMatrx(secondMatrix);
        }
        /// <summary>
        /// Оператор, осуществляющий умножение данной матрицы на скаляр
        /// </summary>
        /// <param name="matrix">Умножаемая матрица</param>
        /// <param name="scalar">Скаляр, на который умножеается матрица</param>
        /// <returns>Произведение матрицы на скаляр</returns>
        public static Matrix operator *(Matrix matrix, double scalar)
        {
            return matrix.MultiplyMatrx(scalar);
        }
        /// <summary>
        /// Проверяет матрицы на полное равенство
        /// </summary>
        /// <param name="obj">Сравниваемый объект, предположительно, матрица</param>
        /// <returns>
        /// True: матрицы равны либо ссылаются на один и тот же 
        /// объект в памяти;
        /// False: все остальные случаи
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (!typeof(Matrix).IsInstanceOfType(obj))
                return false;

            Matrix matrix = (Matrix)obj;
            if (!HasSameSize(matrix, this))
                return false;

            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    if (this.matrix[i, j] != matrix.GetElem(i, j))
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Возвращает строку, отображающую матрицу
        /// </summary>
        /// <returns>Строка, отображающая матрицу</returns>
        public override string ToString()
        {

            string mnogotochie = "";
            for (int i = 0; i < PAD_MARGIN ; i++)
            {
                mnogotochie =  mnogotochie + ".";
            } 

            StringBuilder res = new StringBuilder();
            res.Append("[\r\n");
            for (int i = 0; i < AmountOfCols; i++)
            {
                res.Append("[ ");
                if (i == MAX_TO_PRINT - 1 && AmountOfCols != MAX_TO_PRINT)
                {
                    for (int j = 0; j < MAX_TO_PRINT + 1; j++)
                    {
                        res.Append(mnogotochie + ", ");
                    }
                    res.Remove(res.Length - 2, 2);
                    res.Append("],\r\n");
                    i = AmountOfCols - 2;
                    continue;
                }
                for (int j = 0; j < AmountOfRows; j++)
                {
                    if (j == MAX_TO_PRINT - 1 && AmountOfRows != MAX_TO_PRINT)
                    {
                        j = AmountOfRows - 1;
                        res.Append(mnogotochie + ", ");
                        res.Append(matrix[i, j].ToString($"F{PAD_MARGIN - 2}") + ", ");
                        break;
                    }
                    res.Append(matrix[i,j].ToString($"F{PAD_MARGIN - 2}") + ", ");
                }
                res.Remove(res.Length - 2, 2);
                res.Append("],\r\n");
            }
            res.Remove(res.Length - 3, 3);
            res.Append("\r\n]");
            return res.ToString();
        }
        /// <summary>
        /// Заполняет текущую матрицу случайными элементами
        /// из заданного отрезка
        /// </summary>
        /// <param name="start">Начало отрезка, из которого берутся элементы</param>
        /// <param name="end">Конец отрезка, из которого берутся элементы</param>
        public void FillRandom(double start, double end)
        {
            Random random = new Random();
            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    //double num = ((end - start) * random.NextDouble() + start);
                    double num = random.Next((int) start, (int) end);
                    matrix[i,j] = num;
                }
            }
        }

        /// <summary>
        /// Метод, позволяющий создавать новую матрицу
        /// заданного размера, заполненную случайными элементами
        /// в заданном отрезке
        /// </summary>
        /// <param name="rows">Количество строк в новой матрице</param>
        /// <param name="cols">Количество столбцов в новой матрице</param>
        /// <param name="start">Начало отрезка, из которого берутся случайные числа</param>
        /// <param name="end">Конец отрезка, из которого берутся случайные числа</param>
        /// <returns>Матрица заданного размера, заполненная случайными элементами</returns>
        public static Matrix GenerateRandomMatrix(int rows, int cols, double start, double end)
        {
            Matrix matrix = new Matrix(rows, cols);
            matrix.FillRandom(start, end);
            return matrix;
        }
        /// <summary>
        /// Метод, проверяющий, имеют ли одинаковые размеры по вертикали
        /// и по горизонтали заданные матрицы
        /// </summary>
        /// <param name="first">Первая матрица</param>
        /// <param name="second">Вторая матрица</param>
        /// <returns>
        /// True: матрицы имеют одинаковое число строк и столбцов;
        /// False: все иные случаи ;
        /// </returns>
        public static bool HasSameSize(Matrix first, Matrix second)
        {
            return
                first.AmountOfCols == second.AmountOfCols &&
                first.AmountOfRows == second.AmountOfRows;
        }
        /// <summary>
        /// Меняет местами данные ряды
        /// </summary>
        /// <param name="first">Первый меняемый ряд</param>
        /// <param name="second">Второй меняемый ряд</param>
        protected void SwapRows(int first, int second)
        {
            for (int i = 0; i < AmountOfCols; i++)
            {
                double temp = matrix[second, i];
                matrix[second, i] = matrix[first, i];
                matrix[first, i] = temp;
            }
        }
        public bool IsDegreeOfTwo()
        {
            int n = matrix.GetLength(0);
            if (n > 0 && (n & (n - 1)) == 0)
                return true;
            return false;
        }
        public bool EqualsForSize(Matrix B)
        {
            return ((this.amountOfRows == B.amountOfRows) && (this.amountOfCols == B.amountOfCols));
        }
        public Matrix GetMultiplyStrassen(Matrix B)
        {
            if (IsDegreeOfTwo() && EqualsForSize(B))
                return MultiplyStrassen(this, B);
            return MultiplyMatrx(B);
        }
        private static Matrix MultiplyStrassen(Matrix HelpMatrixA, Matrix HelpMatrixB)
        {
            int n = HelpMatrixA.AmountOfRows;
            if (n == 1)
                return HelpMatrixA * HelpMatrixB;

            n >>= 1;

            Matrix A11 = new Matrix(n);
            Matrix A12 = new Matrix(n);
            Matrix A21 = new Matrix(n);
            Matrix A22 = new Matrix(n);

            Matrix B11 = new Matrix(n);
            Matrix B12 = new Matrix(n);
            Matrix B21 = new Matrix(n);
            Matrix B22 = new Matrix(n);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    A11[i, j] = HelpMatrixA[i, j];
                    A12[i, j] = HelpMatrixA[i, j + n];
                    A21[i, j] = HelpMatrixA[i + n, j];
                    A22[i, j] = HelpMatrixA[i + n, j + n];

                    B11[i, j] = HelpMatrixB[i, j];
                    B12[i, j] = HelpMatrixB[i, j + n];
                    B21[i, j] = HelpMatrixB[i + n, j];
                    B22[i, j] = HelpMatrixB[i + n, j + n];
                }

            Matrix P1 = MultiplyStrassen(A11, B12 - B22);
            Matrix P2 = MultiplyStrassen(A11 + A12, B22);
            Matrix P3 = MultiplyStrassen(A21 + A22, B11);
            Matrix P4 = MultiplyStrassen(A22, B21 - B11);
            Matrix P5 = MultiplyStrassen(A11 + A22, B11 + B22);
            Matrix P6 = MultiplyStrassen(A12 - A22, B21 + B22);
            Matrix P7 = MultiplyStrassen(A11 - A21, B11 + B12);

            Matrix C11 = P5 + P4 - P2 + P6;
            Matrix C12 = P1 + P2;
            Matrix C21 = P3 + P4;
            Matrix C22 = P5 + P1 - P3 - P7;

            Matrix resultMatrix = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultMatrix[i, j] = C11[i, j];
                    resultMatrix[i, j + n] = C12[i, j];
                    resultMatrix[i + n, j] = C21[i, j];
                    resultMatrix[i + n, j + n] = C22[i, j];
                }
            }

            return resultMatrix;
        }
    }
    /// <summary>
    /// Класс, реализующий математическую квадратную матрицу
    /// </summary>
    public class SquareMatrix : Matrix
    {
        private double? det;
        private double[,]? LUmatrix; //матрица LU из LUP-разложения
        private int[] perm; //массив перестановок из LUP-разложения
        private int toggle; //счетчик четности перестановок из LUP-разложения
        /// <summary>
        /// Конструктор, создающий матрицу 3х3, заполненную пустыми элементами
        /// </summary>
        public SquareMatrix() : base() { }
        /// <summary>
        /// Конструктор, создающий квадратную матрицу, на основе двумерного
        /// массива, измерения которого совпадают
        /// </summary>
        /// <param name="matrix">Двумерный
        /// массив, измерения которого совпадают</param>
        /// <exception cref="ArgumentException">
        /// Исключение, возникающее в случае, если измерения двумерного массива
        /// не совпадают
        /// </exception>
        public SquareMatrix(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException("Массив должен быть квадратным");

            this.matrix = matrix;
            this.amountOfRows = matrix.GetLength(0);
            this.amountOfCols = this.amountOfRows;
            LUPdecomposition();
        }
        /// <summary>
        /// Конструктор, приводящий произвольную матрицу к квадртаной, если это возможно
        /// </summary>
        /// <param name="matrix">Матрица измерения которой совпадают</param>
        /// <exception cref="ArgumentException">
        /// Исключение, возникающее в случае, если измерения Матрицы
        /// не совпадают
        /// </exception>
        public SquareMatrix(Matrix matrix)
        {
            if (matrix.AmountOfCols != matrix.AmountOfRows)
                throw new ArgumentException("Массив должен быть квадратным");

            this.matrix = matrix.GetMatrix;
            this.amountOfRows = matrix.AmountOfRows;
            this.amountOfCols = this.amountOfRows;
            LUPdecomposition();
        }
        /// <summary>
        /// Конструктор, создающий новую пустую квадратную
        /// матрицу данного размера
        /// </summary>
        /// <param name="size">Длина квадратной матрицы</param>
        public SquareMatrix(int size) : base(size) { }
        /// <summary>
        /// LUP-разложение текущей матрицы с поиском опорного элемента в каждом столбце
        /// Записывает матрицы L и U в одну для экономии памяти
        /// </summary>
        public void LUPdecomposition()
        {
            int n = AmountOfCols;
            LUmatrix = Aux.CopyArray(GetMatrix);
            perm = new int[n];
            for (int i = 0; i < n;  ++i) { perm[i] = i; }
            toggle = 1;
            for (int j = 0; j < n - 1; ++j)
            {
                double colMax = LUmatrix[j, j];
                int pRow = j;
                for (int i = j + 1; i < n; ++i)
                {
                    if (LUmatrix[i, j] > colMax)
                    {
                        colMax = LUmatrix[i, j];
                        pRow = i;
                    }
                }
                if (pRow != j)
                {
                    Aux.SwapRows(LUmatrix, pRow, j);
                    int tmp = perm[pRow];
                    perm[pRow] = perm[j];
                    perm[j] = tmp;
                    toggle = -toggle;
                }
                if (Math.Abs(LUmatrix[j, j]) < 1.0E-20)
                {
                    LUmatrix = null;
                    return;
                }
                for (int i = j + 1; i < n; ++i)
                {
                    LUmatrix[i, j] /= LUmatrix[j, j];
                    for (int k = j + 1; k < n; ++k)
                        LUmatrix[i, k] -= LUmatrix[i, j] * LUmatrix[j, k];
                }
            }
        }
        /// <summary>
        /// Метод для решения системы
        /// LU*x=b
        /// </summary>
        /// <param name="b">массив свободных коэффициентов</param>
        /// <returns>x - массив значений переменных x1-xn</returns>
        private double[] HelperSolve(double[] b)
        {
            int n = LUmatrix.GetLength(0);
            double[] x = new double[n];
            b.CopyTo(x, 0);
            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= LUmatrix[i, j] * x[j];
                x[i] = sum;
            }
            x[n - 1] /= LUmatrix[n - 1, n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= LUmatrix[i, j] * x[j];
                x[i] = sum / LUmatrix[i, i];
            }
            return x;
        }
        /// <summary>
        /// Метод для нахождения обратной матрицы с помощью LUP-разложения
        /// </summary>
        /// <returns>Матрица, обратная к данной</returns>
        public SquareMatrix MatrixInverse()
        {
            int n = AmountOfCols;
            double[,] result = Aux.CopyArray(matrix);
            double[] b = new double[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;
                }
                double[] x = HelperSolve(b);
                for (int j = 0; j < n; ++j)
                    result[j, i] = x[j];
            }
            return new(result);
        }
        /// <summary>
        /// Метод для решения системы
        /// This*x=b с использованием матрицы LU из LUP-разложения
        /// </summary>
        /// <param name="b">массив свободных коэффициентов</param>
        /// <returns>x - массив значений переменных x1-xn</returns>
        public double[] SystemSolve(double[] b)
        {
            int n = AmountOfCols;
            double[] bp = new double[b.Length];
            for (int i = 0; i < n; ++i)
                bp[i] = b[perm[i]];
            double[] x = HelperSolve(bp);
            return x;
        }
        /// <summary>
        /// Вычисляет детерминант текущей матрицы
        /// </summary>
        /// <returns>Детерминант текущей матрицы</returns>
        public double Determinant()
        {
            if (det != null)
                return (double)det;

            if ((LUmatrix != null) && (amountOfCols > 9))
            {
                double result = toggle;
                for (int i = 0; i < AmountOfCols; ++i)
                    result *= LUmatrix[i, i];
                det = result;
            }
            else
                det = Determinant(GetMatrix);

            return (double)det;
        }
        /// <summary>
        /// Рекурсивно находит определитель матрицы, соответсвующкй данному массиву
        /// </summary>
        /// <param name="matrix">Массив</param>
        /// <returns>Определитель матрицы, соответсвующкй данному массиву</returns>
        private static double Determinant(double[,] matrix)
        {
            if (matrix.GetLength(0) == 1)
                return matrix[0, 0];
            double det = 0;
            int size = matrix.GetLength(0);
            int rowToExclude = 0;// Строка которую исключаем
            for (int col = 0; col < size; col++)
            {
                var tMatrix = new double[size - 1, size - 1];//Под матрица для вычисления минора
                for (int tRow = 0; tRow < size - 1; tRow++)
                {
                    for (int tCol = 0; tCol < size - 1; tCol++)
                    {
                        int OriginalRow = (tRow < rowToExclude) ? tRow : tRow + 1;
                        int subMatrix = (tCol < col) ? tCol : tCol + 1;
                        tMatrix[tRow, tCol] = matrix[OriginalRow, subMatrix];
                    }
                }
                det += Determinant(tMatrix) * matrix[rowToExclude, col] * (((rowToExclude + col) % 2 == 0) ? 1 : -1);
            }
            return det;
        }
        /// <summary>
        /// Возвращает матрицу, сопряженную к исходной
        /// </summary>
        /// <returns>Матрица, сопряженная к исходной</returns>
        public SquareMatrix AdjointMatrix()
        {
            int size = matrix.GetLength(0);
            Matrix cofactored = new Matrix(size);

            for (int row = 0; row < size; row++)
                for (int col = 0; col < size; col++)
                {
                    if ((row + col) % 2 == 0)
                        cofactored[row, col] = GetMinor(row, col).Determinant();
                    else
                        cofactored[row, col] = - GetMinor(row, col).Determinant();
                }
                    

            return new SquareMatrix(cofactored.Transpose());
        }
        /// <summary>
        /// Возвращает минор матрицы элемента,
        /// стоящем в i-ой строке и в j-ом столбце
        /// </summary>
        /// <param name="i">номер строки</param>
        /// <param name="j">номер столбца</param>
        /// <returns>матрица-минор</returns>
        public SquareMatrix GetMinor(int i, int j)
        {

            int size = matrix.GetLength(0);
            SquareMatrix minor = new SquareMatrix(size - 1);
            int minorRow = 0;
            for (int row = 0; row < size; row++)
            {
                if (row == i)
                    continue;

                int minorCol = 0;
                for (int col = 0; col < size; col++)
                {
                    if (col == j)
                        continue;

                    minor[minorRow, minorCol] = matrix[row, col];
                    minorCol++;
                }

                minorRow++;
            }

            return minor;
        }
        /// <summary>
        /// Возвращает матрицу, обратную к данной
        /// </summary>
        /// <returns>Матрица, обратная к данной</returns>
        public SquareMatrix ReversedMatrix()
        {
            if ((LUmatrix != null) && (amountOfCols > 9))
            {
                return MatrixInverse();
            }
            else
            {
                double det = Determinant();
                if (det == 0)
                    throw new ArgumentException("Определитель равен нулю, обратной матрицы не существует!");

                SquareMatrix transposed = new(AdjointMatrix());
                return new SquareMatrix(transposed * (1 / det));
            }
        }
        
        /// <summary>
        /// Принимая значения матрицы за коэфициент при независимой переменной,
        /// имеющей порядковый номер столбца, начиная с нуля,
        /// а также массив свободных коэфициентов, где каждому i-тому элементу 
        /// соответсвует коэфициент для i-той строки, 
        /// решает получившуются систему линейных алгебраических уравнений
        /// </summary>
        /// <param name="freeCoefs">Массив свободных коэфициентов, где каждому i-тому элементу 
        /// соответсвует коэфициент для i-той переменной</param>
        /// <returns>Массив решений системы линейных алгребраических уравнений,
        /// в котором каждому i-тому элементу соответсвует корень
        /// для i-той независимой переменной</returns>
        public double[] GetRoots(double[] freeCoefs)
        {
            if ((LUmatrix != null) && (amountOfCols > 9))
            {
                return SystemSolve(freeCoefs);
            }
            else
            {
                SquareMatrix inverted = this.ReversedMatrix();

                double[,] tmp = new double[freeCoefs.Length, 1];

                for (int i = 0; i < freeCoefs.Length; i++)
                {
                    tmp[i, 0] = freeCoefs[i];
                }

                Matrix freeCoefsMatrix = new Matrix(tmp);
                Matrix res = inverted * freeCoefsMatrix;
                double[] result = new double[freeCoefs.Length];
                for (int i = 0; i < freeCoefs.Length; i++)
                {
                    result[i] = res[i, 0];
                }
                return result;
            }         
        }
        
    }

    /// <summary>
    /// Всмопогательный класс, определяющий необходимые методы для работы с двумерными массивами
    /// </summary>
    public static class Aux
    {
        /// <summary>
        /// Метод для выделения памяти и копирования текущего массива в новый
        /// </summary>
        /// <param name="array">Исходный массив</param>
        /// <returns>Копия исходного массива</returns>
        public static double[,] CopyArray(double[,] array)
        {
            int n = array.GetLength(0);
            int k = array.GetLength(1);
            double[,] result = new double[n, k];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < k; j++)
                    result[i, j] = array[i, j];
            return result;
        }
        /// <summary>
        /// Меняет местами 2 строки в массиве
        /// </summary>
        /// <param name="matrix">Массив для замены</param>
        /// <param name="first">Индекс первой строки</param>
        /// <param name="second">Индекс второй строки</param>
        public static void SwapRows(double[,] matrix, int first, int second)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double temp = matrix[second, i];
                matrix[second, i] = matrix[first, i];
                matrix[first, i] = temp;
            }
        }
    }
}
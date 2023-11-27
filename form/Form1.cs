using Microsoft.VisualBasic.Logging;
using System.Drawing;
using System.Drawing.Text;
using Test;

namespace form
{
    public partial class Form1 : Form
    {
        defaultMtrx deffMatrix;
        extraMatrix exMatrix;
        resultMatrix resMatrix;

        Matrix deffMtrx;
        Matrix exMtrx;

        private bool resMActivity = false;
        private bool exMActivity = false;
        public Form1()
        {
            InitializeComponent();
            deffMatrix = new defaultMtrx((3, 4));
            exMatrix = new extraMatrix();
            Controls.Add(deffMatrix.createMtrx());
            Size = new System.Drawing.Size(1300, 660);
            
            deffMtrx = new Matrix(deffMatrix.getMatrix());
            deffMatrix.fillMatrix.Click += eventFillRandomDeffMatrix;
            deffMatrix.getDeterm.Visible = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void gBDeffaultMatrix_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            if (chekOccupancy(exMatrix.txBx) && chekOccupancy(deffMatrix.txBx) && exMatrix.dimension.Item2 == 1 && exMatrix.dimension.Item1 == deffMatrix.dimension.Item1 && deffMatrix.squareMatrix)
            {
                if (resMActivity == true)
                    resMatrix.getObjectMatrix().Dispose();
                var defaultMatrix = new SquareMatrix(deffMatrix.getMatrix());
                double[] freeCoefs = new double[deffMatrix.dimension.Item2];
                double[,] result;
                for (int i = 0; i < freeCoefs.Length; i++)
                    freeCoefs[i] = exMatrix.getMatrix()[i,0];
                double[] tRes;
                tRes = defaultMatrix.GetRoots(freeCoefs);
                int t = tRes.Length;
                result = new double[t,1];
                for (int i = 0; i < tRes.Length; i++)
                    result[i, 0] = tRes[i];
                resMatrix = new resultMatrix(result, deffMatrix.getObjectMatrix().Location.Y + deffMatrix.getObjectMatrix().Height);
                Controls.Add(resMatrix.createMtrx());
                resMActivity = true;
            }
            else { MessageBox.Show("Невозможно подсчитать произведение!"); }
        }

        private void changeDefaultMatrix_Click(object sender, EventArgs e)
        {
            var propMtrx = new propMatrix(deffMatrix.dimension);
            propMtrx.Show();
            propMtrx.Disposed += PropMtrx_Disposed;
        }

        private void PropMtrx_Disposed(object? sender, EventArgs e)
        {
            if (deffMatrix.dimension == dataBank.dimension)
                return;
            int timeDim = deffMatrix.dimension.Item2;
            if (resMActivity == true)
            {
                resMatrix.getObjectMatrix().Dispose();
                resMActivity = false;
            }

            deffMatrix.getObjectMatrix().Dispose();
            deffMatrix = new defaultMtrx(dataBank.dimension);
            deffMatrix.createMtrx();
            Controls.Add(deffMatrix.getObjectMatrix());
            if (exMActivity == true)
            {
                int scaleLevel = (deffMatrix.dimension.Item2 - timeDim) > 0 ? (deffMatrix.dimension.Item2 - timeDim) : 0;
                exMatrix.gB.Location = new System.Drawing.Point(exMatrix.gB.Location.X + (35 * scaleLevel), exMatrix.gB.Location.Y);
            }
            if (deffMatrix.squareMatrix)
            {
                deffMtrx = new SquareMatrix(deffMatrix.getMatrix());
                deffMatrix.getDeterm.Visible = true;
                deffMatrix.getDeterm.Click += eventGetDetermDefaultMatrx;
            } else 
            { 
                deffMtrx = new Matrix(deffMatrix.getMatrix());
                deffMatrix.getDeterm.Visible = false;
            }
            deffMatrix.fillMatrix.Click += eventFillRandomDeffMatrix;

        }

        

        private void createNewMatrix_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            var createMatrix = new createExtrMatrix(name == "createNewMatrix" ? true : false);
            createMatrix.Show();
            createMatrix.Disposed += CreateMatrix_Disposed;

        }

        private void CreateMatrix_Disposed(object? sender, EventArgs e)
        {
            if (exMActivity == true)
            {
                if (exMatrix.dimension == dataBank.dimension)
                    return;
                exMatrix.getObjectMatrix().Dispose();
            }
            exMtrx = dataBank.dimension.Item2 == dataBank.dimension.Item1 ? new SquareMatrix() : new Matrix();
            exMatrix = new extraMatrix(dataBank.dimension, deffMatrix.getDemensions().Item1 + 240);
            exMatrix.createMtrx();
            Controls.Add(exMatrix.getObjectMatrix());
            createNewMatrix.Text = "Изменить доп. матрицу";
            delExtrMatrix.Visible = true;;
            exMActivity = true;
            if (resMActivity == true)
            {
                resMatrix.getObjectMatrix().Dispose();
                resMActivity = false;
            }
            if (exMatrix.squareMatrix)
            {
                exMtrx = new SquareMatrix(exMatrix.getMatrix());
                exMatrix.getDeterm.Visible = true;
                exMatrix.getDeterm.Click += eventGetDetermExtraMatrx;
            } else { exMtrx = new Matrix(exMatrix.getMatrix()); exMatrix.getDeterm.Visible = false; }
            exMatrix.fillMatrix.Click += eventFillRandomExtraMatrix;
        }


        private void delExtrMatrix_Click(object sender, EventArgs e)
        {
            exMatrix.getObjectMatrix().Dispose();
            exMatrix.dimension = (0, 0);
            createNewMatrix.Text = "Создать новую матрицу";
            delExtrMatrix.Visible = false;
            exMActivity = false;
            if (resMActivity == true)
            {
                resMatrix.getObjectMatrix().Dispose();
                resMActivity = false;
            }
        }
        private bool chekOccupancy(Control[,] control)
        {
            try
            {
                foreach (var item in control)
                {
                    if (item.Text == String.Empty)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (chekOccupancy(exMatrix.txBx) && chekOccupancy(deffMatrix.txBx) && deffMatrix.dimension == exMatrix.dimension)
            {
                if (resMActivity == true)
                    resMatrix.getObjectMatrix().Dispose();
                var defaultMatrix = new Matrix(deffMatrix.getMatrix());
                var extraMatrix = new Matrix(exMatrix.getMatrix());
                Matrix tRes;
                tRes = defaultMatrix + extraMatrix;
                resMatrix = new resultMatrix(tRes.GetMatrix, deffMatrix.getObjectMatrix().Location.Y + deffMatrix.getObjectMatrix().Height);
                Controls.Add(resMatrix.createMtrx());
                resMActivity = true;
            } else { MessageBox.Show("Невозможно выполнить сложение!"); }
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            if (chekOccupancy(exMatrix.txBx) && chekOccupancy(deffMatrix.txBx) && deffMatrix.dimension == exMatrix.dimension)
            {
                if (resMActivity == true)
                    resMatrix.getObjectMatrix().Dispose();
                var defaultMatrix = new Matrix(deffMatrix.getMatrix());
                var extraMatrix = new Matrix(exMatrix.getMatrix());
                Matrix tRes;
                tRes = defaultMatrix - extraMatrix;
                resMatrix = new resultMatrix(tRes.GetMatrix, deffMatrix.getObjectMatrix().Location.Y + deffMatrix.getObjectMatrix().Height);
                Controls.Add(resMatrix.createMtrx());
                resMActivity = true;
            }
            else { MessageBox.Show("Невозможно подсчитать разность!"); }
        }

        private void buttonMultMatrx_Click(object sender, EventArgs e)
        {
            if (chekOccupancy(exMatrix.txBx) && chekOccupancy(deffMatrix.txBx) && deffMatrix.dimension.Item1 == exMatrix.dimension.Item2)
            {
                if (resMActivity == true)
                    resMatrix.getObjectMatrix().Dispose();
                var defaultMatrix = new Matrix(deffMatrix.getMatrix());
                var extraMatrix = new Matrix(exMatrix.getMatrix());
                Matrix tRes;
                tRes = defaultMatrix * extraMatrix;
                resMatrix = new resultMatrix(tRes.GetMatrix, deffMatrix.getObjectMatrix().Location.Y + 10);
                Controls.Add(resMatrix.createMtrx());
                resMActivity = true;
            }
            else { MessageBox.Show("Невозможно подсчитать произведение!"); }
        }

        private void buttonMultNumb_Click(object sender, EventArgs e)
        {
            if (chekOccupancy(exMatrix.txBx) && chekOccupancy(deffMatrix.txBx) && exMatrix.dimension.Item1 == 1 && exMatrix.dimension.Item2 == 1)
            {
                if (resMActivity == true)
                    resMatrix.getObjectMatrix().Dispose();
                var defaultMatrix = new Matrix(deffMatrix.getMatrix());
                double extraMatrix = exMatrix.getMatrix()[0,0];
                Matrix tRes;
                tRes = defaultMatrix * extraMatrix;
                resMatrix = new resultMatrix(tRes.GetMatrix, deffMatrix.getObjectMatrix().Location.Y + deffMatrix.getObjectMatrix().Height);
                Controls.Add(resMatrix.createMtrx());
                resMActivity = true;
            }
            else { MessageBox.Show("Невозможно подсчитать произведение!"); }
        }

        private void buttonGetRevMatrx_Click(object sender, EventArgs e)
        {
            if (deffMatrix.squareMatrix)
            {
                if (exMActivity == false && chekOccupancy(deffMatrix.txBx) && (new SquareMatrix(deffMatrix.getMatrix())).Determinant() != 0.0)
                {
                    if (resMActivity == true)
                        resMatrix.getObjectMatrix().Dispose();
                    var defaultMatrix = new SquareMatrix(deffMatrix.getMatrix());
                    Matrix tRes;
                    tRes = defaultMatrix.ReversedMatrix();
                    resMatrix = new resultMatrix(tRes.GetMatrix, deffMatrix.getObjectMatrix().Location.Y + deffMatrix.getObjectMatrix().Height);
                    Controls.Add(resMatrix.createMtrx());
                    resMActivity = true;
                }
                else { MessageBox.Show("Невозможно получить обратную матрицу!"); }
            }
            else { MessageBox.Show("Невозможно получить обратную матрицу! Исходная матрица должна быть квадратной!"); }

        }
        private void eventFillRandomDeffMatrix(object sender, EventArgs e)
        {
            deffMtrx.FillRandom(1, 100);
            deffMatrix.fillMatrix(deffMtrx);
        }
        private void eventFillRandomExtraMatrix(object sender, EventArgs e)
        {
            exMtrx.FillRandom(1, 100);
            exMatrix.fillMatrix(exMtrx);
        }
        private void eventGetDetermDefaultMatrx(object sender, EventArgs e)
        {
            var tMtrx = new SquareMatrix(deffMatrix.getMatrix());
            MessageBox.Show(tMtrx.Determinant().ToString());
        }
        private void eventGetDetermExtraMatrx(object sender, EventArgs e)
        {
            var tMtrx = new SquareMatrix(exMatrix.getMatrix());
            MessageBox.Show(tMtrx.Determinant().ToString());
        }
    }
    class resultMatrix : mtrx
    {
        public override bool squareMatrix { get; }

        public override (int, int) dimension { get; set; }
        public override int determinant { get; set; }
        public override TextBox[,] txBx { get; set; }
        public override GroupBox gB { get; set; }
        public override (int width, int height) gBSize { get; }

        private double[,] mtrx;

        private int locYDeffMatrix;
        private (int x, int y) loc;
        public bool isEnable = false;
        public resultMatrix(double[,] mtrx, int locYDeffMatrix)
        {
            this.mtrx = mtrx;
            dimension = (mtrx.GetLength(0), mtrx.GetLength(1));
            squareMatrix = determSquare();
            txBx = new TextBox[dimension.Item1, dimension.Item2];
            loc = (5, 15);
            gBSize = ((dimension.Item2 > 3) ? 160 + (45 * (dimension.Item2 - 3)) : 175, 40 * dimension.Item1 + 70);
            this.locYDeffMatrix = locYDeffMatrix;
        }
        public override Control createMtrx()
        {
            gB = new GroupBox() { Size = new Size(gBSize.width, gBSize.height), Location = new System.Drawing.Point(260, locYDeffMatrix), Text = "Результат" };
            for (int i = 0; i < dimension.Item1; i++)
            {
                for (int j = 0; j < dimension.Item2; j++)
                {
                    txBx[i, j] = new TextBox()
                    {
                        Font = new Font("Times New Roman", 18, FontStyle.Bold),
                        Size = new Size(40, 40),
                        Location = new System.Drawing.Point(loc.x, loc.y),
                        Text = mtrx[i, j].ToString(),
                    };
                    loc.x += 45;
                    gB.Controls.Add(txBx[i, j]);
                }
                loc.y += 40;
                loc.x = 5;
            }
            isEnable = true;
            return gB;
        }
    }
    class extraMatrix : mtrx
    {
        public override bool squareMatrix { get; }

        public override (int, int) dimension { get; set; }
        public override int determinant { get; set; }
        public override TextBox[,] txBx { get; set; }
        public override GroupBox gB { get; set; }
        
        public override (int width, int height) gBSize { get; }

        public Button getDeterm { get; }
        public Button fillMatrix { get; }

        private (int x, int y) loc;
        private int locYDeffMatrix;
        public extraMatrix()
        {
            dimension = (0, 0);
        }
        public extraMatrix((int, int) dimension, int locYDeffMatrix)
        {
            this.dimension = dimension;
            squareMatrix = determSquare();
            txBx = new TextBox[dimension.Item1, dimension.Item2];
            loc = (5, 20);
            gBSize = ((dimension.Item2 > 3) ? 160 + (45 * (dimension.Item2 - 3)) : 175, 40 * dimension.Item1 + 70);
            this.locYDeffMatrix = locYDeffMatrix+50;
            fillMatrix = new Button()
            {
                Font = new Font("Times New Roman",
                14, FontStyle.Bold),
                Size = new Size(162, 52),
                Text = "Заполнить случайно"
            };

            getDeterm = new Button()
            {
                Font = new Font("Times New Roman",
                14, FontStyle.Bold),
                Size = new Size(162, 52),
                Text = "Получить детерминант"
            };
        }
        public override Control createMtrx()
        {

            gB = new GroupBox() { Size = new Size(gBSize.width, gBSize.height + 108), Location = new System.Drawing.Point(locYDeffMatrix, 12), Text = "Доп матрица" };
            for (int i = 0; i < dimension.Item1; i++)
            {
                for (int j = 0; j < dimension.Item2; j++)
                {
                    txBx[i, j] = new TextBox()
                    {
                        Font = new Font("Times New Roman",
                    18, FontStyle.Bold),
                        Size = new Size(40, 40),
                        Location = new System.Drawing.Point(loc.x, loc.y)
                    };
                    loc.x += 45;
                    gB.Controls.Add(txBx[i, j]);
                }
                loc.y += 45;
                loc.x = 5;
            }
            fillMatrix.Location = new System.Drawing.Point(loc.x, loc.y + 10);
            getDeterm.Location = new System.Drawing.Point(loc.x, fillMatrix.Location.Y + fillMatrix.Height);
            gB.Controls.Add(fillMatrix);
            gB.Controls.Add(getDeterm);
            return gB;
        }
    }
    class defaultMtrx : mtrx
    {
        public override bool squareMatrix { get; }
        public override (int, int) dimension { get; set; }
        public override int determinant { get; set; }
        public override TextBox[,] txBx { get; set; }
        public override (int width, int height) gBSize { get; }
        public override GroupBox gB { get; set; }
        public Button getDeterm { get; }
        public Button fillMatrix { get; }
        private (int x, int y) loc;
        
        public defaultMtrx((int,int) dimension)
        {
            this.dimension = dimension;
            squareMatrix = determSquare();
            txBx = new TextBox[dimension.Item1, dimension.Item2];
            loc = (10, 20);
            gBSize = ((dimension.Item2 > 3) ? 160 + (45 * (dimension.Item2 - 3)) : 175, 40 * dimension.Item1 + 70);
            fillMatrix = new Button()
            {
                Font = new Font("Times New Roman",
                14, FontStyle.Bold),
                Size = new Size(162, 52),
                Text = "Заполнить случайно"
            };
            
            getDeterm = new Button()
            {
                Font = new Font("Times New Roman",
                14, FontStyle.Bold),
                Size = new Size(162, 52),
                Text = "Получить детерминант"
            };
        }
        public override GroupBox createMtrx()
        {
            gB = new GroupBox() { Size = new Size(gBSize.width, gBSize.height + 108), Location = new System.Drawing.Point(260, 12), Text = "Матрица 1" };
            for (int i = 0; i < dimension.Item1; i++)
            {
                for (int j = 0; j < dimension.Item2; j++)
                {
                    txBx[i,j] = new TextBox() 
                    { Font = new Font("Times New Roman", 
                    18, FontStyle.Bold), 
                    Size = new Size(40, 40), 
                    Location = new System.Drawing.Point(loc.x, loc.y) };
                    loc.Item1 += 45;
                    gB.Controls.Add(txBx[i,j]);
                }
                loc.y += 45;
                loc.x = 10;
            }
            fillMatrix.Location = new System.Drawing.Point(loc.x, loc.y + 10);
            getDeterm.Location = new System.Drawing.Point(loc.x, fillMatrix.Location.Y + fillMatrix.Height);
            gB.Controls.Add(fillMatrix);
            gB.Controls.Add(getDeterm);
            return gB;
        }
    }
    abstract class mtrx
    {
        abstract public bool squareMatrix { get; }
        abstract public (int, int) dimension { get; set; }
        abstract public int determinant { get; set; }
        abstract public (int width, int height) gBSize { get; }
        abstract public TextBox[,] txBx { get; set; }
        abstract public GroupBox gB { get; set; }
        abstract public Control createMtrx();
        
        virtual public Control getObjectMatrix() 
        {
            return gB;
        }
        virtual public double[,] getMatrix()
        {
            var matrix = new double[dimension.Item1, dimension.Item2];
            for (int i = 0; i < dimension.Item1; i++)
            {
                for (int j = 0; j < dimension.Item2; j++)
                {
                    try
                    {
                        matrix[i, j] = Convert.ToDouble(txBx[i, j].Text);
                    }
                    catch (Exception)
                    {
                        matrix[i, j] = 0.0;
                    }
                    
                }
            }
            return matrix;
        }
        virtual public bool determSquare()
        {
            if (dimension.Item1 == dimension.Item2)
                return true;
            return false;
        }
        virtual public (int, int) getDemensions()
        {
            return (gBSize.width, gBSize.height);
        }
        virtual public void fillMatrix(Matrix mtrx)
        {
            double[,] values = mtrx.GetMatrix;
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    txBx[i,j].Text = values[i,j].ToString();
                }
            }
        }
    }

}
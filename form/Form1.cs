using Microsoft.VisualBasic.Logging;
using System.Drawing;
using Test;

namespace form
{
    public partial class Form1 : Form
    {
        defaultMtrx deffMatrix;
        extraMatrix exMatrix;
        resultMatrix resMatrix;

        private bool resMActivity = false;
        private bool exMActivity = false;
        public Form1()
        {
            InitializeComponent();
            deffMatrix = new defaultMtrx((3, 4));
            exMatrix = new extraMatrix();
            Controls.Add(deffMatrix.createMtrx());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void gBDeffaultMatrix_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }
        public static void changeForm((int, int) dimens)
        {
           
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


            deffMatrix.getObjectMatrix().Dispose();
            deffMatrix = new defaultMtrx(dataBank.dimension);
            deffMatrix.createMtrx();
            Controls.Add(deffMatrix.getObjectMatrix());
            if (exMActivity == true)
            {
                int scaleLevel = (deffMatrix.dimension.Item2 - timeDim) > 0 ? (deffMatrix.dimension.Item2 - timeDim) : 0;
                exMatrix.gB.Location = new System.Drawing.Point(exMatrix.gB.Location.X + (35 * scaleLevel), exMatrix.gB.Location.Y);
            }
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
                resMatrix = new resultMatrix(tRes.GetMatrix, deffMatrix.gBSize.height + 20);
                Controls.Add(resMatrix.createMtrx());
                resMActivity = true;
            } else { MessageBox.Show("Невозможно выполнить сложение!"); }
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {

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
            gBSize = ((dimension.Item2 > 3) ? 120 + (35 * (dimension.Item2 - 3)) : 120, 35 * dimension.Item1 + 50);
            this.locYDeffMatrix = locYDeffMatrix;
        }
        public override Control createMtrx()
        {
            int countElement = dimension.Item1 * dimension.Item2;

            gB = new GroupBox() { Size = new Size(gBSize.width, gBSize.height), Location = new System.Drawing.Point(220, locYDeffMatrix), Text = "Результат" };
            for (int i = 0; i < dimension.Item1; i++)
            {
                for (int j = 0; j < dimension.Item2; j++)
                {
                    txBx[i, j] = new TextBox()
                    {
                        Font = new Font("Times New Roman", 14, FontStyle.Bold),
                        Size = new Size(29, 29),
                        Location = new System.Drawing.Point(loc.x, loc.y),
                        Text = mtrx[i, j].ToString(),
                    };
                    loc.x += 35;
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
            loc = (5, 15);
            gBSize = ((dimension.Item2 > 3) ? 120 + (35 * (dimension.Item2 - 3)) : 120, 35 * dimension.Item1 + 50);
            this.locYDeffMatrix = locYDeffMatrix;
            
        }
        public override Control createMtrx()
        {
            int countElement = dimension.Item1 * dimension.Item2;

            gB = new GroupBox() { Size = new Size(gBSize.width, gBSize.height), Location = new System.Drawing.Point(locYDeffMatrix, 12), Text = "Доп матрица" };
            for (int i = 0; i < dimension.Item1; i++)
            {
                for (int j = 0; j < dimension.Item2; j++)
                {
                    txBx[i, j] = new TextBox()
                    {
                        Font = new Font("Times New Roman",
                    14, FontStyle.Bold),
                        Size = new Size(29, 29),
                        Location = new System.Drawing.Point(loc.x, loc.y)
                    };
                    loc.x += 35;
                    gB.Controls.Add(txBx[i, j]);
                }
                loc.y += 40;
                loc.x = 5;
            }
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
        private (int x, int y) loc;
        
        public defaultMtrx((int,int) dimension)
        {
            this.dimension = dimension;
            squareMatrix = determSquare();
            txBx = new TextBox[dimension.Item1, dimension.Item2];
            loc = (5, 15);
            gBSize = ((dimension.Item2 > 3) ? 120 + (35 * (dimension.Item2 - 3)) : 120, 35 * dimension.Item1 + 50);
        }
        public override GroupBox createMtrx()
        {
            int countElement = dimension.Item1 * dimension.Item2;
            
            gB = new GroupBox() { Size = new Size(gBSize.width, gBSize.height), Location = new System.Drawing.Point(220, 12), Text = "Стандартная матрица" };
            for (int i = 0; i < dimension.Item1; i++)
            {
                for (int j = 0; j < dimension.Item2; j++)
                {
                    txBx[i,j] = new TextBox() 
                    { Font = new Font("Times New Roman", 
                    14, FontStyle.Bold), 
                    Size = new Size(29, 29), 
                    Location = new System.Drawing.Point(loc.x, loc.y) };
                    loc.Item1 += 35;
                    gB.Controls.Add(txBx[i,j]);
                }
                loc.y += 40;
                loc.x = 5;
            }
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
                    matrix[i, j] = Convert.ToDouble(txBx[i, j].Text);
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
    }

}
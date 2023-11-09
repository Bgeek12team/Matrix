using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form
{
    public partial class createExtrMatrix : Form
    {
        public createExtrMatrix(bool itention)
        {
            InitializeComponent();
            button1.Text = itention ? "Создать" : "Пересоздать";
            label1.Text = itention ? "Создание матрицы" : "Размер матрицы";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) <= 0 || int.Parse(textBox2.Text) <= 0)
            {
                errorProvider1.SetError(button1, "Нельзя меньше нуля");
            }
            else
            {
                dataBank.dimension = (int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                this.Close();
            }
        }
    }
}

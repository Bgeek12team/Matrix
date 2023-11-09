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
    public partial class propMatrix : Form
    {
        (int, int) dimension;
        public propMatrix((int, int) dimension)
        {
            InitializeComponent();
            this.dimension = dimension;
            textBox1.Text = dimension.Item1.ToString();
            textBox2.Text = dimension.Item2.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) <= 0 || int.Parse(textBox2.Text) <= 0)
            {
                errorProvider1.SetError(createOrChange, "Нельзя меньше нуля");
            } 
            else
            {
                dataBank.dimension = (int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                this.Close();
            }
        }
    }
}

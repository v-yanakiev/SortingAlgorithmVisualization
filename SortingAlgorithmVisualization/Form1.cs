using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingAlgorithmVisualization
{
    public partial class Form1 : Form
    {
        private Random random;
        const int sizeOfData = 10;
        public int[] arrayToSort;
        public Form1()
        {
            InitializeComponent();
            this.random = new Random();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < sizeOfData; i++)
            {
                stringBuilder.Append(random.Next(1,1000));
                if (i != sizeOfData - 1)
                    stringBuilder.Append(", ");
            }
            textBox1.Text = stringBuilder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text.Trim() == "")
            {
                return;
            }
            try
            {
                arrayToSort = textBox1.Text.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).
                    Select(a => int.Parse(a)).ToArray();
            }
            catch
            {
                return;
            }
            Form2 form2 = new Form2(this);
            this.Hide();
            form2.Show();
            
        }
    }
}

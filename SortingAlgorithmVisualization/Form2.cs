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
    public partial class Form2 : Form
    {
        private Form1 callingForm;
        private int[] arrayToSort;
        List<Label> labels;
        int i, j,indexOfCurrentMinimum;
        private bool delay;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 form1)
            : this()
        {
            this.callingForm = form1;
            this.arrayToSort = form1.arrayToSort;
            this.labels = new List<Label>();
            int locationX = 30;
            int locationY = 0;
            foreach (var number in callingForm.arrayToSort)
            {
                Label label = new Label();

                label.Text = string.Format("{0,3:###}",number);
                label.Location = new Point(locationX, locationY);
                label.AutoSize = true;
                label.Font = new Font("Courier", 18);
                label.ForeColor = Color.Black;
                label.Padding = new Padding(10);
                label.BorderStyle = BorderStyle.FixedSingle;
                locationX += 70;
                this.Controls.Add(label);
                this.labels.Add(label);
            }
            i=0;
            j = i + 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (delay)
            {
                delay = false;
            } 
            else
            {
                if (j >= arrayToSort.Length && i >= (arrayToSort.Length - 1))
                {
                    labels[labels.Count - 1].BackColor = Color.Green;
                    return;
                }
                if (labels[j - 1].BackColor != Color.LightGreen && labels[j - 1].BackColor != Color.OrangeRed)
                {
                    labels[j - 1].BackColor = Color.Transparent;
                }
                if (j == i + 1)
                {

                    indexOfCurrentMinimum = i;
                    labels[i].BackColor = Color.OrangeRed;
                }
                labels[j].BackColor = Color.LightBlue;
                if (arrayToSort[j] < arrayToSort[indexOfCurrentMinimum])
                {
                    if (labels[indexOfCurrentMinimum].BackColor == Color.LightGreen)
                    {
                        labels[indexOfCurrentMinimum].BackColor = Color.Transparent;
                    }
                    indexOfCurrentMinimum = j;
                    labels[indexOfCurrentMinimum].BackColor = Color.LightGreen;
                }
                j++;
                if (j == arrayToSort.Length)
                {
                    delay = true;
                    return;
                }
            }

            if (j == arrayToSort.Length)
            {
                if (i != arrayToSort.Length - 1)
                {
                    labels[indexOfCurrentMinimum].BackColor = Color.Transparent;
                }
                labels[labels.Count - 1].BackColor = Color.Transparent;
                int temp = arrayToSort[indexOfCurrentMinimum];
                arrayToSort[indexOfCurrentMinimum] = arrayToSort[i];
                labels[indexOfCurrentMinimum].Text = string.Format("{0,3:###}", arrayToSort[i]);
                arrayToSort[i] = temp;
                labels[i].Text = string.Format("{0,3:###}", temp);
                labels[i].BackColor = Color.Green;
                i++;
                j = i + 1;
            }
        }
    }
}

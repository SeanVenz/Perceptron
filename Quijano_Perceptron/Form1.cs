using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Quijano_Perceptron
{
    public partial class Quijano_Perceptron : Form
    {
        Perceptron perceptron;
        public Quijano_Perceptron()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int input1 = Convert.ToInt32(textBox1.Text);
            int input2 = Convert.ToInt32(textBox2.Text);
            int numOfEpochs = Convert.ToInt32(textBox3.Text);
            // Example usage
            perceptron = new Perceptron(numInputs: 2);
            double[][] inputs = new double[][]
            {
                new double[] { 0, 0 },
                new double[] { 0, 1 },
                new double[] { 1, 0 },
                new double[] { 1, 1 }
            };
            int[] targets = new int[] { 0, 1, 1, 1 };
            perceptron.Train(inputs, targets, numOfEpochs);
            string output = perceptron.Predict(new double[] { input1, input2 }).ToString(); // Output: 0
            label1.Text = output;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

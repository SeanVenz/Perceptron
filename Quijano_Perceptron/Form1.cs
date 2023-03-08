using System;
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
            //get inputs from user
            int input1 = Convert.ToInt32(textBox1.Text);
            int input2 = Convert.ToInt32(textBox2.Text);
            int numOfEpochs = Convert.ToInt32(textBox3.Text);

            //application of perceptron codes
            perceptron = new Perceptron(numInputs: 2);
            double[][] inputs = new double[][]
            {
                new double[] { 0, 0 },
                new double[] { 0, 1 },
                new double[] { 1, 0 },
                new double[] { 1, 1 }
            };
            //set target
            int[] targets = new int[] { 0, 1, 1, 1 };

            //train perceptron
            perceptron.Train(inputs, targets, numOfEpochs);

            //get output
            string output = perceptron.Predict(new double[] { input1, input2 }).ToString();

            //show output
            label1.Text = output;
        }
    }
}

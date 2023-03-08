using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quijano_Perceptron
{
    public class Perceptron
    {
        private double[] weights;
        private double bias;
        private double learningRate;

        public Perceptron(int numInputs, double learningRate = 0.1)
        {
            // Initialize weights randomly between -1 and 1
            weights = new double[numInputs];
            var rnd = new Random();
            for (int i = 0; i < numInputs; i++)
            {
                weights[i] = rnd.NextDouble() * 2 - 1;
            }

            // Initialize bias to 0
            bias = 0;

            // Set learning rate
            this.learningRate = learningRate;
        }

        public int Predict(double[] inputs)
        {
            double weightedSum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                weightedSum += weights[i] * inputs[i];
            }
            weightedSum += bias;
            return weightedSum >= 0 ? 1 : 0;
        }

        public void Train(double[][] inputs, int[] targets, int numEpochs)
        {
            for (int epoch = 0; epoch < numEpochs; epoch++)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    double prediction = Predict(inputs[i]);
                    double error = targets[i] - prediction;
                    for (int j = 0; j < weights.Length; j++)
                    {
                        weights[j] += learningRate * error * inputs[i][j];
                    }
                    bias += learningRate * error;
                }
            }
        }
    }
}

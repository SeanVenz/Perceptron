using System;

namespace Quijano_Perceptron
{
    public class Perceptron
    {
        private double[] weights;
        private double bias;
        private double learningRate;

        /// <summary>
        /// Constructor initialization
        /// </summary>
        /// <param name="numInputs">how many inputs the user wants</param>
        /// <param name="learningRate">learning rate, small learning rate is good</param>
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

        /// <summary>
        /// Predicts the output for the given inputs.
        /// </summary>
        /// <param name="inputs">an array of inputs</param>
        /// <returns>predicted output</returns>
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

        /// <summary>
        /// Trains the perceptron for a single epoch.
        /// </summary>
        /// <param name="inputs">input from the user</param>
        /// <param name="targets">the target output of the perceptron</param>
        /// <param name="numEpochs">how many epochs the model is trained</param>
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

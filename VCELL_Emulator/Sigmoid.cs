using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace VCELL_Emulator
{
    [Serializable]
    public class Sigmoid
    {
        private static readonly System.Random _random = new();

        public float[][] values;
        public float[][][] weights;
        public float[][] biases;

        public float[][] desiredValues;
        private static int x;
        private const float epsilon = 0.005f;
        private const float learnRate = 1f;

        public Sigmoid(IReadOnlyList<int> structure)
        {
            values = new float[structure.Count][];
            desiredValues = new float[structure.Count][];
            biases = new float[structure.Count][];
            weights = new float[structure.Count - 1][][];

            for (int i = 0; i < structure.Count; i++)
            {
                values[i] = new float[structure[i]];
                desiredValues[i] = new float[structure[i]];
                biases[i] = new float[structure[i]];
            }

            for(int i = 0; i < structure.Count; i++)
            {
                weights[i] = new float[values[i + 1].Length][];
                for(var j = 0; j < weights[i].Length; j++)
                {
                    weights[i][j] = new float[values[i].Length];
                    for(var k = 0; k < weights[i][j].Length; k++)
                    {
                        double lity = new Random().NextDouble()
                            * Math.Sqrt(2f / weights[i][j][k]);
                        weights[i][j][k] = (float)lity;
                    }
                }
            }
        }
        //public float Sum(IEnumerable<float> value, IReadOnlyList<float> weights)
        //{
        //    int i = 0;
        //    if (value is null)
        //    {
        //        throw new ArgumentNullException(nameof(value));
        //    }
        //    return weights[i] * value;
        //}

        private static float SigmoidL(float x) =>
            1f / (1f + (float)Math.Exp(-x));

        private static float HardSigmoid(float x) // conditional for output
        {
            if (x < -2.5f)
                return 0;
            if (x > 2.5f)
                return 1;
            return 0.2f * x + 0.5f; 
        }

        public void Train(float[][] trainingInputs, 
            float[][] trainingOutputs)
        {
            for(var i = 0; i < trainingInputs.Length; i++)
            {
                for(int j = 0; j < desiredValues
                    [desiredValues.Length - 1].Length; j++)
                {
                    desiredValues[desiredValues.Length - 1]
                        [j] = trainingInputs[i][j];
                }
            }

            for (var i = values.Length - 1; i >=1; i++)
            {
                for (var j = 0; j <
                    values[i].Length; j++)
                {
                    biases[i][j] +=
                        HardSigmoid(values[i][j])
                        * learnRate;
                    biases[i][j] 
                        *= 1 - epsilon;

                    for(var k = 0; k < 
                        weights[i - 1].Length; k++)
                    {
                        weights[i - 1][j][k] +=
                            weights[i - 1][j][k] * learnRate;
                        weights[i - 1][j][k] *= 1 - epsilon;
                    }

                    desiredValues[i][j] = 0;
                }
            }
        }

        private static float SigmoidDerivative() => x * (1 - x);
    }
}
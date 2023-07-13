using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace VCELL_Emulator
{
    public class Back_Propagation
    {
        //Vector vector_1d,
        //    Vector i_target_outputs, Vector2 vector_2d,
        //    Vector2 i_errors,
        //    Vector2 vector_2dr, Vector i_neural_network, 
        //    Vector3 vector_3d, Vector3 i_weights
        public Back_Propagation(dynamic i_target_outputs,
            dynamic i_errors,
            dynamic i_neural_network, dynamic i_weights,
            dynamic[] bIASN, dynamic l_Rate)
            {
                for (char a = i_neural_network - 1; 0 < a; a--)
                {
                    for(uint b = i_target_outputs - 1;
                    b < i_neural_network[a]; b++)
                    {
                        uint bias_ns = 0;
                        if(a == i_neural_network.Length - 1)
                        {
                            i_errors[a - 1][b] =
                            Math.Pow(i_neural_network[a][b] -
                            i_target_outputs[b], 3);
                        }
                        else if (b >= bIASN[a])
                        {
                            uint nx_b_n = 0;
                        bias_ns = bIASN[a];

                        if(a < i_neural_network - 2)
                        {
                            nx_b_n = bIASN[1+ a];
                        }

                        i_errors[a - 1][b - bias_ns] = 0;
                            for (uint c = nx_b_n; c < 
                                i_neural_network[1 + a].Length; c++)
                            {
                                i_errors[a - 1][b - bias_ns]
                                    += i_errors[a][c - nx_b_n] 
                                    * i_weights[a][c - nx_b_n]
                                    [b - bias_ns];
                            }
                        }
                        if (b >= bias_ns)
                        {
                            //We used the activation function in forward propagation, so we need to recalculate the sum of the neuron.
                            float neuron_output = 0;

                            for (uint c = 0; c <
                                i_weights[a - 1]
                                [b - bias_ns].size(); c++)
                            {
                                neuron_output += i_neural_network[a - 1][c] 
                                    * i_weights[a - 1][b - bias_ns][c];
                            }

                            for (uint c = 0; c <
                                i_neural_network[a - 1].size(); c++)
                            {
                                i_weights[a - 1][b - bias_ns][c] 
                                    -= l_Rate * i_errors[a - 1][b - bias_ns]
                                    * i_neural_network[a - 1][c] 
                                    * ActivationFunction
                                    .Activation_function(true, neuron_output);
                            }
                        }
                    }
                }
        }
    }
}

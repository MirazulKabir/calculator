using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public class Multiply_ButtonCommand : ButtonCommand
    {
        public override void Command()
        {
            executioner.CommandExecutioner(SendButtonSign, Multiplication);
        }

        // Func<double, double, double>
        public double Multiplication(double x, double y)
        {
            return x * y;
        }
    }
}
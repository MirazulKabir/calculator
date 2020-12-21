using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public class Minus_ButtonCommand : ButtonCommand
    {
        public override void Command()
        {
            executioner.CommandExecutioner(SendButtonSign, Subtraction);
        }

        // Func<double, double, double>
        public double Subtraction(double x, double y)
        {
            return x - y;
        }
    }
}
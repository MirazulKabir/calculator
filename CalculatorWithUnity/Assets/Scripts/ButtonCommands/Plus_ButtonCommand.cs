using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public class Plus_ButtonCommand : ButtonCommand
    {
        public override void Command()
        {
            executioner.CommandExecutioner(SendButtonSign, Addition);
        }

        // Func<double, double, double>
        public double Addition(double x, double y)
        {
            return x + y;
        }
    }
}
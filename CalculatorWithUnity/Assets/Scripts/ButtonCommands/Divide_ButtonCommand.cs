using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public class Divide_ButtonCommand : ButtonCommand
    {
        public override void Command()
        {
            executioner.CommandExecutioner(SendButtonSign, Division);
        }

        // Func<double, double, double>
        public double Division(double x, double y)
        {
            if(y == 0)
            {
                Debug.LogError("Cannot be divided by zero");
                return Mathf.Infinity;
            }

            return x / y;
        }
    }
}
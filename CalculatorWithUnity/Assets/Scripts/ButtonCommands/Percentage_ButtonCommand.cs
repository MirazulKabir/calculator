using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public class Percentage_ButtonCommand : ButtonCommand
    {
        public override void Command()
        {
            executioner.CommandExecutioner(SendButtonSign, Percentage);
        }

        public double Percentage(double x)
        {
            return x / 100;
        }
    }
}
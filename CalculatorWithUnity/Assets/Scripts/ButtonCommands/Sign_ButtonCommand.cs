using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public class Sign_ButtonCommand : ButtonCommand
    {
        public override void Command()
        {
            executioner.CommandExecutioner(SendButtonSign, SignInverter);
        }

        public double SignInverter(double x)
        {
            return -x;
        }
    }
}
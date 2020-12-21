using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public abstract class CalculationHandler : MonoBehaviour, ICommandExecutioner
    {
        static ICommandExecutioner executioner;

        protected virtual void Awake()
        {
            executioner = this;
        }

        public static ICommandExecutioner GetCommandExecutioner()
        {
            return executioner;
        }

        public abstract void CommandExecutioner(Func<string> execute);

        public abstract void CommandExecutioner(Func<string> sign, Func<double, double> execute);

        public abstract void CommandExecutioner(Func<string> sign, Func<double, double, double> execute);

    }
}
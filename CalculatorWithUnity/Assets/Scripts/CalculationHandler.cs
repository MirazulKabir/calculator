using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public class CalculationHandler : MonoBehaviour
    {
        ICalculationMode calculationMode;
        bool isDisplayUpdateRequired = false;

        // Start is called before the first frame update
        void Start()
        {
            calculationMode = GetComponent<ICalculationMode>();
        }

        private void Update()
        {
            if(isDisplayUpdateRequired)
            {
                // Do the display update
            }
        }

        public void CommandExecutioner(Action Execute)
        {
            Execute();
        }

        public void CommandExecutioner(Action<double> Execute)
        {
            Execute(1);
        }

        public void CommandExecutioner(Action<double, double> Execute)
        {
            Execute(1, 2);
        }
    }
}
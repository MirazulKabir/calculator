using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator
{
    public class ButtonCommand : MonoBehaviour, ICommand
    {
        string buttonSign;
        protected ICommandExecutioner executioner;

        void Start()
        {
            buttonSign = GetComponentInChildren<Text>().text;
            executioner = CalculationHandler.GetCommandExecutioner();
        }

        public virtual void Command()
        {
            executioner.CommandExecutioner(SendButtonSign);
        }

        public string SendButtonSign()
        {
            return buttonSign;
        }
    }
}
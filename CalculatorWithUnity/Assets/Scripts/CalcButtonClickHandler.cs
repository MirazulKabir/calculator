using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public class CalcButtonClickHandler : MonoBehaviour
    {
        ICommand commandInterface;

        private void Start()
        {
            commandInterface = GetComponent<ICommand>();
        }

        public void ButtonOnClick()
        {
            commandInterface.Command();
        }
    }
}
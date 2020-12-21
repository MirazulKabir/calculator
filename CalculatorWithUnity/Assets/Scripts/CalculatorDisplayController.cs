using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator
{
    public class CalculatorDisplayController : MonoBehaviour
    {
        [SerializeField] Text displayText;
        [SerializeField] Text inputHistoryText;

        public void UpdateDisplay(string str)
        {
            displayText.text = str;
        }

        public void UpdateInputHistory(string str)
        {
            inputHistoryText.text = str;
        }
    }
}
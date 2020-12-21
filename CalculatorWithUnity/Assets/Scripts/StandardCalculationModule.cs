using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Calculator
{
    public class StandardCalculationModule : CalculationHandler
    {
        StringBuilder currentNumString = new StringBuilder(256);
        string inputHistoryString, displayString, lastOperatorSign, lastDigit;
        double currentNum, resultNum;

        bool isDecimal = false;
        bool hasEqualed = false;

        Func<double, double, double> storedBinaryOperation = null;

        CalculatorDisplayController displayController;

        void Start()
        {
            displayController = FindObjectOfType<CalculatorDisplayController>();

            currentNum = resultNum = 0;
            currentNumString.Clear();
            lastOperatorSign = lastDigit = null;

            UpdateDisplayString("0");
            UpdateInputHistoryString("0");
        }

        #region CALCULATION_MODULATION
        public override void CommandExecutioner(Func<string> getSign)
        {
            if (getSign.Invoke().Equals("="))
            {
                OnEqualOperation();
            }
            else if (getSign.Invoke().ToLower().Equals("ce"))
            {
                OnClearCurrentOperation();
            }
            else if (getSign.Invoke().ToLower().Equals("c"))
            {
                OnAllClearOperation();
            }
            else // for digits only
            {
                lastDigit = getSign?.Invoke();
                
                if(hasEqualed)
                {
                    currentNum = 0;
                    currentNumString.Clear();
                    isDecimal = false;
                    hasEqualed = false;

                    if (lastOperatorSign != null)
                    {
                        UpdateInputHistoryString(resultNum.ToString() + " " + lastOperatorSign);
                    }
                }

                if (lastDigit.Equals("0") && currentNumString.ToString().Equals(""))
                {
                    return;
                }
                else if (lastDigit.Equals("."))
                {
                    if (!isDecimal)
                    {
                        currentNumString.Append(currentNum.ToString() + ".");
                        isDecimal = true;
                    }
                }
                else
                {
                    currentNumString.Append(lastDigit);
                    currentNum = double.Parse(currentNumString.ToString());
                    UpdateDisplayString(currentNumString.ToString());
                }
            }
        }

        public override void CommandExecutioner(Func<string> getSign, Func<double, double> execute)
        {
            if (currentNum == 0)
            {
                return;
            }

            if (currentNum != 0)
            {
                currentNum = execute.Invoke(currentNum);
                currentNumString.Clear();
                currentNumString.Append(currentNum.ToString());

                isDecimal = currentNum % 1 == 0 ? false : true;

                UpdateDisplayString(currentNumString.ToString());
            }
        }

        public override void CommandExecutioner(Func<string> getSign, Func<double, double, double> execute) // For Binary Operators
        {
            if(resultNum == 0 && currentNum == 0)
            {
                return;
            }

            if (resultNum == 0 && currentNum != 0)
            {
                lastOperatorSign = getSign?.Invoke();

                resultNum = currentNum;
                currentNum = 0;
                currentNumString.Clear();
                isDecimal = false;

                storedBinaryOperation = execute;

                UpdateInputHistoryString(resultNum.ToString() + " " + lastOperatorSign);
            }
            else if (resultNum != 0 && currentNum == 0)
            {
                lastOperatorSign = getSign?.Invoke();

                storedBinaryOperation = execute;

                UpdateInputHistoryString(resultNum.ToString() + " " + lastOperatorSign);
            }
            else if (resultNum != 0 && currentNum != 0)
            {
                lastOperatorSign = getSign?.Invoke();

                if (storedBinaryOperation != null)
                {
                    resultNum = storedBinaryOperation.Invoke(resultNum, currentNum);

                    currentNum = 0;
                    currentNumString.Clear();
                    storedBinaryOperation = execute;
                    isDecimal = false;

                    UpdateDisplayString(resultNum.ToString());
                    UpdateInputHistoryString(resultNum.ToString() + " " + lastOperatorSign);
                }
            }
        }
        #endregion


        public void OnEqualOperation()
        {
            if (storedBinaryOperation != null)
            {
                resultNum = storedBinaryOperation.Invoke(resultNum, currentNum);
                hasEqualed = true;

                UpdateDisplayString(resultNum.ToString());
                UpdateInputHistoryString(resultNum.ToString() + " " + lastOperatorSign + " " + currentNum + " =");
            }
        }

        public void OnClearCurrentOperation()
        {
            currentNum = 0;
            currentNumString.Clear();
            isDecimal = false;

            UpdateDisplayString("0");
            
            if(lastOperatorSign != null)
            {
                UpdateInputHistoryString(resultNum.ToString() + " " + lastOperatorSign);
            }
            else
            {
                UpdateInputHistoryString(resultNum.ToString());
            }
        }

        public void OnAllClearOperation()
        {
            resultNum = currentNum = 0;
            currentNumString.Clear();
            isDecimal = false;
            lastOperatorSign = null;

            UpdateDisplayString("0");
            UpdateInputHistoryString("0");
        }

        
        public void UpdateDisplayString(string str)
        {
            displayString = str;
            displayController.UpdateDisplay(displayString);
        }

        public void UpdateInputHistoryString(string str)
        {
            inputHistoryString = str;
            displayController.UpdateInputHistory(inputHistoryString);
        }

        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public class CalcButtonClickHandler : MonoBehaviour
    {
        public void ButtonOnClick()
        {
            Debug.Log("Button Clicked " + gameObject.name);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class CalcAndCompare : MonoBehaviour
{
    [SerializeField] private InputField firstCalcValue;
    [SerializeField] private InputField secondCalcValue;
    public Text resultCalculatorValue;
    public string firstValue;
    public string secondValue;

    int resultCalcValue;

    [SerializeField] private InputField firstCompareValue;
    [SerializeField] private InputField secondCompareValue;
    public Text resultCompareValue;

    public void Compare()
    {
        int firstValue = Convert.ToInt32(firstCompareValue.text);
        int secondValue = Convert.ToInt32(secondCompareValue.text);
        string result;

        if (firstValue == secondValue)
        {
            result = "Значения равны!";
            resultCompareValue.text = result;
        }

        if (firstValue > secondValue)
        {
            result = "Первое значение больше второго!";
            resultCompareValue.text = result;
        }

        if (firstValue < secondValue)
        {
            result = "Второе значение больше первого!";
            resultCompareValue.text = result;
        }
    }

    public void Sum()
    {
        firstValue = firstCalcValue.text;
        secondValue = secondCalcValue.text;
        resultCalcValue = Convert.ToInt32(firstValue) + Convert.ToInt32(secondValue);
        resultCalculatorValue.text = resultCalcValue.ToString();

    }

    public void Minus()
    {
        firstValue = firstCalcValue.text;
        secondValue = secondCalcValue.text;
        resultCalcValue = Convert.ToInt32(firstValue) - Convert.ToInt32(secondValue);
        resultCalculatorValue.text = resultCalcValue.ToString();

    }

    public void Multiply()
    {
        firstValue = firstCalcValue.text;
        secondValue = secondCalcValue.text;
        resultCalcValue = Convert.ToInt32(firstValue) * Convert.ToInt32(secondValue);
        resultCalculatorValue.text = resultCalcValue.ToString();

    }

    public void Divide()
    {
        firstValue = firstCalcValue.text;
        secondValue = secondCalcValue.text;
        double resultCalcValue = Convert.ToDouble(firstValue) / Convert.ToDouble(secondValue);
        resultCalcValue = Math.Round(resultCalcValue, 2);
        resultCalculatorValue.text = resultCalcValue.ToString();

    }



}

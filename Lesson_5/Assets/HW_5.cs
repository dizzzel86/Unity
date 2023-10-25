using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class HW_5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*Сумма чётных чисел заданного диапазона  от 7 до 21*/
        Debug.Log("Сумма четных чисел диапазона:");
        SumOfValues();

        /*Сумма чётных чисел в заданном массиве (81, 22, 13, 54, 10, 34, 15, 26, 71, 68)*/
        int[] arr = new int[] { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
        Debug.Log("Сумма четных чисел массива:");
        Debug.Log(SumOfArrValues(arr));

        /*Индекс первого вхождения числа в массив*/
        int value_1 = 34;
        int value_2 = 55;
        Debug.Log("Индекс вхождения числа 34:");
        Debug.Log(IndexOfArrValue(value_1));
        Debug.Log("Индекс вхождения числа 55:");
        Debug.Log(IndexOfArrValue(value_2));

        /*Сортировка выбором*/
        int[] sortArr = new int[10];
        sortArr = FillArray(sortArr);
        Debug.Log("Изначальный массив:");
        PrintArr(sortArr);
        sortArr = ChooseSort(sortArr);
        Debug.Log("Отсортированный массив:");
        PrintArr(sortArr);
    }


    private static void SumOfValues()
    {
        int sum = 0;
        for (int i = 7; i < 22; i++)
        {
            if (i % 2 == 0)
            {
                sum += i;
            }
        }

        Debug.Log(sum);
    }

    private int SumOfArrValues(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0)
            {
                sum += arr[i];
            }
        }
        return sum;
    }

    private int IndexOfArrValue(int indexValue)
    {
        int[] arr = new int[] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        int index = 0;
        for (int i = 0; i < arr.Length; ++i)
        {
            if (arr[i] == indexValue)
            {
                index = i;
                break;
            }

            else
            {
                index = -1;
            }
        }
        return index;

    }

    private int[] ChooseSort(int[] arr)
    {
        int min;
        int temp;

        for (int i = 0; i < arr.Length; ++i)
        {
            min = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }
            temp = arr[min];
            arr[min] = arr[i];
            arr[i] = temp;
        }
        return arr;
    }

    private int[] FillArray(int[] arr)
    {
        Random random = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(0, 11);
        }
        return arr;
    }

    private void PrintArr(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Debug.Log(arr[i]);
        }
    }

}

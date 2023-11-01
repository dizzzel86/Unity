using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CrackerGameScript : MonoBehaviour
{
    [SerializeField] private Text leftLockText;
    [SerializeField] private Text middleLockText;
    [SerializeField] private Text rightLockText;
    [SerializeField] private Text errorText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text victoryText;
    [SerializeField] private Text gameOver;
    [SerializeField] private GameObject firstScreen;
    [SerializeField] private GameObject secondScreen;
    [SerializeField] private GameObject thirdScreen;
    [SerializeField] private GameObject fourthScreen;
    private int leftLockValue = 5;
    private int middleLockValue = 5;
    private int rightLockValue = 5;

    private float timerTextValue = 60f;
    private GameObject currentScreen;





    // Start is called before the first frame update
    void Start()
    {
        firstScreen.SetActive(true);
        currentScreen = firstScreen;
        timerText.text = timerTextValue.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        if (timerTextValue > 0f)
        {
            timerTextValue -= Time.deltaTime;
            timerText.text = Mathf.Round(timerTextValue).ToString();
        }
        if (timerTextValue <= 0f)
        {
            GameOver();
            SetDefaultLockValues();
            ChangeViewLockToDefault();
        }
        if (leftLockValue == 7 && middleLockValue == 7 && rightLockValue == 7)
        {
            Victory();
            SetDefaultLockValues();
            ChangeViewLockToDefault();
        }
    }
    public void LeftButtonClick()
    {
        int resultLeft = GetLeftLockValue() + 3;
        int resultMiddle = GetMiddleLockValue() - 1;
        int resultRight = GetRightLockValue() + 5;
        if (resultLeft <= 10 && resultLeft >= 0)
        {
            leftLockText.text = resultLeft.ToString();
            SetLeftLockValue();
        }
        else if (resultLeft > 10)
        {
            ChangeScreen(secondScreen);
            leftLockText.text = "10";
            SetLeftLockValue();
            ErrorValue();
        }
        else if (resultLeft < 0)
        {
            ChangeScreen(secondScreen);
            leftLockText.text = "0";
            SetLeftLockValue();
        }

        if (resultMiddle <= 10 && resultMiddle >= 0)
        {
            middleLockText.text = resultMiddle.ToString();
            SetMiddleLockValue();
        }
        else if (resultMiddle > 10)
        {
            ChangeScreen(secondScreen);
            middleLockText.text = "10";
            SetMiddleLockValue();
            ErrorValue();
        }
        else if (resultMiddle < 0)
        {
            ChangeScreen(secondScreen);
            middleLockText.text = "0";
            SetMiddleLockValue();
            ErrorValue();
        }


        if (resultRight <= 10 && resultRight >= 0)
        {
            rightLockText.text = resultRight.ToString();
            SetRightLockValue();
        }
        else if (resultRight > 10)
        {
            ChangeScreen(secondScreen);
            rightLockText.text = "10";
            SetRightLockValue();
            ErrorValue();
        }
        else if (resultRight < 0)
        {
            ChangeScreen(secondScreen);
            rightLockText.text = "0";
            SetRightLockValue();
            ErrorValue();
        }


    }
    public void MiddleButtonClick()
    {
        int resultLeft = GetLeftLockValue() + 1;
        int resultMiddle = GetMiddleLockValue() + 1;
        int resultRight = GetRightLockValue() - 2;
        if (resultLeft <= 10 && resultLeft >= 0)
        {
            leftLockText.text = resultLeft.ToString();
            SetLeftLockValue();
        }
        else if (resultLeft > 10)
        {
            ChangeScreen(secondScreen);
            leftLockText.text = "10";
            SetLeftLockValue();
            ErrorValue();
        }
        else if (resultLeft < 0)
        {
            ChangeScreen(secondScreen);
            leftLockText.text = "0";
            SetLeftLockValue();
        }

        if (resultMiddle <= 10 && resultMiddle >= 0)
        {
            middleLockText.text = resultMiddle.ToString();
            SetMiddleLockValue();
        }
        else if (resultMiddle > 10)
        {
            ChangeScreen(secondScreen);
            middleLockText.text = "10";
            SetMiddleLockValue();
            ErrorValue();
        }
        else if (resultMiddle < 0)
        {
            ChangeScreen(secondScreen);
            middleLockText.text = "0";
            SetMiddleLockValue();
            ErrorValue();
        }

        if (resultRight <= 10 && resultRight >= 0)
        {
            rightLockText.text = resultRight.ToString();
            SetRightLockValue();
        }
        else if (resultRight > 10)
        {
            ChangeScreen(secondScreen);
            rightLockText.text = "10";
            SetRightLockValue();
            ErrorValue();
        }
        else if (resultRight < 0)
        {
            ChangeScreen(secondScreen);
            rightLockText.text = "0";
            SetRightLockValue();
            ErrorValue();
        }
    }
    public void RightButtonClick()
    {
        int resultLeft = GetLeftLockValue() - 2;
        int resultMiddle = GetMiddleLockValue() + 2;
        int resultRight = GetRightLockValue() - 1;
        if (resultLeft <= 10 && resultLeft >= 0)
        {
            leftLockText.text = resultLeft.ToString();
            SetLeftLockValue();
        }
        else if (resultLeft > 10)
        {
            ChangeScreen(secondScreen);
            leftLockText.text = "10";
            SetLeftLockValue();
            ErrorValue();
        }
        else if (resultLeft < 0)
        {
            ChangeScreen(secondScreen);
            leftLockText.text = "0";
            SetLeftLockValue();
            ErrorValue();
        }


        if (resultMiddle <= 10 && resultMiddle >= 0)
        {
            middleLockText.text = resultMiddle.ToString();
            SetMiddleLockValue();
        }
        else if (resultMiddle > 10)
        {
            ChangeScreen(secondScreen);
            middleLockText.text = "10";
            SetMiddleLockValue();
            ErrorValue();
        }
        else if (resultMiddle < 0)
        {
            ChangeScreen(secondScreen);
            middleLockText.text = "0";
            SetMiddleLockValue();
            ErrorValue();
        }

        if (resultRight <= 10 && resultRight >= 0)
        {
            rightLockText.text = resultRight.ToString();
            SetRightLockValue();
        }
        else if (resultRight > 10)
        {
            ChangeScreen(secondScreen);
            rightLockText.text = "10";
            SetRightLockValue();
            ErrorValue();
        }
        else if (resultRight < 0)
        {
            ChangeScreen(secondScreen);
            rightLockText.text = "0";
            SetRightLockValue();
            ErrorValue();
        }

    }

    public int GetLeftLockValue()
    {
        return leftLockValue;
    }

    public int GetMiddleLockValue()
    {
        return middleLockValue;
    }
    public int GetRightLockValue()
    {
        return rightLockValue;
    }

    public void SetLeftLockValue()
    {
        leftLockValue = Convert.ToInt32(leftLockText.text);
    }

    public void SetMiddleLockValue()
    {
        middleLockValue = Convert.ToInt32(middleLockText.text);
    }

    public void SetRightLockValue()
    {
        rightLockValue = Convert.ToInt32(rightLockText.text);
    }

    public void SetDefaultLockValues()
    {
        leftLockValue = 5;
        middleLockValue = 5;
        rightLockValue = 5;
    }


    public void ErrorValue()
    {
        errorText.text = "ѕолученное значение не может быть меньше 0 больше 10!";
    }

    public void Victory()
    {
        ChangeScreen(fourthScreen);
        victoryText.text = "VICTORY!";

    }

    public void GameOver()
    {
        ChangeScreen(thirdScreen);
        gameOver.text = "Time is UP!\nGame OVER!!!";

    }

    public void ChangeScreen(GameObject state)
    {
        if (currentScreen != null)
        {
            currentScreen.SetActive(false);
            state.SetActive(true);
            currentScreen = state;
        }
    }

    public void ChangeViewLockToDefault()
    {
        leftLockText.text = "5";
        middleLockText.text = "5";
        rightLockText.text = "5";
    }

    public void ResetTimerTextValue()
    {
        timerTextValue = 60f;
        ChangeScreen(firstScreen);
    }

    public void SetFirstScreenActive()
    {
        ChangeScreen(firstScreen);
    }



}

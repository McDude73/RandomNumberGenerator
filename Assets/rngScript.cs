using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

public class rngScript : MonoBehaviour
{
    public KMBombInfo Info;
    public KMSelectable generatebutton;
    public KMSelectable acceptbutton;
    public TextMesh displayTxtL;
    public TextMesh displayTxtR;
    int rngTxt1 = 0;
    int rngTxt2 = 0;
    int lastNumber1 = 3;
    int lastNumber2 = 2;
    int prevAns1 = 10;
    int prevAns2 = 10;
    int isActive = 0;

    protected int randomNL;
    protected int randomNR;

    void Awake()
    {
        GetComponent<KMNeedyModule>().OnNeedyActivation += OnNeedyActivation;
        GetComponent<KMNeedyModule>().OnNeedyDeactivation += OnNeedyDeactivation;
        generatebutton.OnInteract += Operation;
        acceptbutton.OnInteract += Solve;
        GetComponent<KMNeedyModule>().OnTimerExpired += OnTimerExpired;
    }

    protected bool Solve()
    {
        if (isActive == 2)
        {
            prevAns1 = randomNL;
            prevAns2 = randomNR;
            isActive = 0;
            if ((Info.GetSerialNumberNumbers().Last() % 2) == 0)  //Digit has to be even!
            {
                if (Info.GetSerialNumberLetters().Any("AEIOU".Contains)) // 0 - 49
                {
                    if (randomNR % 2 == 0)
                    {
                        if (randomNL < 5)
                        {
                            isActive = 0;
                            GetComponent<KMNeedyModule>().OnPass();
                            displayTxtL.text = "";
                            displayTxtR.text = "";
                        }
                        else
                        {
                            isActive = 0;
                            GetComponent<KMNeedyModule>().OnStrike();
                            GetComponent<KMNeedyModule>().OnPass();
                            displayTxtL.text = "";
                            displayTxtR.text = "";
                        }
                    }
                    else
                    {
                        isActive = 0;
                        GetComponent<KMNeedyModule>().OnStrike();
                        GetComponent<KMNeedyModule>().OnPass();
                        displayTxtL.text = "";
                        displayTxtR.text = "";
                    }
                }
                else // 50 - 99
                {
                    if (randomNR % 2 == 0)
                    {
                        if (randomNL > 4)
                        {
                            if (randomNL < 10)
                            {
                                isActive = 0;
                                GetComponent<KMNeedyModule>().OnPass();
                                displayTxtL.text = "";
                                displayTxtR.text = "";
                            }
                            else
                            {
                                isActive = 0;
                                GetComponent<KMNeedyModule>().OnStrike();
                                GetComponent<KMNeedyModule>().OnPass();
                                displayTxtL.text = "";
                                displayTxtR.text = "";
                            }
                        }
                        else
                        {
                            isActive = 0;
                            GetComponent<KMNeedyModule>().OnStrike();
                            GetComponent<KMNeedyModule>().OnPass();
                            displayTxtL.text = "";
                            displayTxtR.text = "";
                        }
                    }
                    else
                    {
                        isActive = 0;
                        GetComponent<KMNeedyModule>().OnStrike();
                        GetComponent<KMNeedyModule>().OnPass();
                        displayTxtL.text = "";
                        displayTxtR.text = "";
                    }
                }
            }
            else //Digit has to be odd! 
            {
                if (Info.GetSerialNumberLetters().Any("AEIOU".Contains)) // 0 - 49
                {
                    if (randomNR % 2 == 1)
                    {
                        if (randomNL < 5)
                        {
                            isActive = 0;
                            GetComponent<KMNeedyModule>().OnPass();
                            displayTxtL.text = "";
                            displayTxtR.text = "";
                        }
                        else
                        {
                            isActive = 0;
                            GetComponent<KMNeedyModule>().OnStrike();
                            GetComponent<KMNeedyModule>().OnPass();
                            displayTxtL.text = "";
                            displayTxtR.text = "";
                        }
                    }
                    if (randomNR % 2 == 1)
                    {
                        if (randomNL < 5)
                        {
                            isActive = 0;
                            GetComponent<KMNeedyModule>().OnPass();
                            displayTxtL.text = "";
                            displayTxtR.text = "";
                        }
                        else
                        {
                            isActive = 0;
                            GetComponent<KMNeedyModule>().OnStrike();
                            GetComponent<KMNeedyModule>().OnPass();
                            displayTxtL.text = "";
                            displayTxtR.text = "";
                        }
                    }
                    else
                    {
                        isActive = 0;
                        GetComponent<KMNeedyModule>().OnStrike();
                        GetComponent<KMNeedyModule>().OnPass();
                        displayTxtL.text = "";
                        displayTxtR.text = "";
                    }
                }
                else // 50 - 99
                {
                    if (randomNR % 2 == 1)
                    {
                        if (randomNL > 4)
                        {
                            if (randomNL < 10)
                            {
                                isActive = 0;
                                GetComponent<KMNeedyModule>().OnPass();
                                displayTxtL.text = "";
                                displayTxtR.text = "";
                            }
                            else
                            {
                                isActive = 0;
                                GetComponent<KMNeedyModule>().OnStrike();
                                GetComponent<KMNeedyModule>().OnPass();
                                displayTxtL.text = "";
                                displayTxtR.text = "";
                            }
                        }
                        else
                        {
                            isActive = 0;
                            GetComponent<KMNeedyModule>().OnStrike();
                            GetComponent<KMNeedyModule>().OnPass();
                            displayTxtL.text = "";
                            displayTxtR.text = "";
                        }
                    }
                    else
                    {
                        isActive = 0;
                        GetComponent<KMNeedyModule>().OnStrike();
                        GetComponent<KMNeedyModule>().OnPass();
                        displayTxtL.text = "";
                        displayTxtR.text = "";
                    }
                }
            }
            return false;
        }
        return false;
    }

    protected bool Operation()
    {
        if (isActive >= 1)
        {
            isActive = 2;
            System.Random rnd = new System.Random();
            rngTxt1 = rnd.Next(0, 10);
            lastNumber1 = randomNL;
            randomNL = rngTxt1;
            if (lastNumber1 == rngTxt1)
            {
                randomNL = randomNL + 4;
            }
            if (randomNL > 9)
            {
                randomNL = randomNL - 10;
            }
            displayTxtL.text = randomNL.ToString();
            System.Random rnd2 = new System.Random();
            rngTxt2 = rnd2.Next(-3, 4);
            randomNR = rngTxt1 + rngTxt2;
            if (lastNumber2 == rngTxt2)
            {
                randomNR = randomNR * 3;
            }
            lastNumber2 = randomNR;
            if (prevAns1 == randomNL)
            {
                if (prevAns2 == randomNR)
                {
                    randomNL = randomNL - 1;
                    randomNR = randomNR + 5;
                }
            }
            if (randomNR > 29)
            {
                randomNR = randomNR - 30;
            }
            if (randomNR > 19)
            {
                randomNR = randomNR - 20;
            }
            if (randomNR > 9)
            {
                randomNR = randomNR - 10;
            }
            if (randomNR < 0)
            {
                randomNR = randomNR + 10;
            }
            displayTxtR.text = randomNR.ToString();
        }
        return false;
    }

    protected void OnNeedyActivation()
    {
        displayTxtL.text = "~";
        displayTxtR.text = "~";
        isActive = 1;
    }

    protected void OnNeedyDeactivation()
    {
        isActive = 0;
    }

    protected void OnTimerExpired()
    {
        GetComponent<KMNeedyModule>().OnStrike();
        displayTxtL.text = "";
        displayTxtR.text = "";
        isActive = 0;
    }
}
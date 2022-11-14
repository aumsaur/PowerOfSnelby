using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInput : MonoBehaviour
{
    public float baseInput = 1;
    public float powerInput = 1;
    public TMP_Text baseInputText;
    public TMP_Text powerInputText;
    public float answerOfUser;

    // Start is called before the first frame update
    void Start()
    {
        baseInput = 1;
        powerInput = 1;
        baseInputText.text = baseInput.ToString();
        powerInputText.text = powerInput.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        baseInputText.text = baseInput.ToString();
        powerInputText.text = powerInput.ToString();
    }

    public void AddBase()
    {
        baseInput += 1;
        if (powerInput == 0)
        {
            baseInput += 1;
        }
        //Debug.Log(baseInput.ToString());
        //Debug.Log(powerInput.ToString());
        answerOfUser = Mathf.Pow(baseInput, powerInput);
        Debug.Log(answerOfUser.ToString());
    }

    public void MinusBase()
    {
        baseInput -= 1;
        if (powerInput == 0)
        {
            baseInput -= 1;
        }
        //Debug.Log(baseInput.ToString());
        //Debug.Log(powerInput.ToString());
        answerOfUser = Mathf.Pow(baseInput, powerInput);
        Debug.Log(answerOfUser.ToString());
    }

    public void AddPower()
    {
        powerInput += 1;
        if (baseInput == 0)
        {
            powerInput += 1;
        }
        //Debug.Log(baseInput.ToString());
        //Debug.Log(powerInput.ToString());
        answerOfUser = Mathf.Pow(baseInput, powerInput);
        Debug.Log(answerOfUser.ToString());
    }

    public void MinusPower()
    {
        powerInput -= 1;
        if (baseInput == 0)
        {
            powerInput -= 1;
        }
        //Debug.Log(baseInput.ToString());
        //Debug.Log(powerInput.ToString());
        answerOfUser = Mathf.Pow(baseInput, powerInput);
        Debug.Log(answerOfUser.ToString());
    }

    public float GetAnswer()
    {
        return answerOfUser;
    }
}

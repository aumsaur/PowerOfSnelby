using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HUDHandler : MonoBehaviour
{
    public static HUDHandler currentInstance;

    public Vector2 currentInputEquation { get; private set; }
    public bool currentSign { get; private set; }

    [SerializeField] private TextMeshProUGUI baseText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI signText;

    [SerializeField] private TextMeshProUGUI equationText;
    
    [SerializeField] private TextMeshProUGUI streakText;
    [SerializeField] private TextMeshProUGUI progressText;

    private int _progress;

    //[VectorLabels("Base Input", "Power Input"), SerializeField] private Vector2 input = new Vector2(1,1);

    // Start is called before the first frame update
    void Start()
    {
        currentInstance = this;
        currentInputEquation = new Vector2(Int16.Parse(baseText.text), Int16.Parse(powerText.text));
        currentSign = true;
    }

    public void UpdateEquation(string equation)
    {
        equationText.text = equation;
    }

    public void UpdateInputEquation(Vector2 input)
    {
        baseText.text = input.x.ToString();
        powerText.text = input.y.ToString();
        currentInputEquation = new Vector2(input.x, input.y);
    }

    public bool UpdateSign()
    {
        signText.text = signText.text == "+" ? "-" : "+";
        currentSign = !currentSign;
        return signText.text == "+";
    }

    public void UpdateStreak(int streak)
    {
        switch (streak)
        {
            case 0:
                streakText.enabled = false;
                break;
            default:
                streakText.enabled = true;
                streakText.text = streak.ToString();
                break;
        }
        progressText.text = _progress.ToString();
    }
}

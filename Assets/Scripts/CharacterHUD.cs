using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Windows;

public class CharacterHUD : MonoBehaviour
{
    public static CharacterHUD currentInstance;

    [SerializeField] private TextMeshProUGUI baseText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI equationText;
    [SerializeField] private TextMeshProUGUI streakText;
    [SerializeField] private TextMeshProUGUI progressText;

    private int _progress;

    //[VectorLabels("Base Input", "Power Input"), SerializeField] private Vector2 input = new Vector2(1,1);

    // Start is called before the first frame update
    void Start()
    {
       currentInstance = this;
    }

    public void UpdateEquation(string equation)
    {
        equationText.text = equation;
    }

    public void UpdateInputEquation(Vector2 input)
    {
        baseText.text = input.x.ToString();
        powerText.text = input.y.ToString();
    }

    public void UpdateStreak(int streak)
    {
        switch (streak)
        {
            case 0:
                streakText.enabled = false;
                break;
            default:
                _progress += 1;
                streakText.enabled = true;
                streakText.text = streak.ToString();
                break;
        }
        progressText.text = _progress.ToString();
    }
}

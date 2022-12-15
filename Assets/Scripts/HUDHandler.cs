using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class HUDHandler : MonoBehaviour
{
    public static HUDHandler currentInstance;

    public Vector2 currentInputEquation { get; private set; }

    [SerializeField] private TextMeshProUGUI baseText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI signText;

    [SerializeField] private TextMeshProUGUI equationText;
    
    [SerializeField] private TextMeshProUGUI streakText;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI progressTargetText;

    [SerializeField] private GameObject summaryOverlay;
    [SerializeField] private TextMeshProUGUI summaryScore;
    [SerializeField] private TextMeshProUGUI progressScore;
    [SerializeField] private TextMeshProUGUI progressRequire;
    [SerializeField] private GameObject floatingTextPrefabs;

    private int _progress;
    private int _progressRequire;

    // Start is called before the first frame update
    void Start()
    {
        currentInstance = this;
        currentInputEquation = new Vector2(Int16.Parse(baseText.text), Int16.Parse(powerText.text));
        summaryOverlay.SetActive(false);
        StartCoroutine(SetupHUD());
    }

    public IEnumerator SetupHUD(bool sign = true,int progressRequire = 10)
    {
        yield return null;
        _progressRequire = progressRequire;
        signText.text = sign ? "+" : "-";

        yield return new WaitForSeconds(3);
        progressTargetText.text = progressRequire.ToString();
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
                _progress += 1;
                break;
        }
        progressText.text = _progress.ToString();
        progressText.color = _progress > _progressRequire ? ScoreHandler.currentInstance.progressOver :progressText.color;
    }

    public void ShowSummary(int progressScore)
    {
        summaryOverlay.SetActive(true);
        summaryScore.text = ScoreHandler.currentInstance.GetSummary(progressScore).ToString();
        this.progressScore.text = progressText.text;
        this.progressScore.color = _progress >= _progressRequire ? progressText.color : ScoreHandler.currentInstance.progressBelow;
        progressRequire.text = progressTargetText.text;
    }
}

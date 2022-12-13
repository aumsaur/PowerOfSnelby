using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler currentInstance;

    [SerializeField] private TextMeshProUGUI totalScore;

    [SerializeField] private Color positiveScore;

    [SerializeField] private Color negativeScore;

    [SerializeField] private GameObject floatingTextPrefabs;

    private int _totalScore;

    // Start is called before the first frame update
    void Start()
    {
        currentInstance = this;
    }

    public void TestAccess(int something)
    {
        Debug.Log("Something pass as" + something);
    }

    public void AddScore(int scoreToAdd)
    {
        totalScore.text = (_totalScore + scoreToAdd).ToString();

        GameObject newFloatingText = Instantiate(floatingTextPrefabs, transform.position, Quaternion.identity, transform);
        newFloatingText.GetComponentInChildren<TextMeshPro>().text = scoreToAdd > 0 ? "+ " + scoreToAdd.ToString() : "- " + scoreToAdd.ToString();
        newFloatingText.GetComponentInChildren<TextMeshPro>().color = scoreToAdd > 0 ? positiveScore : negativeScore;
    }
}

using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler currentInstance;

    [SerializeField] private TextMeshProUGUI totalScore;
    public Color progressOver { get; [SerializeField] private set; }
    public Color progressBelow { get; [SerializeField] private set; }

    [SerializeField] private Color positiveScore;
    [SerializeField] private Color negativeScore;

    [SerializeField] private GameObject floatingTextPrefabs;

    private int _totalScore;
    private int _progress;

    // Start is called before the first frame update
    void Start()
    {
        currentInstance = this;
    }

    public int GetSummary(int progressScore)
    {
        return (_totalScore + _progress * progressScore);
    }

    public void AddScore(int scoreToAdd)
    {
        totalScore.text = (_totalScore + scoreToAdd).ToString().PadLeft(8, '0');
        _progress += 1;

        GameObject newFloatingText = Instantiate(floatingTextPrefabs, transform.position, Quaternion.identity, transform);
        newFloatingText.GetComponentInChildren<TextMeshPro>().text = scoreToAdd > 0 ? "+ " + scoreToAdd.ToString() : "- " + scoreToAdd.ToString();
        newFloatingText.GetComponentInChildren<TextMeshPro>().color = scoreToAdd > 0 ? positiveScore : negativeScore;
    }
}

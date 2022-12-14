using UnityEngine;
using TMPro;

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

    public void AddScore(int scoreToAdd)
    {
        totalScore.text = (_totalScore + scoreToAdd).ToString().PadLeft(8, '0');

        GameObject newFloatingText = Instantiate(floatingTextPrefabs, transform.position, Quaternion.identity, transform);
        newFloatingText.GetComponentInChildren<TextMeshPro>().text = scoreToAdd > 0 ? "+ " + scoreToAdd.ToString() : "- " + scoreToAdd.ToString();
        newFloatingText.GetComponentInChildren<TextMeshPro>().color = scoreToAdd > 0 ? positiveScore : negativeScore;
    }
}

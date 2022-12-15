using UnityEngine;
using TMPro;
using System;
using System.Collections;

// maze rule and mechanic handle
public class MazeHandler : MonoBehaviour
{
    public static MazeHandler currentInstance;

    [Tooltip("x: for Correct Door\ny: for Incorrect Door"), SerializeField] private Vector2 flatScore;
    [SerializeField] private GameObject floatingTextPrefabs;

    private GameObject newFloatingText;

    private void Start()
    {
        currentInstance = this;
    }

    public void GrantReward(bool isCorrectDoor, IEnumerator callBack)
    {
        if (isCorrectDoor)
        {
            StartCoroutine(callBack);
        }

        ScoreHandler.currentInstance.AddScore(isCorrectDoor ? (int)Mathf.Abs(flatScore.x) : -(int)Mathf.Abs(flatScore.y));
        
    }  
}

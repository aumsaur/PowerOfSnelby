using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : ScriptableObject
{
    public GameObject prefabs;
    [Tooltip("When correct in each difficulty")] public Vector3 scorePositive;
    [Tooltip("When incorrect in each difficulty")] public Vector3 scoreNegative;
    [Tooltip("Time limit in each difficulty")] public Vector3 timeDuration;
    [Tooltip("Number of solved to pass requirement in each difficulty")] public Vector3 totalRequire;
    public int[] topics;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent : MonoBehaviour
{
    // monster data : prefab, duration, score multiplier, topic level 
    public static BattleEvent currentInstance;
    public BattleUnit currentUnit { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}

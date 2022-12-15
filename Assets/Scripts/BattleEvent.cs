using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent : MonoBehaviour
{
    // monster data : prefab, duration, score multiplier, topic level 
    [SerializeField] private GameObject battleUnitPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // pass prefab to BattleHandler in another scene ... how?
    }
}
